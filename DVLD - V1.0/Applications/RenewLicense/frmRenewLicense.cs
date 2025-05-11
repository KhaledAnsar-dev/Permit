using DVLD___V1._0.GlobalClasses;
using DVLD___V1._0.InternationalLicenses;
using DVLD___V1._0.LocalLicenses;
using DVLD___V1._0.User_Controls;
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

namespace DVLD___V1._0.RenewLicense
{
    public partial class frmRenewLicense : Form
    {

        int _RenewedLicenseID;
        public frmRenewLicense()
        {
            InitializeComponent();
        }
 

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsLicense RenewedLicense = ucLicenseInfoWithFilter1.SelectedLicense.Renew(clsGlobalSettings.CurrentUser.UserID , txtNotes.Text);

            if (RenewedLicense == null)
            {
                MessageBox.Show("Faild to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblRenewedLicenseID.Text = RenewedLicense.LicenseID.ToString();
            lblApplicationID.Text = RenewedLicense.ApplicationID.ToString();
            _RenewedLicenseID = RenewedLicense.LicenseID;


            MessageBox.Show("Licensed Renewed Successfully with ID=" + _RenewedLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);


            btnRenew.Enabled = false;
            ucLicenseInfoWithFilter1.FilterEnabled = false;
            btnViewLicense.Enabled = true;
        }
        private void btnViewLicense_Click(object sender, EventArgs e)
        {
            frmDriverLicense DriverInterLicense = new frmDriverLicense(_RenewedLicenseID);
            DriverInterLicense.ShowDialog();
        }
        private void btnLicensesHistory_Click(object sender, EventArgs e)
        {
            frmLicensesHistory LicensesHistory = new frmLicensesHistory(ucLicenseInfoWithFilter1.SelectedLicense.DriverInfo.PersonID);
            LicensesHistory.ShowDialog();
        }
        private void btnNotes_Click(object sender, EventArgs e)
        {
            if (btnNotes.Tag.ToString() == "Hide")
            {
                txtNotes.Visible = true;
                btnNotes.Tag = "Visible";
                btnNotes.Text = "Hide Notes";
            }
            else
            {
                txtNotes.Visible = false;
                btnNotes.Tag = "Hide";
                btnNotes.Text = "Add Notes";
            }
        }
        private void _CopyLicenseInfoToRenewedLicense(int SelectedLicenseID)
        {

            // Since we are replacing an old license, the new one will depend on the same values
            float LicenseFees = ucLicenseInfoWithFilter1.SelectedLicense.LicenseClassInfo.ClassFees;
            float ApplicationFees = clsApplicationTypes.Find((int)clsApplications.enApplicationType.RenewDrivingLicense).ApplicationFees;
            lblTotalFees.Text = (ApplicationFees + LicenseFees).ToString() + " DA";

            // Copy old license info to the renewed license
            int Validity = ucLicenseInfoWithFilter1.SelectedLicense.LicenseClassInfo.DefaultValidityLength;
            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            lblLicenseFees.Text = LicenseFees.ToString() + " DA";
            lblLicenseExpDate.Text = Validity.ToString();
            txtNotes.Text = ucLicenseInfoWithFilter1.SelectedLicense.Notes;
        }
        private void _LicenseSelector(int SelectedLicenseID)
        {
            if (SelectedLicenseID == -1)
            {
                MessageBox.Show("No license found with ID: " + SelectedLicenseID, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }

            // Check if license is not expired
            if (!ucLicenseInfoWithFilter1.SelectedLicense.IsLicenseExpired())
            {
                MessageBox.Show("Selected License is not yet expiared, it will expire on: " + clsFormat.DateToShort(ucLicenseInfoWithFilter1.SelectedLicense.ExpirationDate)
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucLicenseInfoWithFilter1.DefaultDriverLicenseCard();
                btnRenew.Enabled = false;
                return;
            }


            // Check if license is active
            if (!ucLicenseInfoWithFilter1.SelectedLicense.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucLicenseInfoWithFilter1.DefaultDriverLicenseCard();
                btnRenew.Enabled = false;
                return;
            }

            btnLicensesHistory.Enabled = SelectedLicenseID != -1;

            _CopyLicenseInfoToRenewedLicense(SelectedLicenseID);

            // Now we are ready to issue renewed license
            btnRenew.Enabled = true;
        }
        private void ucLicenseInfoWithFilter1_Load(object sender, EventArgs e)
        {
            ucLicenseInfoWithFilter1.FilterFocus();
            
            // Default Application Info
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.RenewDrivingLicense).ApplicationFees.ToString();
            
            // Default New License Info
            lblLicenseIssueDate.Text = lblApplicationDate.Text;
            lblCreatedByUser.Text = clsGlobalSettings.CurrentUser.UserID.ToString();
        }
    }
}
