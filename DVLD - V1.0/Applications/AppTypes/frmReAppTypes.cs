using DVLD___V1._0.GlobalClasses;
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

namespace DVLD___V1._0.AppTypes
{
    public partial class frmReAppTypes : Form
    {

        public frmReAppTypes(int applicationTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = applicationTypeID;
        }

        private int _ApplicationTypeID;
        private clsApplicationTypes _AppType;

        private void _CopyDataToObject()
        {
            _AppType.ApplicationTypeTitle = txtAppTypeTitle.Text;
            _AppType.ApplicationFees = Convert.ToSingle(txtAppTypeFees.Text);
        }
        private void frmReAppTypes_Load(object sender, EventArgs e)
        {
            _AppType = clsApplicationTypes.Find(_ApplicationTypeID);

            if (_AppType != null)
            {
                txtAppTypeID.Text = _AppType.ApplicationTypeID.ToString();
                txtAppTypeTitle.Text = _AppType.ApplicationTypeTitle.ToString();
                txtAppTypeFees.Text = _AppType.ApplicationFees.ToString();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _CopyDataToObject();

            if (_AppType.Save())
                MessageBox.Show("Data Saved Succefully");
            else
            {
                MessageBox.Show("Can Not Save Data , Please Check Your Input");
                return;
            }
        }

        private void txtAppTypeTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAppTypeTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAppTypeTitle, "Title cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtAppTypeTitle, null);
            }
        }

        private void txtAppTypeFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAppTypeFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAppTypeFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtAppTypeFees, null);
            };


            if (!clsValidation.IsNumber(txtAppTypeFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAppTypeFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtAppTypeFees, null);
            };


        }
    }
}
