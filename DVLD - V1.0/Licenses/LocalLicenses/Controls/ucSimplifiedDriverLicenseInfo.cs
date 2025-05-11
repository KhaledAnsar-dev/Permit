using DVLD___V1._0.GlobalClasses;
using DVLD___V1._0.Properties;
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

namespace DVLD___V1._0.Licenses.LocalLicenses.Controls
{
    public partial class ucSimplifiedDriverLicenseInfo : UserControl
    {
        private int _LicenseID;
        private clsLicense _License;

        public int LicenseID
        {
            get { return _LicenseID; }
        }
        public clsLicense SelectedLicense
        {
            get { return _License; }
        }
        public ucSimplifiedDriverLicenseInfo()
        {
            InitializeComponent();
        }

        public void DefaultDriverLicenseCard()
        {
            lblLicenseClass.Text = "---";
            lblLicenseID.Text = "---";
            lblDriverID.Text = "---";
            lblDetained.Text = "---";
            lblIssueReason.Text = "---";
            lblIssueDate.Text = "---";
            lblExpDate.Text = "---";
            lblNotes.Text = "---";
            lblActive.Text = "---";
            lblName.Text = "---";
            lblNo.Text = "---";
            lblGendor.Text = "---";
            lblDateOfBirth.Text = "---";

            // Default Image
            pbImage.Image = Resources.worker;
        }
        private void _LoadPersonImage()
        {
            string ImagePath = _License.DriverInfo.PersonInfo.Image;

            if (File.Exists(ImagePath))
            {
                pbImage.ImageLocation = ImagePath;
                return;
            }

            if (_License.DriverInfo.PersonInfo.Gendor == 0)
                pbImage.Image = Resources.worker;
            else
                pbImage.Image = Resources.female_worker1;

        }
        public void LoadInfo(int LicenseID)
        {
            _LicenseID = LicenseID;

            _License = clsLicense.Find(_LicenseID);

            if (_License == null)
            {
                MessageBox.Show("Could not find License ID = " + _LicenseID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }


            lblLicenseClass.Text = _License.LicenseClassInfo.ClassName;
            lblLicenseID.Text = _LicenseID.ToString();
            lblDriverID.Text = _License.DriverID.ToString();
            lblDetained.Text = _License.IsDetained ? "Yes" : "No";
            lblIssueReason.Text = _License.IssueReasonText;
            lblIssueDate.Text = clsFormat.DateToShort(_License.IssueDate);
            lblExpDate.Text = clsFormat.DateToShort(_License.ExpirationDate);
            lblNotes.Text = _License.Notes == "" ? "No Notes" : _License.Notes;
            lblActive.Text = _License.IsActive ? "Yes" : "No";
            lblName.Text = _License.DriverInfo.PersonInfo.FullName;
            lblNo.Text = _License.DriverInfo.PersonInfo.NO;
            lblGendor.Text = (_License.DriverInfo.PersonInfo.Gendor == 0) ? "Male" : "Female";
            lblDateOfBirth.Text = clsFormat.DateToShort(_License.DriverInfo.PersonInfo.DateOfBirth);

            _LoadPersonImage();
        }

    }
}
