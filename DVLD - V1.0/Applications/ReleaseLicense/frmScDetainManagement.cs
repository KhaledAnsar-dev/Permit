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
    public partial class frmScDetainManagement : Form
    {
        private DataTable _dtDetainedLicenses;

        public frmScDetainManagement()
        {
            InitializeComponent();
        }
        private string _FilterColumn = "None";

        private void _ApplyFilter()
        {
            if (_FilterColumn == "Is Released")
            {
                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", _FilterColumn, 1);
                return;
            }

            if (txtFilter.Text.Trim() == "" || _FilterColumn == "None")
            {
                _dtDetainedLicenses.DefaultView.RowFilter = "";
                return;
            }

            _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}" , _FilterColumn , txtFilter.Text.Trim());
        }
        private void _ChooseFilter()
        {
            switch (cbFilterType.Text)
            {
                case "Detain ID":
                    {
                        _FilterColumn = "Detain ID";
                        break;
                    }
                case "License ID":
                    {
                        _FilterColumn = "License ID";
                        break;
                    }
                case "Is Released":
                    {
                        _FilterColumn = "Is Released";
                        break;
                    }
                default:
                    {
                        _FilterColumn = "None";
                        break;
                    }
            }

        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }
        private void cbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ChooseFilter();
            txtFilter.Text = "";

            if (_FilterColumn == "Is Released")
            {
                txtFilter.Enabled = false;
                _ApplyFilter();
            }
            else
                txtFilter.Enabled = true;
            
        }
        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_FilterColumn == "Detain ID" || _FilterColumn == "License ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void frmScDetainManagement_Load(object sender, EventArgs e)
        {
            _dtDetainedLicenses = clsDetain.GetAllDetainedLicenses();
            dgvDetainLicenseTable.DataSource = _dtDetainedLicenses;
            cbFilterType.SelectedIndex = 0;
        }
   
        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicense DetainLicense = new frmDetainLicense();
            DetainLicense.ShowDialog();
            // Refresh
            frmScDetainManagement_Load(null, null);
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseLicense ReleaseLicense = new frmReleaseLicense();
            ReleaseLicense.ShowDialog();

            // Refresh
            frmScDetainManagement_Load(null, null);
        }

        private void btnPersonCMS_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainLicenseTable.CurrentRow.Cells[1].Value;

            frmShowPersonDetails PersonDetails = new frmShowPersonDetails
                (clsLicense.Find(LicenseID).DriverInfo.PersonID);
            PersonDetails.ShowDialog();
        }

        private void btnLicenseInfoCMS_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainLicenseTable.CurrentRow.Cells[1].Value;
            frmDriverLicense DriverLicenseInfo = new frmDriverLicense(LicenseID);
            DriverLicenseInfo.ShowDialog();
        }

        private void btnPersonLicenseHistoryCMS_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainLicenseTable.CurrentRow.Cells[1].Value;
            frmLicensesHistory LicensesHistory = new frmLicensesHistory
                (clsLicense.Find(LicenseID).DriverInfo.PersonID);
            LicensesHistory.ShowDialog();
        }

        private void btnReleaseLicenseCMS_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainLicenseTable.CurrentRow.Cells[1].Value;
            frmReleaseLicense ReleaseLicense = new frmReleaseLicense(LicenseID);
            ReleaseLicense.ShowDialog();
            frmScDetainManagement_Load(null, null);
        }

        private void guna2ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            bool IsReleased = (bool)dgvDetainLicenseTable.CurrentRow.Cells[3].Value;

            btnReleaseLicenseCMS.Enabled = IsReleased? false : true;
        }
    }
}
