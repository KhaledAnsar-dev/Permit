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

namespace DVLD___V1._0.InternationalLicenses
{
    public partial class frmScInternationalLicenses : Form
    {
        public frmScInternationalLicenses()
        {
            InitializeComponent();
        }

        private DataTable _dtInternationalLicenses;
        private string _FilterColumn = "None";

        private void _ApplyFilter()
        {
            if(_FilterColumn == "Active")
            {
                _dtInternationalLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}",_FilterColumn , 1);
                return;
            }

            if (txtFilter.Text.Trim() == "" || _FilterColumn == "None")
            {
                _dtInternationalLicenses.DefaultView.RowFilter = "";
                return;
            }

            _dtInternationalLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}" , _FilterColumn , txtFilter.Text.Trim());
        }
        private void _ChooseFilter()
        {
            switch (cbFilterType.Text)
            {
                case "International License ID":
                    {
                        _FilterColumn = "Inter LicenseID";
                        break;
                    }
                case "Application ID":
                    {
                        _FilterColumn = "ApplicationID";
                        break;
                    }
                case "Driver ID":
                    {
                        _FilterColumn = "DriverID";
                        break;
                    }
                case "Local License ID":
                    {
                        _FilterColumn = "Local LicenseID";
                        break;
                    }
                case "Is Active":
                    {
                        _FilterColumn = "Active";
                        break;
                    }
                default:
                    {
                        _FilterColumn = "None";
                        break;
                    }
            }
        }

        private void frmScInternationalLicenses_Load(object sender, EventArgs e)
        {
            _dtInternationalLicenses = clsInterLicense.GetAllInternationalLicenses();
            dgvInternationalLicenseTable.DataSource = _dtInternationalLicenses;
            cbFilterType.Text = "None";            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmReInternationLicenses ReInterLicense = new frmReInternationLicenses();
            ReInterLicense.ShowDialog();
            frmScInternationalLicenses_Load(null, null);
        }
        private void btnPersonDetails_Click(object sender, EventArgs e)
        {
        
            int LocalLicenseID = Convert.ToInt32(dgvInternationalLicenseTable.CurrentRow.Cells[3].Value);
            int PersonID = clsLicense.Find(LocalLicenseID).DriverInfo.PersonID;

            frmShowPersonDetails Card = new frmShowPersonDetails(PersonID);
            Card.ShowDialog();
            
        }
        private void btnLicenseDetails_Click(object sender, EventArgs e)
        {

            int InterLicenseID = Convert.ToInt32(dgvInternationalLicenseTable.CurrentRow.Cells[0].Value);
            
            frmDriverInterLicense Card = new frmDriverInterLicense(InterLicenseID);
            Card.ShowDialog();
        }
        private void btnLicenseHistory_Click(object sender, EventArgs e)
        {

            int LocalLicenseID = Convert.ToInt32(dgvInternationalLicenseTable.CurrentRow.Cells[3].Value);
            int PersonID = clsLicense.Find(LocalLicenseID).DriverInfo.PersonID;

            frmLicensesHistory Card = new frmLicensesHistory(PersonID);
            Card.ShowDialog();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }
        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(_FilterColumn != "None")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void cbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ChooseFilter();
            if (_FilterColumn == "Active")
            {
                txtFilter.Enabled = false;
                _ApplyFilter();
            }
            else
                txtFilter.Enabled = true; ;

        }
    }
}
