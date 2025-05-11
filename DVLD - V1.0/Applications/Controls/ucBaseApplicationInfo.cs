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

namespace DVLD___V1._0.Applications.Controls
{
    public partial class ucBaseApplicationInfo : UserControl
    {
        private clsApplications _Application;

        private int _ApplicationID = -1;

        public int ApplicationID
        {
            get { return _ApplicationID; }
        }
        public ucBaseApplicationInfo()
        {
            InitializeComponent();
        }
        private void _FillApplicationInfo()
        {
            _ApplicationID = _Application.ApplicationID;

            lblAppIicationID.Text = _Application.ApplicationID.ToString();
            lblApplicantName.Text = _Application.ApplicantFullName;
            lblApplicationFees.Text = _Application.PaidFees.ToString();
            lblApplicationType.Text = _Application.ApplicationTypeInfo.ApplicationTypeTitle;
            lblApplicationDate.Text = clsFormat.DateToShort(_Application.ApplicationDate);
            lblStatusChangedDate.Text = _Application.LastStatusDate.ToString();
            lblUser.Text = _Application.CreatedByUserID.ToString();
            lblStatus.Text = _Application.StatusText;
        }
        public void ResetApplicationInfo()
        {
            lblAppIicationID.Text = "";
            lblApplicantName.Text = "";
            lblApplicationFees.Text = "";
            lblApplicationType.Text = "";
            lblApplicationDate.Text = "";
            lblStatusChangedDate.Text = "";
            lblUser.Text = "";
            lblStatus.Text = "";
        }
        public void LoadApplicationInfo(int AppID)
        {
            //_ApplicationID = AppID;

            _Application = clsApplications.FindBaseApplication(AppID);
            if (_Application == null)
            {
                ResetApplicationInfo();
                MessageBox.Show("No Application with ApplicationID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                _FillApplicationInfo();

            
        }

        private void btnPersonCard_Click(object sender, EventArgs e)
        {
            if (_Application == null)
                return;

            frmShowPersonDetails PersonCard = new frmShowPersonDetails(_Application.ApplicantPersonID);
            PersonCard.ShowDialog();
            LoadApplicationInfo(_ApplicationID);
        }
    }
}
