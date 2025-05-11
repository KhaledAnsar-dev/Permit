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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD___V1._0.Users
{
    public partial class frmScUsers : Form
    {

        private static DataTable _dtAllUsers;


        private string _FilterColumn = "";
        public frmScUsers()
        {
            InitializeComponent();
        }
      
        private void _ApplyFilter()
        {

            // Handle Filter based on status "Active" or "Not Active
            if (txtFilter.Enabled == false && cbFilterType.Text == "Active")
            {
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", _FilterColumn, 1);
                return;
            }
            else
            {
                if (txtFilter.Enabled == false)
                {
                    _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", _FilterColumn, 0);
                    return;
                }                
            }

           

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilter.Text.Trim() == "" || _FilterColumn == "None")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                return;
            }

            
            if (_FilterColumn == "UserID" || _FilterColumn == "PersonID")
            {
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", _FilterColumn, txtFilter.Text.Trim());
                return;
            }

            if(_FilterColumn == "FullName" || _FilterColumn == "UserName")
            {
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", _FilterColumn, txtFilter.Text.Trim());
                return;
            }



        }
        private void _ChooseFilter()
        {
           switch (cbFilterType.Text)
            {
                case "UserName":
                    {
                        _FilterColumn = "UserName";
                        break;
                    }
                case "FullName":
                    {
                        _FilterColumn = "FullName";
                        break;
                    }
                case "UserID":
                    {
                        _FilterColumn = "UserID";
                        break;
                    }
                case "PersonID":
                    {
                        _FilterColumn = "PersonID";
                        break;
                    }
                case "Active":
                    {
                        _FilterColumn = "IsActive";
                        break;
                    }
                case "NotActive":
                    {
                        _FilterColumn = "IsActive";
                        break;
                    }
                default :
                    {
                        _FilterColumn = "None";
                        break;
                    }
            }
        }

        private void frmUsersScreen_Load(object sender, EventArgs e)
        {
            _dtAllUsers = clsUser.GetAllUsers();
            dgvUsersTable.DataSource = _dtAllUsers;
            cbFilterType.SelectedIndex = 0;

            if(dgvUsersTable.Rows.Count > 0)
            {
                dgvUsersTable.Columns[0].HeaderText = "User ID";
                dgvUsersTable.Columns[1].HeaderText = "Person ID";
                dgvUsersTable.Columns[2].HeaderText = "Full Name";
                dgvUsersTable.Columns[3].HeaderText = "UserName";
                dgvUsersTable.Columns[4].HeaderText = "Is Active";

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmReUser RecordEditor = new frmReUser();
            RecordEditor.ShowDialog();
            frmUsersScreen_Load(null, null);
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsersTable.CurrentRow.Selected == false)
            {
                MessageBox.Show("Please select User");
                return;
            }
            frmReUser RecordEditor = new frmReUser((int)dgvUsersTable.CurrentRow.Cells[0].Value);
            RecordEditor.ShowDialog();
            frmUsersScreen_Load(null, null);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete User [" + dgvUsersTable.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (clsUser.DeleteUser((int)dgvUsersTable.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Successfully.");
                    frmUsersScreen_Load(null, null);
                }

                else
                    MessageBox.Show("User is not deleted.");

            }
        }
        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (dgvUsersTable.CurrentRow.Selected == false)
            {
                MessageBox.Show("Please select User");
                return;
            }

            frmShowUserDetails frmUserDetails = new frmShowUserDetails((int)dgvUsersTable.CurrentRow.Cells[0].Value);
            frmUserDetails.ShowDialog();

        }
        private void btnEditPassword_Click(object sender, EventArgs e)
        {
            if (dgvUsersTable.CurrentRow.Selected == false)
            {
                MessageBox.Show("Please select User");
                return;
            }

            frmEditPassword EP = new frmEditPassword((int)dgvUsersTable.CurrentRow.Cells[0].Value);
            EP.ShowDialog();
        }

        private void cbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ChooseFilter();
            txtFilter.Text = "";

            if (_FilterColumn == "IsActive")
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
            if (_FilterColumn == "PersonID" || _FilterColumn == "UserID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

    }
}
