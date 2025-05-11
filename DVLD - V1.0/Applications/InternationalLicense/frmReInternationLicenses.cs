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

namespace DVLD___V1._0.InternationalLicenses
{
    public partial class frmReInternationLicenses : Form
    {
        public frmReInternationLicenses()
        {
            InitializeComponent();
        }

        private int _InternationalLicenseID;

        private void _LicenseSelector(int LicenseID)
        {
            if(LicenseID == -1)
            {
                MessageBox.Show("No license found with ID: " + LicenseID, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblLocalLicenseID.Text = LicenseID.ToString();

            btnLicensesHistory.Enabled = LicenseID != -1;

            //check the license class, person could not issue international license without having
            //normal license of class 3.

            if (ucLicenseInfoWithFilter1.SelectedLicense.LicenseClassID != 3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucLicenseInfoWithFilter1.DefaultDriverLicenseCard();
                return;
            }

            // Check if person already has an active international license

            int ActiveInternationalLicenseID = clsInterLicense.GetActiveInternationalLicenseIDByDriverID
                (ucLicenseInfoWithFilter1.SelectedLicense.DriverID);

            if (ActiveInternationalLicenseID != -1)
            {
                MessageBox.Show("Person already have an active international license with ID = " + ActiveInternationalLicenseID.ToString(), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnViewInterLicense.Enabled = true;
                _InternationalLicenseID = ActiveInternationalLicenseID;
                btnIssueInterLicense.Enabled = false;
                ucLicenseInfoWithFilter1.DefaultDriverLicenseCard();
                return;
            }
            btnIssueInterLicense.Enabled = true;

        }
        private void btnIssueInterLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsInterLicense InterLicense = new clsInterLicense();

            InterLicense.DriverID = ucLicenseInfoWithFilter1.SelectedLicense.DriverID;
            InterLicense.IssuedUsingLocalLicenseID = ucLicenseInfoWithFilter1.LicenseID;
            InterLicense.IssueDate = DateTime.Now;
            InterLicense.ExpirationDate = InterLicense.IssueDate.AddYears(1);
            InterLicense.IsActive = true;

            //those are the information for the base application, because it inhirts from application, they are part of the sub class.

            InterLicense.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
            InterLicense.ApplicantPersonID = ucLicenseInfoWithFilter1.SelectedLicense.DriverInfo.PersonID;
            InterLicense.ApplicationDate = DateTime.Now;
            InterLicense.ApplicationTypeID = Convert.ToInt32(clsApplications.enApplicationType.NewInternationalLicense);
            InterLicense.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
            InterLicense.LastStatusDate = DateTime.Now;
            InterLicense.PaidFees = clsApplicationTypes.Find((int)clsApplications.enApplicationType.NewInternationalLicense).ApplicationFees;

            if (!InterLicense.Save())
            {
                MessageBox.Show("Faild to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblApplicationID.Text = InterLicense.ApplicationID.ToString();
            _InternationalLicenseID = InterLicense.InternationalLicenseID;
            lblInternationalLicenseID.Text = InterLicense.InternationalLicenseID.ToString();
            MessageBox.Show("International License Issued Successfully with ID=" + _InternationalLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnIssueInterLicense.Enabled = false;
            ucLicenseInfoWithFilter1.FilterEnabled = false;
            btnViewInterLicense.Enabled = true;
        }
        private void btnViewInterLicense_Click(object sender, EventArgs e)
        {
            frmDriverInterLicense DriverInterLicense = new frmDriverInterLicense(_InternationalLicenseID);
            DriverInterLicense.ShowDialog();
        }
        private void btnLicensesHistory_Click(object sender, EventArgs e)
        {
            frmLicensesHistory LicensesHistory = new frmLicensesHistory(ucLicenseInfoWithFilter1.SelectedLicense.DriverInfo.PersonID);
            LicensesHistory.ShowDialog();
        }

        private void frmReInternationLicenses_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = lblApplicationDate.Text;
            lblLicenseExpDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(1));//add one year.
            lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.NewInternationalLicense).ApplicationFees.ToString();
            lblCreatedByUser.Text = clsGlobalSettings.CurrentUser.UserName;
        }


    }
}
