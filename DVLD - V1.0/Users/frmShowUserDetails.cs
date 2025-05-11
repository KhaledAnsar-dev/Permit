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
    public partial class frmShowUserDetails : Form
    {

        private int _UserID;

        public frmShowUserDetails(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }


        private void frmShowUserDetails_Load(object sender, EventArgs e)
        {
            ucUserDetails1.LoadUserInfo(_UserID);
        }
    }
}
