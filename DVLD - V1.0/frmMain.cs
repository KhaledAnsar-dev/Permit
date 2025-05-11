using DVLD___V1._0.AppTypes;
using DVLD___V1._0.DetainLicense;
using DVLD___V1._0.Drivers;
using DVLD___V1._0.InternationalLicenses;
using DVLD___V1._0.LocalLicenses;
using DVLD___V1._0.RenewLicense;
using DVLD___V1._0.ReplaceLicense;
using DVLD___V1._0.TestTypes;
using DVLD___V1._0.Users;
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

namespace DVLD___V1._0
{
    public partial class frmMain : Form
    {
        public frmMain(frmLoginScreen LoginScreen)
        {
            InitializeComponent();
            _LoginScreen = LoginScreen;
        }

        private frmLoginScreen _LoginScreen;
        // Create Dynamic Side Bar Menu
        // Handlle New Licenses Section
        private bool ApplicationsIsCollapsed = false;
        private bool NewLicenseIsCollapsed = true;
        private bool LicenseServicesIsCollapsed = true;
        private bool ManageAppIsCollapsed = true;
        private bool DetainedLicenseIsCollapsed = true;

        private void TimerTick(Panel panel , Timer timer , ref bool IsCollapsed)
        {
            if (IsCollapsed)
            {
                panel.Height += 10;

                if (panel.Size == panel.MaximumSize)
                {
                    IsCollapsed = false;
                    timer.Stop();
                }
            }
            else
            {
                panel.Height -= 10;

                if (panel.Size == panel.MinimumSize)
                {
                    IsCollapsed = true;
                    timer.Stop();
                }
            }
        }


        private void btnNewLicenses_Click(object sender, EventArgs e)
        {
            tmNewDrivingLicense.Start();
        }
        private void tmNewDrivingLicense_Tick(object sender, EventArgs e)
        {
            TimerTick(pnNewLicenses, tmNewDrivingLicense, ref NewLicenseIsCollapsed);
        }

        private void btnLicensesServices_Click(object sender, EventArgs e)
        {
            tmLicensesServices.Start();
        }
        private void tmLicensesServices_Tick(object sender, EventArgs e)
        {
            TimerTick(pnLicenseServices, tmLicensesServices, ref LicenseServicesIsCollapsed);
        }

        private void btnManageApplications_Click(object sender, EventArgs e)
        {
            tmManageApplications.Start();
        }
        private void tmManageApplications_Tick(object sender, EventArgs e)
        {
            TimerTick(pnMangeApplications, tmManageApplications, ref ManageAppIsCollapsed);
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            tmDetainedLicenses.Start();
        }
        private void tmDetainedLicenses_Tick(object sender, EventArgs e)
        {
            TimerTick(pnDetainedLicenses, tmDetainedLicenses, ref DetainedLicenseIsCollapsed);
        }

        private void btnApplications_Click(object sender, EventArgs e)
        {
            tmApplications.Start();
        }
        private void tmApplications_Tick(object sender, EventArgs e)
        {
            TimerTick(pnApplications, tmApplications, ref ApplicationsIsCollapsed);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //pnApplications.Size = pnApplications.MinimumSize;
            pnMangeApplications.Size = pnMangeApplications.MinimumSize;
            pnDetainedLicenses.Size = pnDetainedLicenses.MinimumSize;
            pnLicenseServices.Size = pnLicenseServices.MinimumSize;
            pnNewLicenses.Size = pnNewLicenses.MinimumSize;


            btnCurrentUser.Text = clsUser.GetUserFullName(clsGlobalSettings.CurrentUser.UserID);

        }


        // Perform Main Menu
        private void btnPeople_Click(object sender, EventArgs e)
        {
            frmScPeople People = new frmScPeople();
            People.ShowDialog();
        }
        private void btnUsers_Click(object sender, EventArgs e)
        {
            frmScUsers US = new frmScUsers();
            US.ShowDialog();
        }
        private void btnDrivers_Click(object sender, EventArgs e)
        {
            frmScDrivers Drivers = new frmScDrivers();
            Drivers.ShowDialog();
        }
        private void btnApplicationTypes_Click(object sender, EventArgs e)
        {
            frmScAppTypes scAppTypes = new frmScAppTypes();
            scAppTypes.ShowDialog();
        }
        private void btnTestTypes_Click(object sender, EventArgs e)
        {
            frmScTestTypes TestTypes = new frmScTestTypes();
            TestTypes.ShowDialog();
        }
        private void btnCurrentUser_Click(object sender, EventArgs e)
        {
            frmShowUserDetails SUD = new frmShowUserDetails(clsGlobalSettings.CurrentUser.UserID);
            SUD.ShowDialog();
        }
        private void btnEditPassword_Click(object sender, EventArgs e)
        {
            frmEditPassword EP = new frmEditPassword(clsGlobalSettings.CurrentUser.UserID);
            EP.ShowDialog();
        }
        private void btnLocalLicenceAppManage_Click(object sender, EventArgs e)
        {
            frmScLocalLicenseApps localLicenseApps = new frmScLocalLicenseApps();
            localLicenseApps.ShowDialog();
        }
        private void btnManageInternationalLicenses_Click(object sender, EventArgs e)
        {
            frmScInternationalLicenses internationalLicensesScreen = new frmScInternationalLicenses();
            internationalLicensesScreen.ShowDialog();
        }
        private void btnLocalLicenseService_Click(object sender, EventArgs e)
        {
            frmReLocalLicenseApps localLicenseApps = new frmReLocalLicenseApps();
            localLicenseApps.ShowDialog();
        }
        private void btnInterLicenseService_Click(object sender, EventArgs e)
        {
            frmReInternationLicenses InterLicense = new frmReInternationLicenses(); ;
            InterLicense.ShowDialog();
        }
        private void btnRenewLicense_Click(object sender, EventArgs e)
        {
            frmRenewLicense ReRenewLicense = new frmRenewLicense();
            ReRenewLicense.ShowDialog();
        }
        private void btnReplaceLicense_Click(object sender, EventArgs e)
        {
            frmReplaceLicense ReplaceLicense = new frmReplaceLicense();
            ReplaceLicense.ShowDialog();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense DetainLicense = new frmDetainLicense();
            DetainLicense.ShowDialog();  
        }
        private void btnReleasedLicense_Click(object sender, EventArgs e)
        {
            frmReleaseLicense ReleaseLicense = new frmReleaseLicense();
            ReleaseLicense.ShowDialog();
        }
        private void btnManageDetain_Click(object sender, EventArgs e)
        {
            frmScDetainManagement DetainMangement = new frmScDetainManagement();
            DetainMangement.ShowDialog();
        }
        private void btnReleaseDetained_Click(object sender, EventArgs e)
        {
            frmReleaseLicense ReleaseLicense = new frmReleaseLicense();
            ReleaseLicense.ShowDialog();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _LoginScreen.Show();
            clsGlobalSettings.CurrentUser = null;
        }

    }
}
