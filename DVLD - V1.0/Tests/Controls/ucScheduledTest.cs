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

namespace DVLD___V1._0.Tests.Controls
{
    public partial class ucScheduledTest : UserControl
    {

        private int _TestAppointmentID = -1;
        private clsTestAppointment _TestAppointment;
        public int TestAppointmentID
        {
            get { return _TestAppointmentID; }
        }

        private int _LocalDLA_ID = -1;
        private clsLocalLicenseApps _LocalDLA;

        private int _TestID = -1;
        public int TestID
        {
            get { return _TestID; }
        }
        public string TestIDLabel
        {
            get { return lblTestID.Text; }
            set { lblTestID.Text = value; } 
        }

        private clsTestTypes.enTestType _TestType;
        public clsTestTypes.enTestType TestType
        {
            get { return _TestType; }

            set
            {
                _TestType = value;

                switch (_TestType) 
                {
                    case clsTestTypes.enTestType.VisionTest:
                        {
                            lblTitle.Text = "Vision Test";
                            break;
                        }
                    case clsTestTypes.enTestType.WrittenTest:
                        {
                            lblTitle.Text = "Written Test";
                            break;
                        }
                    default:
                        {
                            lblTitle.Text = "Street Test";
                            break;
                        }
                }
            
            }
        }

        private void _SetControlValues()
        {
            lblLicenseAppID.Text = _LocalDLA_ID.ToString();
            lblApplicant.Text = _LocalDLA.ApplicantFullName;
            lblLicenseType.Text = _LocalDLA.LicenseClassInfo.ClassName;
            lblPaidFees.Text = _TestAppointment.PaidFees.ToString();
            lblDate.Text = _TestAppointment.AppointmentDate.ToString();
            lblTestID.Text = _TestAppointment.TestID.ToString();
            lblTrail.Text = _LocalDLA.TotalTrialsPerTest((clsTestTypes.enTestType)_TestAppointment.TestTypeID).ToString();
        }

        public void LoadInfo(int testAppointmentID)
        {

            // Handle TestAppointment
            _TestAppointmentID = testAppointmentID;
            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);
            if(_TestAppointment == null)
            {
                MessageBox.Show("Error: No  Appointment ID = " + _TestAppointmentID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _TestAppointmentID = -1;
                return;
            }



            // Handle LocalDLA
            _LocalDLA_ID = _TestAppointment.LicenseAppID;
            _LocalDLA = clsLocalLicenseApps.FindByLocalDLAppID(_LocalDLA_ID);
            if (_LocalDLA == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDLA_ID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Fill the rest of the ucScheduledTest private members
            _TestID = _TestAppointment.TestID;
            _TestType = (clsTestTypes.enTestType) _TestAppointment.TestTypeID;
            
            // Fill controls with data
            _SetControlValues();
        }

        public ucScheduledTest()
        {
            InitializeComponent();
        }
    }
}
