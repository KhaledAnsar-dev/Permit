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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD___V1._0.User_Controls
{
    public partial class ucLocalLicenseApp : UserControl
    {
        public ucLocalLicenseApp()
        {
            InitializeComponent();
        }

        private clsLocalLicenseApps _LocalDrivingLicenseApplication;

        private int _LocalDrivingLicenseApplicationID = -1;

        private int _LicenseID;

        public int LocalDrivingLicenseApplicationID
        {
            get { return _LocalDrivingLicenseApplicationID; }
        }

        private void _ResetLocalDrivingLicenseApplicationInfo()
        {
            lblLicenseApplicationID.Text = "";
            lblAppliedLicense.Text = "";
            lblPassedTests.Text = "";
            ucBaseApplicationInfo1.ResetApplicationInfo();
        }
        private void _FillLocalDrivingLicenseApplicationInfo()
        {
            _LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
            lblLicenseApplicationID.Text = _LocalDrivingLicenseApplicationID.ToString();
            lblAppliedLicense.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblPassedTests.Text = _LocalDrivingLicenseApplication.GetPassedTestCount().ToString();
            ucBaseApplicationInfo1.LoadApplicationInfo(_LocalDrivingLicenseApplication.ApplicationID);
        }
        public void LoadApplicationInfoByLocalDrivingAppID(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplication = clsLocalLicenseApps.FindByLocalDLAppID(LocalDrivingLicenseApplicationID);
            if (_LocalDrivingLicenseApplication == null)
            {
                _ResetLocalDrivingLicenseApplicationInfo();


                MessageBox.Show("No Application with ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_LocalDrivingLicenseApplication.IsLicenseIssued())
                btnShowLicense.Enabled = true;

            _FillLocalDrivingLicenseApplicationInfo();
        }
        public void LoadApplicationInfoByApplicationID(int ApplicationID)
        {
            _LocalDrivingLicenseApplication = clsLocalLicenseApps.FindByApplicationID(ApplicationID);
            if (_LocalDrivingLicenseApplication == null)
            {
                _ResetLocalDrivingLicenseApplicationInfo();


                MessageBox.Show("No Application with ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLocalDrivingLicenseApplicationInfo();
        }


        private void btnShowLicense_Click(object sender, EventArgs e)
        {
            _LicenseID = clsLocalLicenseApps.FindByLocalDLAppID(_LocalDrivingLicenseApplicationID).GetActiveLicenseID();
            frmDriverLicense DriverLicense = new frmDriverLicense(_LicenseID);
            DriverLicense.ShowDialog();
        }
    }
}
