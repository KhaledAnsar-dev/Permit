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

namespace DVLD___V1._0
{
    public partial class frmScPeople : Form
    {

        private static DataTable _dtAllPeople = clsPerson.GetAllPeople();

        // Select only columns that we need in this new DataTable
        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "LastName",
                                                       "GendorCaption", "DateOfBirth", "CountryName",
                                                       "Phone");

        private string _FilterColumn = "";

        public frmScPeople()
        {
            InitializeComponent();
        }

        private void _RefreshTable()
        {
            _dtAllPeople = clsPerson.GetAllPeople();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "LastName",
                                                       "GendorCaption", "DateOfBirth", "CountryName",
                                                       "Phone");

            dgvPeopleTable.DataSource = _dtPeople;
        }
        private void _ChooseFilter()
        {
            //Map Selected Filter to real Column name 

            switch (cbFilterType.Text)
            {
                case "First Name":
                    {
                        _FilterColumn = "FirstName";
                        break;
                    }
                case "Second Name":
                    {
                        _FilterColumn = "SecondName";
                        break;
                    }
                case "Last Name":
                    {
                        _FilterColumn = "LastName";
                        break;
                    }
                case "Phone":
                    {
                        _FilterColumn = "Phone";
                        break;
                    }
                case "Gendor":
                    {
                        _FilterColumn = "GendorCaption";
                        break;
                    }
                case "Person ID":
                    {
                        _FilterColumn = "PersonID";
                        break;
                    }
                case "NO":
                    {
                        _FilterColumn = "NationalNo";
                        break;
                    }
                case "Date Of Birth":
                    {
                        _FilterColumn = "DateOfBirth";
                        break;
                    }
                default:
                    {
                        _FilterColumn = "None";
                        break;
                    }
            }
        }
        private void _ApplyFilter()
        {
            // In this case there is no filter
            if (txtFilter.Text.Trim() == "" || _FilterColumn == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";

                return;
            }

            // Apply filter based on entered text
            if (_FilterColumn == "PersonID")
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", _FilterColumn, txtFilter.Text.Trim());
            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", _FilterColumn, txtFilter.Text.Trim());
        }

        private void PeopleScreen_Load(object sender, EventArgs e)
        {
            dgvPeopleTable.DataSource = _dtPeople;
            cbFilterType.SelectedIndex = 0;
            if (dgvPeopleTable.Rows.Count > 0)
            {

                dgvPeopleTable.Columns[0].HeaderText = "Person ID";
                dgvPeopleTable.Columns[1].HeaderText = "National No.";
                dgvPeopleTable.Columns[2].HeaderText = "First Name";
                dgvPeopleTable.Columns[3].HeaderText = "Second Name";
                dgvPeopleTable.Columns[4].HeaderText = "Last Name";
                dgvPeopleTable.Columns[5].HeaderText = "Gendor";
                dgvPeopleTable.Columns[6].HeaderText = "Date Of Birth";
                dgvPeopleTable.Columns[7].HeaderText = "Nationality";
                dgvPeopleTable.Columns[8].HeaderText = "Phone";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmRePeople PE = new frmRePeople();
            PE.ShowDialog();
            _RefreshTable();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPeopleTable.CurrentRow.Selected == false)
            {
                MessageBox.Show("Please select Person");
                return;
            }

            frmRePeople PE = new frmRePeople((int)dgvPeopleTable.CurrentRow.Cells[0].Value);
            PE.ShowDialog();

            _RefreshTable();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvPeopleTable.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (clsPerson.DeletePerson((int)dgvPeopleTable.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.");
                    _RefreshTable();
                }

                else
                    MessageBox.Show("Person is not deleted.");

            }
        }
        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (dgvPeopleTable.CurrentRow.Selected == false)
            {
                MessageBox.Show("Please select Person");
                return;
            }

            frmShowPersonDetails PD = new frmShowPersonDetails((int)dgvPeopleTable.CurrentRow.Cells[0].Value);
            PD.ShowDialog();

            _RefreshTable();
        }

        private void cbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Text = "";
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {

            _ChooseFilter();

            _ApplyFilter();

        }
        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_FilterColumn == "PersonID" || _FilterColumn == "Phone")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    e.Handled = true;
            }
        }
    }
    }
