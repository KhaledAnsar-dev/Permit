using DVLD___V1._0.LocalLicenses;
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

namespace DVLD___V1._0.Drivers
{
    public partial class frmScDrivers : Form
    {
        public frmScDrivers()
        {
            InitializeComponent();
        }
        private DataTable _dtAllDrivers;
        private string _FilterColumn = "None";

        private void _ApplyFilter()
        {
            if(txtFilter.Text.Trim() == "" || _FilterColumn == "None")
            {
                _dtAllDrivers.DefaultView.RowFilter = "";
                return;
            }

            if(_FilterColumn == "Driver ID" || _FilterColumn == "Person ID")
            {
                _dtAllDrivers.DefaultView.RowFilter = string.Format("[{0}] = {1}", _FilterColumn, txtFilter.Text);
                return;
            }

            _dtAllDrivers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", _FilterColumn, txtFilter.Text);

        }
        private void _ChooseFilter()
        {
            switch (cbFilterType.Text)
            {
                case "Driver ID":
                    {
                        _FilterColumn = "Driver ID";
                        break;
                    }
                case "Person ID":
                    {
                        _FilterColumn = "Person ID";
                        break;
                    }
                case "NO":
                    {
                        _FilterColumn = "No";
                        break;
                    }
                default:
                    {
                        _FilterColumn = "None";
                        break;
                    }
            }
        }
        private void frmScDrivers_Load(object sender, EventArgs e)
        {
            cbFilterType.SelectedIndex = 0;
            _dtAllDrivers = clsDriver.GetAllDrivers();
            dgvDriversTable.DataSource = _dtAllDrivers;
        }

        private void cbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ChooseFilter();
            txtFilter.Text = "";
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }
        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterType.Text == "Driver ID" || cbFilterType.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = Convert.ToInt32(dgvDriversTable.CurrentRow.Cells[1].Value);

            frmShowPersonDetails showPersonDetails = new frmShowPersonDetails(PersonID);
            showPersonDetails.ShowDialog();

            frmScDrivers_Load(null, null);

        }

        private void licensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = Convert.ToInt32(dgvDriversTable.CurrentRow.Cells[1].Value);
            frmLicensesHistory LicensesHistory = new frmLicensesHistory(PersonID);
            LicensesHistory.ShowDialog();
        }

    }
}
