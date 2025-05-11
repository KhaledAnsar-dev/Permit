using DVLD___V1._0.TestAppointment;
using DVLD_Business;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD___V1._0.LocalLicenses
{
    public partial class frmScLocalLicenseApps : Form
    {
        private DataTable _dtAllLocalDrivingLicensesApps;
        public frmScLocalLicenseApps()
        {
            InitializeComponent();
        }

        string _FilterColumn;

        private void _ApplyFilter()
        {

            // Handle Filter based on status "New" or "Canceled" or "Completed
            if (!txtFilter.Enabled)
            {
                if (cbFilterType.Text == "New")
                {
                    _dtAllLocalDrivingLicensesApps.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", _FilterColumn, "New");
                    return;
                }
                else if (cbFilterType.Text == "Canceled")
                {
                    _dtAllLocalDrivingLicensesApps.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", _FilterColumn, "Canceled");
                    return;
                }
                else
                {
                    _dtAllLocalDrivingLicensesApps.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", _FilterColumn, "Completed");
                    return;
                }
            }

            if (string.IsNullOrEmpty(txtFilter.Text) || cbFilterType.Text == "None")
            {
                _dtAllLocalDrivingLicensesApps.DefaultView.RowFilter = "";
                return;
            }

            if(_FilterColumn == "LocalLicID")
            {
                _dtAllLocalDrivingLicensesApps.DefaultView.RowFilter = string.Format("[{0}] = {1}", _FilterColumn, txtFilter.Text);
                return;
            }
            else
            {
                _dtAllLocalDrivingLicensesApps.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", _FilterColumn, txtFilter.Text);
                return;
            }
        }
        private void _ChooseFilter()
        {
            switch (cbFilterType.SelectedItem.ToString())
            {
                case "Local License ID":
                    {
                        _FilterColumn = "LocalLicID";
                        break;
                    }
                case "NO":
                    {
                        _FilterColumn = "NO";
                        break;
                    }
                case "FullName":
                    {
                        _FilterColumn = "Full Name";
                        break;
                    }
                case "New":
                    {
                        _FilterColumn = "Status";
                        break;
                    }
                case "Canceled":
                    {
                        _FilterColumn = "Status";
                        break;
                    }
                case "Completed":
                    {
                        _FilterColumn = "Status";
                        break;
                    }
                default:
                    {
                        _FilterColumn = "None";
                        break;
                    }
            }
        }
        private bool _RowSelected()
        {
            if (dgvLocalLicenseAppsTable.Rows.Count == 0)
                return false;

            if (dgvLocalLicenseAppsTable.CurrentRow.Selected == false)
            {
                MessageBox.Show("Please select a License");
                return false;
            }
            else
                return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmReLocalLicenseApps localLicenseApps = new frmReLocalLicenseApps();
            localLicenseApps.ShowDialog();
            frmScLocalLicenseApps_Load(null, null);
        }

        private void cbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ChooseFilter();
            txtFilter.Text = "";

            if (_FilterColumn == "Status")
            {
                txtFilter.Enabled = false;
                _ApplyFilter();
            }
            else
            {
                txtFilter.Enabled = true;
            }
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }
        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_FilterColumn == "LocalLicID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void frmScLocalLicenseApps_Load(object sender, EventArgs e)
        {
            _dtAllLocalDrivingLicensesApps = clsLocalLicenseApps.GetAllLocalLicenseApps();
            dgvLocalLicenseAppsTable.DataSource = _dtAllLocalDrivingLicensesApps;

            if (dgvLocalLicenseAppsTable.Rows.Count > 0)
            {
                dgvLocalLicenseAppsTable.Columns[0].HeaderText = "L.D.L.AppID";
                dgvLocalLicenseAppsTable.Columns[1].HeaderText = "Driving Class";
                dgvLocalLicenseAppsTable.Columns[2].HeaderText = "National No";
                dgvLocalLicenseAppsTable.Columns[3].HeaderText = "Full Name";
                dgvLocalLicenseAppsTable.Columns[4].HeaderText = "Application Date";
                dgvLocalLicenseAppsTable.Columns[5].HeaderText = "Passed Tests";
            }
            cbFilterType.SelectedIndex = 0;
        }

        private void cmsLicenseTests_Opening(object sender, CancelEventArgs e)
        {
            if (!_RowSelected())
                return;

            int LocalLicenseAppID = (int)dgvLocalLicenseAppsTable.CurrentRow.Cells[0].Value;

            clsLocalLicenseApps LocalLicenseApp = clsLocalLicenseApps.FindByLocalDLAppID(LocalLicenseAppID);

            if(LocalLicenseApp != null)
            {
                short TotalPassedTests = Convert.ToInt16(dgvLocalLicenseAppsTable.CurrentRow.Cells[5].Value);
                bool LicenseExist = LocalLicenseApp.IsLicenseIssued();
                bool PassedVisionTest = LocalLicenseApp.DoesPassTestType(clsTestTypes.enTestType.VisionTest);
                bool PassedWrittenTest = LocalLicenseApp.DoesPassTestType(clsTestTypes.enTestType.WrittenTest); 
                bool PassedStreetTest = LocalLicenseApp.DoesPassTestType(clsTestTypes.enTestType.StreetTest); 

                //Enable/Disable "Show License" button
                btnShowLicense.Enabled = LicenseExist;

                //Enable/Disable "Issue License" button
                btnIssueLicense.Enabled = TotalPassedTests == 3 && !LicenseExist;

                //Enable/Disable "Tests" button
                btnTests.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) && (LocalLicenseApp.ApplicationStatus == clsApplications.enApplicationStatus.New);

                if(btnTests.Enabled)
                {
                    //Enable/Disable "Vision Test" button
                    btnViewTest.Enabled = !PassedVisionTest;

                    //Enable/Disable "Writen Test" button
                    btnWrittenTest.Enabled = PassedVisionTest && !PassedWrittenTest;

                    //Enable/Disable "street Test" button
                    btnStreetTest.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;
                }        
              
                //Enable/Disable "Person License History" button
                btnPersonLicensesHistory.Enabled = LicenseExist;

                //Enable/Disable "Edit" button
                editToolStripMenuItem.Enabled = !LicenseExist && (LocalLicenseApp.ApplicationStatus == clsApplications.enApplicationStatus.New);
                
                //Enable/Disable "Cancel" button
                //We only cancel the applications with status=new.
                cancelToolStripMenuItem.Enabled = (LocalLicenseApp.ApplicationStatus == clsApplications.enApplicationStatus.New);
               
                //Enable/Disable "Delete" button
                //We only allow delete incase the application status is new not complete or Cancelled.
                deleteToolStripMenuItem.Enabled = (LocalLicenseApp.ApplicationStatus == clsApplications.enApplicationStatus.New); ;
            }
        }
      
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_RowSelected())
            {
                int LocalDrivingLicenseApplicationID = (int)dgvLocalLicenseAppsTable.CurrentRow.Cells[0].Value;

                frmReLocalLicenseApps frm =
                             new frmReLocalLicenseApps(LocalDrivingLicenseApplicationID);
                frm.ShowDialog();

                frmScLocalLicenseApps_Load(null, null);
            }
        }
        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_RowSelected())
            {

                if (MessageBox.Show("Are you sure do want to cancel this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                int LocalLicenseAppID = (int)dgvLocalLicenseAppsTable.CurrentRow.Cells[0].Value;
                clsLocalLicenseApps LocalLicenseApp = clsLocalLicenseApps.FindByLocalDLAppID(LocalLicenseAppID);

                if (LocalLicenseApp != null)
                {
                    if (LocalLicenseApp.Cancel())
                    {
                        MessageBox.Show("Local License App Canceled Successfully.");
                        frmScLocalLicenseApps_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Could not cancel application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_RowSelected())
            {

                if (MessageBox.Show("Are you sure do want to delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                int LocalLicenseAppID = (int)dgvLocalLicenseAppsTable.CurrentRow.Cells[0].Value;
                clsLocalLicenseApps LocalLicenseApp = clsLocalLicenseApps.FindByLocalDLAppID(LocalLicenseAppID);

                if (LocalLicenseApp != null)
                {
                    if (LocalLicenseApp.DeleteLocalLicenseApp())
                    {
                        MessageBox.Show("Local License App Deleted Successfully.");
                        frmScLocalLicenseApps_Load(null, null);
                    }
                    else
                        MessageBox.Show("Could not delete applicatoin, other data depends on it.");

                }

            }
        }
        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_RowSelected())
            {
                int LocalLicenseAppID = (int)dgvLocalLicenseAppsTable.CurrentRow.Cells[0].Value;

                frmLocalLicenseAppDetails LocalLicApp = new frmLocalLicenseAppDetails(LocalLicenseAppID);
                LocalLicApp.ShowDialog();
                frmScLocalLicenseApps_Load(null, null);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem TestButton = (ToolStripMenuItem)sender;

            int TestTypeID = Convert.ToInt32(TestButton.Tag);
            int LocalLicenseAppID = (int)dgvLocalLicenseAppsTable.CurrentRow.Cells[0].Value;

            frmScTestAppointments TA = new frmScTestAppointments(LocalLicenseAppID, (clsTestTypes.enTestType)TestTypeID);
            TA.ShowDialog();

            frmScLocalLicenseApps_Load(null, null);


        }
        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            if (_RowSelected())
            {
                int LocalLicenseAppID = (int)dgvLocalLicenseAppsTable.CurrentRow.Cells[0].Value;
                frmIssueLicense Issue = new frmIssueLicense(LocalLicenseAppID);
                Issue.ShowDialog();
                frmScLocalLicenseApps_Load(null, null);
            }

        }
        private void btnShowLicense_Click(object sender, EventArgs e)
        {
            if (_RowSelected())
            {
                int LocalDLA_ID = (int)dgvLocalLicenseAppsTable.CurrentRow.Cells[0].Value;


                int LocalLicenseID = clsLocalLicenseApps.FindByLocalDLAppID(LocalDLA_ID).GetActiveLicenseID();

                frmDriverLicense DriverLicense = new frmDriverLicense(LocalLicenseID);
                DriverLicense.ShowDialog();
            }
        }
        private void btnPersonLicensesHistory_Click(object sender, EventArgs e)
        {
            if (_RowSelected())
            {
                int LocalLicenseAppID = (int)dgvLocalLicenseAppsTable.CurrentRow.Cells[0].Value;

                int ApplicationID = clsLocalLicenseApps.FindByLocalDLAppID(LocalLicenseAppID).ApplicationID;


                int PersonID = clsApplications.FindBaseApplication(ApplicationID).ApplicantPersonID;


                frmLicensesHistory LicensesHistory = new frmLicensesHistory(PersonID);
                LicensesHistory.ShowDialog();
            }
        }

    }
}