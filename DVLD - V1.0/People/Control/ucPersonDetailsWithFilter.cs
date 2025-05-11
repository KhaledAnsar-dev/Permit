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

namespace DVLD___V1._0.Users
{
    public partial class ucPersonDetailsWithFilter : UserControl
    {
        public ucPersonDetailsWithFilter()
        {
            InitializeComponent();
        }


        private bool _ShowAddButton = true;
        private bool _FilterEnabled = true;

        public int PersonID
        {
            get { return personDetails1.PersonID; }
        }
        public clsPerson SelectedPersonInfo
        {
            get {return personDetails1.SelectedPersonInfo; }
        }
        public bool ShowAddPerson
        {
            get {return _ShowAddButton; }
            set
            {
                _ShowAddButton = value;
                btnAddPerson.Visible = _ShowAddButton;
            }
        }
        public bool FilterEnabled
        {
            get {return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                pnlPersonFilter.Enabled = _FilterEnabled;
            }
        }


        public delegate void PersonSelected(int PersonID);
        public event PersonSelected OnPersonSelected;

        protected virtual void SelectionComplete(int PersonID)
        {
            PersonSelected varSelect = OnPersonSelected;

            if(varSelect != null)
            {
                varSelect(PersonID);
            }
        }

        private void _AddedPerson(object sender, int PersonID)
        {
            LoadPersonInfo(PersonID);
        }
        private void _FindNow()
        {
            switch (cbFilterType.Text)
            {
                case "PersonID":
                    {
                        personDetails1.LoadPersonInfo(Convert.ToInt32(txtFilter.Text));
                        break;
                    }
                default:
                    {
                        personDetails1.LoadPersonInfo(txtFilter.Text);
                        break;
                    }
            }

            // Indicate that the person is selected
            if (personDetails1.SelectedPersonInfo != null)
                SelectionComplete(PersonID);
        }

        public void LoadPersonInfo(int PersonID)
        {
            cbFilterType.SelectedIndex = 0;
            txtFilter.Text = PersonID.ToString();
            _FindNow();
        }
        public void LoadPersonInfo(string No)
        {
            cbFilterType.SelectedIndex = 1;
            txtFilter.Text = No;
            _FindNow();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _FindNow();       
        }
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmRePeople PRE = new frmRePeople();
            PRE.DataBack += _AddedPerson;
            PRE.ShowDialog();
        }

        private void cbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Text = "";
        }
        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                btnSearch.PerformClick();
            }
            if (cbFilterType.Text == "PersonID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    e.Handled = true;
            }
        }
        private void ucPersonDetailsWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterType.SelectedItem = 0;
        }
        private void txtFilter_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtFilter.Text.Trim()) && cbFilterType.Text != "")
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
    }
}
