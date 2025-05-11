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
    public partial class frmReleaseLicense : Form
    {
        private int _SelectedLicenseID;

        public frmReleaseLicense()
        {
            InitializeComponent();
        }

        public frmReleaseLicense(int LicenseID)
        {
            InitializeComponent();

            _SelectedLicenseID = LicenseID; 
            ucLicenseInfoWithFilter1.LoadDriverLicenseInfo(LicenseID);
            ucLicenseInfoWithFilter1.FilterEnabled = false;
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

        private void frmReleaseLicense_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.ReleaseDetainedDrivingLicsense).ApplicationFees.ToString() + " DA";
            lblCreatedByUser.Text = clsGlobalSettings.CurrentUser.UserID.ToString();
        }
        private void _LicenseSelector(int LicenseID)
        {
            if(LicenseID == -1)
            {
                MessageBox.Show("License With ID : " + LicenseID + " Doesn't Exists", "Not Allowed");
                return;
            }

            // Check if the license is detained

            if(!ucLicenseInfoWithFilter1.SelectedLicense.IsDetained)
            {
                MessageBox.Show("License With ID : " + LicenseID + " Is Not Deatined", "Not Allowed");
                ucLicenseInfoWithFilter1.DefaultDriverLicenseCard();
                return;
            }

            _SelectedLicenseID = LicenseID;

            // Load the rest info
            lblLicenseID.Text = _SelectedLicenseID.ToString();
            if (ucLicenseInfoWithFilter1.SelectedLicense.DetainedInfo == null)
                return;
            lblDetainDate.Text = ucLicenseInfoWithFilter1.SelectedLicense.DetainedInfo.DetainDate.ToString();
            lblDetainID.Text = ucLicenseInfoWithFilter1.SelectedLicense.DetainedInfo.DetainID.ToString();
            float DetainFineFees = ucLicenseInfoWithFilter1.SelectedLicense.DetainedInfo.FineFees;
            float ApplicationFees = clsApplicationTypes.Find((int)clsApplications.enApplicationType.ReleaseDetainedDrivingLicsense).ApplicationFees;

            lblFineFees.Text = DetainFineFees.ToString() + " DA";
            lblTotalFees.Text = (DetainFineFees + ApplicationFees).ToString() + " DA";

            btnLicensesHistory.Enabled = LicenseID != -1;

            btnReleaseLicense.Enabled = true;          
        }
        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release this detained  license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            int ApplicationID = -1;

            bool IsReleased = ucLicenseInfoWithFilter1.SelectedLicense.ReleaseDetainedLicense(clsGlobalSettings.CurrentUser.UserID, ref ApplicationID);

            if (IsReleased)
            {
                MessageBox.Show("Detained License released Successfully ", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnReleaseLicense.Enabled = false;
                btnViewLicense.Enabled = true;
                ucLicenseInfoWithFilter1.FilterEnabled = false;
                lblApplicationID.Text = ApplicationID.ToString();
                return;
            }

            MessageBox.Show("Faild to to release the Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

    }
}
