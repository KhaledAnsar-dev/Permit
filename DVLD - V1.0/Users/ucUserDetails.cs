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
    public partial class ucUserDetails : UserControl
    {

        private int _UserID;
        private clsUser _User;

        public int UserID
        {
            get { return _UserID; }
        }

        public ucUserDetails()
        {
            InitializeComponent();
        }

        public void LoadUserInfo(int UserID)
        {
            _User = clsUser.FindByUserID(UserID);
            if (_User == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _UserID = UserID;
            _FillUserInfo();
        }

        private void _FillUserInfo()
        {

            personDetails1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName.ToString();

            if (_User.IsActive)
                lblStatus.Text = "Yes";
            else
                lblStatus.Text = "No";

        }

        private void _ResetPersonInfo()
        {

            personDetails1.ResetPersonInfo();
            lblUserID.Text = "";
            lblUserName.Text = "";
            lblStatus.Text = "";
        }

    }
}
