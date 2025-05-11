using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD___V1._0.TestAppointment
{
    public partial class frmTakeTest : Form
    {
        public frmTakeTest(int TestAppointmentID , clsTestTypes.enTestType TestTypeID)
        {
            InitializeComponent();

            _TestAppointmentID = TestAppointmentID;
            _TestTypeID = TestTypeID;

        }

        private int _TestAppointmentID;
        private clsTestTypes.enTestType _TestTypeID;

        private int _TestID;
        private clsTest _Test;


        private void _GetExistingTestResult()
        {
            _Test = clsTest.Find(_TestID);

            if (_Test.TestResult)
                rbPass.Checked = true;
            else
                rbFail.Checked = true;

            txtNote.Text = _Test.Notes;

            // Cannot edit the status of a taken exam
            rbFail.Enabled = false;
            rbPass.Enabled = false;
        }
        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            // Load Data in UserControl
            ucScheduledTest1.TestType = _TestTypeID;
            ucScheduledTest1.LoadInfo(_TestAppointmentID);

          

            // Check if the test has already been taken
            if (ucScheduledTest1.TestID != -1)
            {
                _TestID = ucScheduledTest1.TestID;
                _GetExistingTestResult();
            }
            else
            {
                _Test = new clsTest();
            }
            if (ucScheduledTest1.TestAppointmentID == -1)
                return;

            btnSave.Enabled = true;

        }

        private void _CopyDataToTestObject()
        {
            _Test.TestAppointmentID = _TestAppointmentID;

            if (rbPass.Checked)
                _Test.TestResult = true;
            else
                _Test.TestResult = false;

            _Test.Notes = txtNote.Text;
            _Test.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
                  "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No
         )
            {
                return;
            }

            _CopyDataToTestObject();

            if(_Test.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ucScheduledTest1.TestIDLabel = _Test.TestID.ToString();
                this.Close();
                btnSave.Enabled = false;

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
