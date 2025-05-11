using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD___V1._0.InternationalLicenses
{
    public partial class frmDriverInterLicense : Form
    {
        public frmDriverInterLicense(int InterLicenseID)
        {
            InitializeComponent();
            this._InterLicenseID = InterLicenseID;
        }

        private int _InterLicenseID;

        private void frmDriverInterLicense_Load(object sender, EventArgs e)
        {
            ucDriverInternationalLicenseInfo1.LoadInternationalinfo(_InterLicenseID);
        }
    }
}
