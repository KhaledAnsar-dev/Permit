using DVLD___V1._0.InternationalLicenses;
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

namespace DVLD___V1._0.User_Controls
{
    public partial class ucLicensesHistory : UserControl
    {
        public ucLicensesHistory()
        {
            InitializeComponent();
        }
        private DataTable _dtDriverLocalLicensesHistory;
        private DataTable _dtDriverInternationalLicensesHistory;
        private int _DriverID;

        private void _LoadLocalLicenses()
        {
            _dtDriverLocalLicensesHistory = clsLicense.GetDriverLicenses(_DriverID);

            dgvLocalLicensesTable.DataSource = _dtDriverLocalLicensesHistory;
        }
        private void _LoadInternationalLicenses()
        {
            _dtDriverInternationalLicensesHistory = clsDriver.GetInternationalLicenses(_DriverID);
            dgvInterLicensesTable.DataSource = _dtDriverInternationalLicensesHistory;
        }

        public void LoadLicensesByPersonID(int PersonID)
        {
            clsDriver Driver = clsDriver.FindByPersonID(PersonID);

            if (Driver == null)
            {
                MessageBox.Show("Person is not a driver", "Attention");
                return;
            }

            _DriverID = Driver.DriverID;

            _LoadLocalLicenses();
            _LoadInternationalLicenses();
        }
        public void LoadLicensesByDriverID(int DriverID)
        {
            clsDriver Driver = clsDriver.FindByDriverID(DriverID);

            if (Driver == null)
            {
                MessageBox.Show("Driver Doesn't exist", "Attention");
                return;
            }

            _DriverID = DriverID;

            _LoadLocalLicenses();
            _LoadInternationalLicenses();
        }
        public void Clear()
        {
            _dtDriverLocalLicensesHistory.Clear();
            _dtDriverInternationalLicensesHistory.Clear();
        }


        private void btnLocalLicense_Click(object sender, EventArgs e)
        {
            int LicenseID = Convert.ToInt32(dgvLocalLicensesTable.CurrentRow.Cells[0].Value);
            frmDriverLicense DriverLicense = new frmDriverLicense(LicenseID);
            DriverLicense.ShowDialog();
            
        }
        private void btnInterLicense_Click(object sender, EventArgs e)
        {
            int InterLicenseID = Convert.ToInt32(dgvInterLicensesTable.CurrentRow.Cells[0].Value);

            frmDriverInterLicense Card = new frmDriverInterLicense(InterLicenseID);
            Card.ShowDialog();
           
        }
    }
}
