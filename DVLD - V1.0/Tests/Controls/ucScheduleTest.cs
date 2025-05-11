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

namespace DVLD___V1._0.Tests
{
    public partial class ucScheduleTest : UserControl
    {
        public enum enMode { Add = 0 , Update = 1}
        public enum enCreationMode { FirstTimeSchedule = 0 , RetakeTestSchedule = 1}

        private enMode _Mode = enMode.Add;
        private enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;

        private clsTestAppointment _TestAppointment;
        private int _TestAppointmentID;

        private clsLocalLicenseApps _LocalDirvingLicenseApplication;
        private int _LocalDirvingLicenseApplicationID;

        private clsTestTypes.enTestType _TestType = clsTestTypes.enTestType.VisionTest;
        public clsTestTypes.enTestType TestType
        {
            get { return _TestType; }

            set { _TestType = value; }
        }


        public ucScheduleTest()
        {
            InitializeComponent();
        }

        private void _DetermineCreationMode()
        {
            // Decide Creation Mode if is retake test or for the first time
            if (_LocalDirvingLicenseApplication.DoesAttendTestType(TestType))
                _CreationMode = enCreationMode.RetakeTestSchedule;
            else
                _CreationMode = enCreationMode.FirstTimeSchedule;

            if(_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                pnlRetakeTest.Enabled = true;
                lblRetakeFees.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.RetakeTest).ApplicationFees.ToString();
            }
            else
            {
                lblRetakeFees.Text = "0";
                pnlRetakeTest.Enabled = false;
            }
        }
        private Boolean _HandleActiveTestAppointmentConstraint()
        {
            if(_LocalDirvingLicenseApplication.IsThereAnActiveScheduledTest(TestType))
            {
                MessageBox.Show("Person Already have an active appointment for this test" , "Attention");
                return true; ;
            }
            return false;
        }
        private Boolean _HandlePrviousTestConstraint()
        {
            switch (TestType)
            {
                case clsTestTypes.enTestType.WrittenTest:
                    {
                        if (!_LocalDirvingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.VisionTest))
                        {
                            MessageBox.Show("Cannot Schedule, Vision Test should be passed first", "Attention");
                            return false;
                        }
                        else
                            return true;
                    }
                case clsTestTypes.enTestType.StreetTest:
                    {
                        if(!_LocalDirvingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.WrittenTest))
                        {
                            MessageBox.Show("Cannot Schedule, Written Test should be passed first", "Attention");
                            return false;
                        }
                        else
                            return true;
                    }
                default:
                    return true;
            }
        }
        private Boolean _HandleAppointmentLockedConstraint()
        {
            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);

            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: No Appointment with ID = " + _TestAppointmentID.ToString(),
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }

            if (_TestAppointment.IsLocked)
                return false;
            else
                return true;

        }
        private void _LoadTestAppointmentInfo()
        {


            lblFees.Text = _TestAppointment.PaidFees.ToString();

            if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0)
                dtpDate.MinDate = DateTime.Now;
            else
                dtpDate.MinDate = _TestAppointment.AppointmentDate;

            dtpDate.Value = _TestAppointment.AppointmentDate;


            // RetakeTest Column
            if(_TestAppointment.RetakeTestApplicationID != -1)
            {
                lblRetakeAppID.Text = _TestAppointment.RetakeTestApplicationID.ToString();
            }

        }

        private void _CopyDataToApplicationObject(clsApplications Application)
        {
            Application.ApplicantPersonID = _LocalDirvingLicenseApplication.ApplicantPersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplications.enApplicationType.RetakeTest;
            Application.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationTypes.Find(Application.ApplicationTypeID).ApplicationFees;
            Application.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
        }
        private Boolean _HandleRetakeTest()
        {
            if(_CreationMode == enCreationMode.RetakeTestSchedule && _Mode == enMode.Add)
            {
                clsApplications Application = new clsApplications();

                _CopyDataToApplicationObject(Application);

                if (!Application.Save())
                {
                    _TestAppointment.RetakeTestApplicationID = -1;
                    MessageBox.Show("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _TestAppointment.RetakeTestApplicationID = Application.ApplicationID;
            }
            return true;
        }
        private void _CopyDataToTestAppointmentObject()
        {
            _TestAppointment.TestTypeID = (int)TestType;
            _TestAppointment.LicenseAppID = _LocalDirvingLicenseApplicationID;
            _TestAppointment.AppointmentDate = dtpDate.Value;
            _TestAppointment.PaidFees = Convert.ToSingle(lblFees.Text);
            _TestAppointment.CreatedByUser = clsGlobalSettings.CurrentUser.UserID;
            _TestAppointment.IsLocked = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!_HandleRetakeTest())
            {
                return;
            }
            _CopyDataToTestAppointmentObject();

            if (_TestAppointment.Save())
            {
                _Mode = enMode.Update;
                // Determine Opperation Type
                lblTestTitle.Text = "Update  \"" + _TestType + "\"  Appointment";

                if(pnlRetakeTest.Enabled)
                    lblRetakeAppID.Text = _TestAppointment.RetakeTestApplicationID.ToString();

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        public void LoadInfo(int LocalDLAppID, int testAppointmentID = -1)
        {
            //if no appointment id this means AddNew mode otherwise it's update mode.
            if (testAppointmentID == -1)
                _Mode = enMode.Add;
            else
                _Mode = enMode.Update;

            _LocalDirvingLicenseApplicationID = LocalDLAppID;
            _TestAppointmentID = testAppointmentID;

            // Get LocalDLApp Object
            _LocalDirvingLicenseApplication = clsLocalLicenseApps.FindByLocalDLAppID(LocalDLAppID);

            if (_LocalDirvingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDirvingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //btnSave.Enabled = false;
                return;
            }

            _DetermineCreationMode();

            // Get General info from LocalDLA
            lblLocalDLAppID.Text = _LocalDirvingLicenseApplicationID.ToString();
            lblApplicant.Text = _LocalDirvingLicenseApplication.ApplicantFullName;
            lblLicenseClass.Text = _LocalDirvingLicenseApplication.LicenseClassInfo.ClassName;
            lblTrail.Text = _LocalDirvingLicenseApplication.TotalTrialsPerTest(TestType).ToString();


            if (_Mode == enMode.Add)
            {

                // Determine Opperation Type
                lblTestTitle.Text = "New  \"" + _TestType + "\"  Appointment";

                // Check if there is no an active appointment (not locked)
                if (_HandleActiveTestAppointmentConstraint())
                    return;

                // Check if the previous test was done
                if (!_HandlePrviousTestConstraint())
                    return;

                // Get the rest info
                lblFees.Text = clsTestTypes.Find((int)TestType).TestTypeFees.ToString();
                dtpDate.MinDate = DateTime.Now;

                // Prepare Object For New Record
                _TestAppointment = new clsTestAppointment();
            }
            else
            {
                // Determine Opperation Type
                lblTestTitle.Text = "Update  \"" + _TestType + "\"  Appointment";


             
                // Check if the appointment is Not Locked
                if (!_HandleAppointmentLockedConstraint())
                    return;
                else
                {
                    // Get the rest info for unlocked existing appointment
                    _LoadTestAppointmentInfo();
                }
            }

            // Set Total Fees
            lblTotalFees.Text = lblTotalFees.Text = (Convert.ToSingle(lblFees.Text) + Convert.ToSingle(lblRetakeFees.Text)).ToString();

            btnSave.Enabled = true;
        }
    }
}
