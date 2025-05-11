using DVLD___V1._0.GlobalClasses;
using DVLD_Business;
using Guna.UI2.WinForms;
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
    public partial class frmReUser : Form
    {
        public frmReUser()
        {
            InitializeComponent();

            Mode = enUser.Add;

        }
        public frmReUser(int UserID)
        {
            InitializeComponent();

            Mode = enUser.Update;
            this._UserID = UserID;
        }

        enum enUser { Add, Update };
        enUser Mode = new enUser();
        int _UserID;
        clsUser _User;


        private void _ResetDefaultValue()
        {
            if(Mode == enUser.Add)
            {
                lblUserRecordEditor.Text = "Add User";
                lblUserRecordEditor1.Text = "Add User";
                _User = new clsUser();
            }
            else
            {
                lblUserRecordEditor.Text = "Update User";
                lblUserRecordEditor1.Text = "Update User";
            }
        }
        private void _LoadData()
        {
            _User = clsUser.FindByUserID(_UserID);


            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _User, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            //the following code will not be executed if the user was not found
            ucPersonDetailsWithFilter1.FilterEnabled = false;

            // User can't change password here 
            txtPassword.Enabled = false;
            txtPaswordConfirmation.Enabled = false;

           
            txtUserID.Text = _User.UserID.ToString();
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtPaswordConfirmation.Text = _User.Password;

            if (_User.IsActive)
                rbActive.Checked = true;
            else 
                rbNotActive.Checked = true;

            ucPersonDetailsWithFilter1.LoadPersonInfo(_User.PersonID);
            
        }
        private void _CopyDataToObject()
        {
            _User.PersonID = ucPersonDetailsWithFilter1.PersonID;
            _User.UserName = txtUserName.Text.Trim();
            _User.Password = txtPassword.Text.Trim();

            if (rbActive.Checked)
                _User.IsActive = true;
            else
                _User.IsActive = false;
        }

        private void frmUserRecordEditor_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();

            if (Mode == enUser.Update)
            {
                btnNext.Enabled = true;
                _LoadData();
            }

        }
        private void PersonSelector(int PersonID)
        {
            // When we update a user record, it already exists, so there is no need to check if it exists
            if (Mode == enUser.Update)
                return;

            if (PersonID != -1)
            {
                if (clsUser.IsUserExistForPersonID(PersonID))
                {
                    MessageBox.Show("This person already belong to user", "Attention");
                }
                else
                    btnNext.Enabled = true;

            }
            else
                btnNext.Enabled = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedTab = tpFindPerson;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedTab = tpLoginInfo;
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

            _CopyDataToObject();

            if (_User.Save())
            {

                Mode = enUser.Update;
                lblUserRecordEditor.Text = "Update Person";
                lblUserRecordEditor1.Text = "Update Person";
                txtUserID.Text = _User.UserID.ToString();

                MessageBox.Show("Data saved successfully");

                this.Close();
            }
            else
            {
                MessageBox.Show("Eror : Data is not saved Data successfully");
                this.Close();
                return;
            }            
        }
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            Guna2TextBox Text = (Guna2TextBox)sender;


            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "Username cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            };


            if(Mode == enUser.Add)
            {
                if (!clsUser.DoesExists(Text.Text))
                {
                    errorProvider1.SetError(Text, "");
                }
                else
                {
                    e.Cancel = true;
                    errorProvider1.SetError(Text, "UserName Exists");
                }
            }
            else
            {
                if (_User.UserName != txtUserName.Text.Trim() && clsUser.DoesExists(Text.Text))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(Text, "UserName Exists"); 
                }
                else
                {
                    errorProvider1.SetError(Text, "");
                }
            }
       
        }
        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            };

        }
        private void txtPaswordConfirmation_Validating(object sender, CancelEventArgs e)
        {
            if (txtPaswordConfirmation.Text == txtPassword.Text)
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtPaswordConfirmation, "");
            }
            else
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPaswordConfirmation, "Password not match");
                txtPaswordConfirmation.Text = "";

            }
        }


    }
}
