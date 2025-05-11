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
using static DVLD_Business.clsApplications;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD___V1._0.ReplaceLicense
{
    public partial class frmReplaceLicense : Form
    {
        public frmReplaceLicense()
        {
            InitializeComponent();
        }

        private int _ReplacedLicenseID = -1;

        private clsLicense.enIssueReason _GetIssueReason()
        {
            if (rbDamaged.Checked)
            {
                return clsLicense.enIssueReason.DamagedReplacement;
            }
            else
                return clsLicense.enIssueReason.LostReplacement;
        }


        private void _LicenseSelector(int LicenseID)
        {
            if(LicenseID == -1)
            {
                MessageBox.Show("No license found with ID: " + LicenseID, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Dont allow a replacement if is Not Active
            if (!ucLicenseInfoWithFilter1.SelectedLicense.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucLicenseInfoWithFilter1.DefaultDriverLicenseCard();
                btnReplaceLicense.Enabled = false;
                return;
            }

            btnLicensesHistory.Enabled = (LicenseID != -1);

            lblOldLicenseID.Text = LicenseID.ToString();

            btnReplaceLicense.Enabled = true;
        }
        private void btnReplaceLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Issue a Replacement for the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsLicense ReplacedLicense =
                ucLicenseInfoWithFilter1.SelectedLicense.Replace(clsGlobalSettings.CurrentUser.UserID, _GetIssueReason());

            if(ReplacedLicense == null)
            {
                MessageBox.Show("Faild to Issue a replacemnet for this  License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            lblReplacedLicenseID.Text = ReplacedLicense.LicenseID.ToString();
            lblApplicationID.Text = ReplacedLicense.ApplicationID.ToString();
            _ReplacedLicenseID = ReplacedLicense.LicenseID;

            MessageBox.Show("Licensed Replaced Successfully with ID=" + _ReplacedLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnReplaceLicense.Enabled = false;
            btnViewReplacedLicense.Enabled = (_ReplacedLicenseID != -1);
            ucLicenseInfoWithFilter1.FilterEnabled = false;
        }
        private void btnViewReplacedLicense_Click(object sender, EventArgs e)
        {
            frmDriverLicense DriverInterLicense = new frmDriverLicense(_ReplacedLicenseID);
            DriverInterLicense.ShowDialog();
        }
        private void btnLicensesHistory_Click(object sender, EventArgs e)
        {
            frmLicensesHistory LicensesHistory = new frmLicensesHistory(ucLicenseInfoWithFilter1.SelectedLicense.DriverInfo.PersonID);
            LicensesHistory.ShowDialog();
        }

        private void frmReplaceLicense_Load(object sender, EventArgs e)
        {
            ucLicenseInfoWithFilter1.FilterFocus();

            // Default Application Info
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);

            // Default New License Info
            lblCreatedByUser.Text = clsGlobalSettings.CurrentUser.UserID.ToString();

            rbDamaged.Checked = true;

        }
        private int _GetApplicationTypeID()
        {
            if(rbDamaged.Checked)
                return Convert.ToInt32(clsApplications.enApplicationType.ReplaceDamagedDrivingLicense);
            else
                return Convert.ToInt32(clsApplications.enApplicationType.ReplaceLostDrivingLicense);
        }
        private void rbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            lblTitle.Text = "Replacement for Damaged License";
            lblApplicationFees.Text = clsApplicationTypes.Find(_GetApplicationTypeID()).ApplicationFees.ToString();
        }
        private void rbLost_CheckedChanged(object sender, EventArgs e)
        {
            lblTitle.Text = "Replacement for Lost License";
            lblApplicationFees.Text = clsApplicationTypes.Find(_GetApplicationTypeID()).ApplicationFees.ToString();
        }
    }
}
