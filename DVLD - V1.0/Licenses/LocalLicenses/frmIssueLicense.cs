using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using static DVLD_Business.clsLicense;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD___V1._0.LocalLicenses
{
    public partial class frmIssueLicense : Form
    {
        public frmIssueLicense(int LocalDLA_ID)
        {
            InitializeComponent();

            this._LocalDLA_ID = LocalDLA_ID;
        }

        private int _LocalDLA_ID;
        private clsLocalLicenseApps _LocalDLA;

        private void btnSizeEd_Click(object sender, EventArgs e)
        {
            if (btnSizeEd.Tag.ToString() == "App")
            {
                ucLocalLicenseApp1.Size = new Size(668, 244);
                btnSizeEd.Tag = "Notes";
                btnSizeEd.Text = "App Details";
            }
            else
            {
                ucLocalLicenseApp1.Size = new Size(668, 578);
                btnSizeEd.Tag = "App";
                btnSizeEd.Text = "Add Notes";
            }
        }
        private void frmIssueLicense_Load(object sender, EventArgs e)
        {
            _LocalDLA = clsLocalLicenseApps.FindByLocalDLAppID(_LocalDLA_ID);

            if (_LocalDLA == null)
            {

                MessageBox.Show("No Applicaiton with ID=" + _LocalDLA_ID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if(!_LocalDLA.PassedAllTests())
            {
                MessageBox.Show("Person Should Pass All Tests First.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }


            int ExistingLicenseID = _LocalDLA.GetActiveLicenseID();
            if(ExistingLicenseID != -1)
            {
                MessageBox.Show("Person already has License before with License ID=" + ExistingLicenseID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ucLocalLicenseApp1.LoadApplicationInfoByLocalDrivingAppID(_LocalDLA_ID);

            // Get license class fees
            lblLicenseFees.Text = _LocalDLA.LicenseClassInfo.ClassFees.ToString() + " DA";

        }
        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            int LicenseID = _LocalDLA.IssueLicenseForFirstTime(txtNotes.Text, clsGlobalSettings.CurrentUser.UserID);

            if(LicenseID != -1)
            {
                MessageBox.Show("License Issued Successfully with License ID = " + LicenseID.ToString(),
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("License Was not Issued ! ",
                 "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
