using DVLD___V1._0.GlobalClasses;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD___V1._0
{
    public partial class frmLoginScreen : Form
    {
        public frmLoginScreen()
        {
            InitializeComponent();
        }
      

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            string UserName = ""; string Password = "";

            if (clsGlobalSettings.RetrieveStoredCredentials(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPaswword.Text = Password;
                chbRememberMe.Checked = true;
            }
            else
                chbRememberMe.Checked = false;

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPaswword.Text))
                return;
            
            clsUser User = clsUser.FindByUsernameAndPassword(txtUserName.Text.Trim(), txtPaswword.Text.Trim());

            if (User != null)
            {
                if (!User.IsActive)
                {
                    MessageBox.Show("Account is not active , please contact your admin");
                    return;
                }
                else
                {
                    if (chbRememberMe.Checked)
                        clsGlobalSettings.StoreLoginCredentials(txtUserName.Text.Trim(), txtPaswword.Text.Trim());
                    else
                        clsGlobalSettings.StoreLoginCredentials("", "");


                    clsGlobalSettings.CurrentUser = User;
                    this.Hide();
                    frmMain Main = new frmMain(this);
                    Main.ShowDialog();

                }
            }
            else
                MessageBox.Show("Worng Username or Password");
        }
    }
}
