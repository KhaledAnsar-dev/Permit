using DVLD___V1._0.GlobalClasses;
using DVLD___V1._0.LocalLicenses;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD___V1._0.DetainLicense
{
    public partial class frmDetainLicense : Form
    {
        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private int _SelectedLicenseID;
        private int _DetainID;

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblCreatedByUser.Text = clsGlobalSettings.CurrentUser.UserName;
        }
        private void _LicenseSelector(int LicenseID)
        {
            // Check if license exists
            if (LicenseID == -1)
                return;

            // Check if the license is not detained
            if(ucLicenseInfoWithFilter1.SelectedLicense.IsDetained)
            {
                MessageBox.Show("Selected License is already detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucLicenseInfoWithFilter1.DefaultDriverLicenseCard();
                return;
            }

            // Check if the license is active
            if (!ucLicenseInfoWithFilter1.SelectedLicense.IsActive)
            {
                MessageBox.Show("Selected License is not active, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucLicenseInfoWithFilter1.DefaultDriverLicenseCard();
                return;
            }

            _SelectedLicenseID = LicenseID;

            lblLicenseID.Text = _SelectedLicenseID.ToString();

            btnLicensesHistory.Enabled = (_SelectedLicenseID != -1);

            txtFineFees.Enabled = true;
            txtFineFees.Focus();

            btnDetainLicense.Enabled = true;

        }
        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            float FineFees = Convert.ToSingle(txtFineFees.Text.Trim());
            _DetainID = ucLicenseInfoWithFilter1.SelectedLicense.Detain(FineFees, clsGlobalSettings.CurrentUser.UserID);

            if(_DetainID == -1)
            {
                MessageBox.Show("Faild to Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("License Detained Successfully with ID=" + _DetainID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            lblDetainID.Text = _DetainID.ToString();
            btnViewLicense.Enabled = true;
            btnDetainLicense.Enabled = false;
            ucLicenseInfoWithFilter1.FilterEnabled = false;
            txtFineFees.Enabled = false;

        }

        private void btnViewLicense_Click(object sender, EventArgs e)
        {
            frmDriverLicense DriverInterLicense = new frmDriverLicense(_SelectedLicenseID);
            DriverInterLicense.ShowDialog();
        }
        private void btnLicensesHistory_Click(object sender, EventArgs e)
        {
            frmLicensesHistory LicensesHistory = new frmLicensesHistory(ucLicenseInfoWithFilter1.SelectedLicense.DriverInfo.PersonID);
            LicensesHistory.ShowDialog();
        }
        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFineFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFineFees, null);

            };
        }
    }
}
    

