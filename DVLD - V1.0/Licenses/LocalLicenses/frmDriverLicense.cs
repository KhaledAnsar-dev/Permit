using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD___V1._0
{
    public partial class frmDriverLicense : Form
    {
        private int _LocalLicenseID;

        public frmDriverLicense(int LocalLicenseID)
        {
            InitializeComponent();
            this._LocalLicenseID = LocalLicenseID;
        }



        private void frmDriverLicense_Load(object sender, EventArgs e)
        {
            ucSimplifiedDriverLicenseInfo1.LoadInfo(_LocalLicenseID);
        }
    }
}
