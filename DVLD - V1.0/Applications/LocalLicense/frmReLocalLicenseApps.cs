using DVLD___V1._0.GlobalClasses;
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
using static DVLD___V1._0.frmRePeople;

namespace DVLD___V1._0.LocalLicenses
{
    public partial class frmReLocalLicenseApps : Form
    {
        public frmReLocalLicenseApps()
        {
            InitializeComponent();
            Mode = enMode.Add;            
        }

        public frmReLocalLicenseApps(int LLicAppID)
        {
            InitializeComponent();

            Mode = enMode.Update;

            // Get Local License Driving App ID
            this.LLicenseAppID = LLicAppID;            
        }
        enum enMode { Add, Update };
        enMode Mode = new enMode();

        int LLicenseAppID;
        clsLocalLicenseApps LocalLicenseApp;
        private int _SelectedPersonID = -1;

        private void _LoadLicensesClasses()
        {
            DataTable Classes = clsLicenseClasses.GetAllClasses();

            foreach (DataRow Row in Classes.Rows)
            {
                cbLicenseClasses.Items.Add(Row["ClassName"]).ToString();
            }
        }
        private void _SetUserAndDate()
        {
            txtUserID.Text = clsGlobalSettings.CurrentUser.UserID.ToString();
            lblAppDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        private void _CopyDataToLocalLicenseAppObject()
        {
            LocalLicenseApp.ApplicantPersonID = _SelectedPersonID;
            LocalLicenseApp.ApplicationDate = DateTime.Now;
            LocalLicenseApp.ApplicationStatus = clsApplications.enApplicationStatus.New;
            LocalLicenseApp.ApplicationTypeID = (int)clsApplications.enApplicationType.NewDrivingLicense;
            LocalLicenseApp.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
            LocalLicenseApp.LastStatusDate = DateTime.Now;
            LocalLicenseApp.PaidFees = clsApplicationTypes.Find((int)clsApplications.enApplicationType.NewDrivingLicense).ApplicationFees;
            LocalLicenseApp.LicenseClassID = clsLicenseClasses.Find(cbLicenseClasses.Text).LicenseClassID;
        }
        private void _LockPersonEdit()
        {
            ucPersonDetailsWithFilter1.FilterEnabled = false;
            btnNext.Enabled = true;
        }
        private void _LoadData()
        {
            LocalLicenseApp = clsLocalLicenseApps.FindByLocalDLAppID(LLicenseAppID);

            if (LocalLicenseApp != null)
            {
                // User Shouldn't change the person
                _LockPersonEdit();

                // Load person info in card details
                ucPersonDetailsWithFilter1.LoadPersonInfo(LocalLicenseApp.ApplicantPersonID);

                // Get Application data
                txtUserID.Text = LocalLicenseApp.CreatedByUserID.ToString();
                txtDLAppID.Text = LLicenseAppID.ToString();
                lblAppDate.Text = clsFormat.DateToShort(LocalLicenseApp.ApplicationDate);
                lblAppFees.Text = LocalLicenseApp.PaidFees.ToString() + " DA";

                // Get License Claas Name
                cbLicenseClasses.SelectedText = LocalLicenseApp.LicenseClassInfo.ClassName;
            }
            else
            {
                MessageBox.Show("No Application with ID = " + LLicenseAppID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }
        }
        private void _ResetDefaultValues()
        {
            _LoadLicensesClasses();

            lblAppFees.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.NewDrivingLicense).ApplicationFees.ToString();
            
            if (Mode == enMode.Add)
            {
                lblLicenseApp1.Text = "Add Local License App";
                lblLicenseApp2.Text = "Add Local License App";
                cbLicenseClasses.Text = "Class 3 - Ordinary driving license";

                _SetUserAndDate();

                LocalLicenseApp = new clsLocalLicenseApps();
                return;
            }
            else
            {
                lblLicenseApp1.Text = "Edit Local License App";
                lblLicenseApp2.Text = "Edit Local License App";
            }


        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedTab = tpLoginInfo;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedTab = tpFindPerson;
        }
        private void ucPersonDetailsWithFilter1_OnPersonSelected(int PersonID)
        {
            if (PersonID != -1)
            {
                _SelectedPersonID = PersonID;
                btnNext.Enabled = true;
            }
            else
                btnNext.Enabled = false;
        }

        private void frmReLocalLicenseApps_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (Mode == enMode.Update)
                _LoadData();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            int ClassLicenseID = clsLicenseClasses.Find(cbLicenseClasses.Text).LicenseClassID;

            _CopyDataToLocalLicenseAppObject();

            int ActiveApplicationID = clsApplications.GetActiveApplicationIDForLicenseClass(_SelectedPersonID, clsApplications.enApplicationType.NewDrivingLicense, ClassLicenseID);


            // Check if user have already an application for this license class
            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClasses.Focus();
                return;
            }

            //check if user already have issued license of the same driving  class.
            if (clsLicense.IsLicenseExistByPersonID(ucPersonDetailsWithFilter1.PersonID, ClassLicenseID))
            {

                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (LocalLicenseApp.Save())
            {
                Mode = enMode.Update;
                lblLicenseApp1.Text = "Edit Local License App";
                lblLicenseApp2.Text = "Edit Local License App";
                txtDLAppID.Text = LocalLicenseApp.LocalDrivingLicenseApplicationID.ToString();

                MessageBox.Show("Data saved successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("Eror : Data is not saved Data successfully");
                this.Close();
                return;
            }

  
        }
    }
}
