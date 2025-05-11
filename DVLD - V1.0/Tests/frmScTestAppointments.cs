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

namespace DVLD___V1._0.TestAppointment
{
    public partial class frmScTestAppointments : Form
    {

        private DataTable _dtAllTestAppointmentPerTestType;
        private int _LocalDLA_ID;
        private clsTestTypes.enTestType _TestTypeID;

        public frmScTestAppointments(int LocalDLA_ID, clsTestTypes.enTestType TestTypeID)
        {
            InitializeComponent();
            _LocalDLA_ID = LocalDLA_ID;
            _TestTypeID = TestTypeID;
        }
        
        private void btnSizeEd_Click(object sender, EventArgs e)
        {
            if (btnSizeEd.Tag.ToString() == "less")
            {
                ucLocalLicenseApp1.Size = new Size(668, 567);
                btnSizeEd.Tag = "more";
                btnSizeEd.Text = "Less Details";
            }
            else
            {
                ucLocalLicenseApp1.Size = new Size(668, 238);
                btnSizeEd.Tag = "less";
                btnSizeEd.Text = "More Details";
            }
        }
        private void frmScTestAppointments_Load(object sender, EventArgs e)
        {
            ucLocalLicenseApp1.LoadApplicationInfoByLocalDrivingAppID(_LocalDLA_ID);
            _dtAllTestAppointmentPerTestType =clsTestAppointment.GetApplicationTestAppointmentsPerTestType(_LocalDLA_ID,_TestTypeID);
            dgvAppointmentsTable.DataSource = _dtAllTestAppointmentPerTestType;

            if(dgvAppointmentsTable.Rows.Count > 0)
            {
                dgvAppointmentsTable.Columns[0].HeaderText = "Appointment ID";

                dgvAppointmentsTable.Columns[1].HeaderText = "Appointment Date";

                dgvAppointmentsTable.Columns[2].HeaderText = "Paid Fees";

                dgvAppointmentsTable.Columns[3].HeaderText = "Is Locked";
            }
        }

       
        private bool _RowSelected()
        {
           if(dgvAppointmentsTable.Rows.Count == 0)
                return false;

            if (dgvAppointmentsTable.CurrentRow.Selected == false)
            {
                MessageBox.Show("Please select An appointment");
                return false;
            }
            else
                return true;
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            clsLocalLicenseApps LocalDLA = clsLocalLicenseApps.FindByLocalDLAppID(_LocalDLA_ID);


            // Check if there is no active appointment
            if(clsLocalLicenseApps.IsThereAnActiveScheduledTest(_LocalDLA_ID, _TestTypeID))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if there is no prior appointment or if the previous appointment failed
            clsTest LastTest = LocalDLA.GetLastTestPerTestType(_TestTypeID);

            if(LastTest == null || LastTest.TestResult == false)
            {
                frmScheduleTest ScheduleTest = new frmScheduleTest(_LocalDLA_ID, _TestTypeID);
                ScheduleTest.ShowDialog();
                frmScTestAppointments_Load(null, null);
            }
            else
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(_RowSelected())
            {
                int TestAppointmentID = Convert.ToInt32(dgvAppointmentsTable.CurrentRow.Cells[0].Value);

                frmScheduleTest ScheduleTest = new frmScheduleTest(_LocalDLA_ID, _TestTypeID ,TestAppointmentID);
                ScheduleTest.ShowDialog();
                frmScTestAppointments_Load(null, null);

            }
        }
        private void btnTakeTest_Click(object sender, EventArgs e)
        {
            if (_RowSelected())
            {
                int TestAppointmentID = Convert.ToInt32(dgvAppointmentsTable.CurrentRow.Cells[0].Value);

                bool DoesAppointmentLocked = clsTestAppointment.Find(TestAppointmentID).IsLocked;

                if (DoesAppointmentLocked)
                {
                    MessageBox.Show("Error: This Appointment ID = " + TestAppointmentID.ToString() + " Is Taken",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                frmTakeTest TakeTest = new frmTakeTest(TestAppointmentID, _TestTypeID);
                TakeTest.ShowDialog();
                frmScTestAppointments_Load(null, null);
            }
        }
    }
}
