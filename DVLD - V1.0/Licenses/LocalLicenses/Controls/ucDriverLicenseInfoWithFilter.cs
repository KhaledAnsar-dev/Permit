using DVLD___V1._0.Properties;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD___V1._0.User_Controls
{
    public partial class ucDriverLicenseInfoWithFilter : UserControl
    {
        public ucDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        public delegate void LicenseSelected(int LicenseID);
        public event LicenseSelected OnLicenseSelected;

        private int _LicenseID;
        public int LicenseID
        {
            get { return ucSimplifiedDriverLicenseInfo1.LicenseID; }
        }
        public clsLicense SelectedLicense
        {
            get { return ucSimplifiedDriverLicenseInfo1.SelectedLicense; }
        }

        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {

            get { return _FilterEnabled; }
            set 
            { 
                _FilterEnabled = value;
                pnlFilter.Enabled = _FilterEnabled;
            }
        }
        protected virtual void SelectionComplete(int LicenseID)
        {
            LicenseSelected varSelect = OnLicenseSelected;

            if (varSelect != null)
            {
                varSelect(LicenseID);
            }
        }

        public void LoadDriverLicenseInfo(int LicenseID)
        {
            txtFilter.Text = LicenseID.ToString();

            ucSimplifiedDriverLicenseInfo1.LoadInfo(LicenseID);
            _LicenseID = ucSimplifiedDriverLicenseInfo1.LicenseID;
            if (ucSimplifiedDriverLicenseInfo1.SelectedLicense != null && _FilterEnabled)
                SelectionComplete(LicenseID);

        }
        public void DefaultDriverLicenseCard()
        {
            ucSimplifiedDriverLicenseInfo1.DefaultDriverLicenseCard();
        }
      
        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                btnSearch.PerformClick();
            }

        }
        private void txtLicenseID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilter.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilter, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtFilter, null);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFilter.Focus();
                return;
            }

            _LicenseID = Convert.ToInt32(txtFilter.Text.Trim());
            LoadDriverLicenseInfo(_LicenseID);
        }
        public void FilterFocus()
        {
            txtFilter.Focus();
        }

    }
}
