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

namespace DVLD___V1._0.LocalLicenses
{
    public partial class frmLicensesHistory : Form
    {

        public frmLicensesHistory(int PersonID)
        {
            InitializeComponent();
            this._PersonID = PersonID;            
        }

        private int _PersonID;
   
        private void frmLicensesHistory_Load(object sender, EventArgs e)
        {
            personDetails1.LoadPersonInfo(_PersonID);
            ucLicensesHistory1.LoadLicensesByPersonID(this._PersonID);
        }
    }
}
