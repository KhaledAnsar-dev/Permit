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
    public partial class frmLocalLicenseAppDetails : Form
    {
        public frmLocalLicenseAppDetails(int LocalLicenseApplicationID)
        {
            InitializeComponent();
            this._LocalLicenseApplicationID = LocalLicenseApplicationID;
        }

        private int _LocalLicenseApplicationID;
        private void frmLocalLicenseAppDetails_Load(object sender, EventArgs e)
        {
            ucLocalLicenseApp1.LoadApplicationInfoByLocalDrivingAppID(_LocalLicenseApplicationID);
        }
    }
}
