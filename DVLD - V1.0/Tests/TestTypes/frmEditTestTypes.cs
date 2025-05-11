using DVLD___V1._0.GlobalClasses;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD___V1._0.TestTypes
{
    public partial class frmEditTestTypes : Form
    {
        private clsTestTypes.enTestType _TestTypeID = clsTestTypes.enTestType.VisionTest;
        private clsTestTypes _TestType;

        public frmEditTestTypes(clsTestTypes.enTestType ID)
        {
            InitializeComponent();
            _TestTypeID = ID;
        }

        private void _CopyDataToObject()
        {
            _TestType.TestTypeID = (clsTestTypes.enTestType)Convert.ToInt32(txtTestTypeID.Text);
            _TestType.TestTypeTitle = txtTestTypeTitle.Text;
            _TestType.TestTypeDescription = txtTestTypeDescription.Text;
            _TestType.TestTypeFees = Convert.ToSingle(txtTestTypeFees.Text);
        }

        private void frmReTestTypes_Load(object sender, EventArgs e)
        {
            _TestType = clsTestTypes.Find((int)_TestTypeID);

            if(_TestType != null)
            {
                txtTestTypeID.Text = ((int)_TestType.TestTypeID).ToString();
                txtTestTypeTitle.Text = _TestType.TestTypeTitle;
                txtTestTypeDescription.Text = _TestType.TestTypeDescription;
                txtTestTypeFees.Text = _TestType.TestTypeFees.ToString();
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

            if (_TestType.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void txtTestTypeTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }
        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTestTypeTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestTypeTitle, "Title cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtTestTypeTitle, null);
            };
        }
        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTestTypeDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestTypeDescription, "Description cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtTestTypeDescription, null);
            };
        }
        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTestTypeFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestTypeFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtTestTypeFees, null);
            };


            if (!clsValidation.IsNumber(txtTestTypeFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestTypeFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtTestTypeFees, null);
            };
        }

    }
}

