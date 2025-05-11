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

namespace DVLD___V1._0.Users
{
    public partial class frmEditPassword : Form
    {
        public frmEditPassword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }


        private int _UserID;
        private clsUser _User;

        private void _ResetDefualtValues()
        {
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtPasswordConfirmation.Text = "";
        }
        private void _UpdatePasswordForUserObject()
        {
            _User.Password = txtNewPassword.Text.Trim();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {


            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _UpdatePasswordForUserObject();

            if (_User.SavePassword())
            {
                MessageBox.Show("Password Changed Successfully.",
                   "Saved.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ResetDefualtValues();
            }
            else
            {
                MessageBox.Show("An Erro Occured, Password did not change.",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }
        private void btnDetails_Click(object sender, EventArgs e)
        {
            frmShowUserDetails SUD = new frmShowUserDetails(_UserID);
            SUD.ShowDialog();
        }
        private void frmEditPassword_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            _User = clsUser.FindByUserID(_UserID);

            if (_User == null)
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Could not Find User with id = " + _UserID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

                return;

            }
            btnDetails.Focus();
            lblUserID.Text = _UserID.ToString();
        }

        private void txtPasswordConfirmation_Validating(object sender, CancelEventArgs e)
        {
            if (txtPasswordConfirmation.Text == txtNewPassword.Text)
            {
                errorProvider1.SetError(txtPasswordConfirmation, "");
                btnSave.Enabled = true;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPasswordConfirmation, "Password not match");
                txtPasswordConfirmation.Text = "";
                btnSave.Enabled = false;

            }
        }
        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "New Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, null);
            };
        }
        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Username cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            };

            if (_User.Password != clsSecurity.ComputeHash(txtCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Current password is wrong!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            };
        }

    }
}
