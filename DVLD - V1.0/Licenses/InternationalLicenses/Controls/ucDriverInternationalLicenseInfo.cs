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

namespace DVLD___V1._0.Licenses.InternationalLicenses.Controls
{
    public partial class ucDriverInternationalLicenseInfo : UserControl
    {
        private int _InternationalLicenseID;
        private clsInterLicense _InterLicense;
        public ucDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        public int InternationalLicenseID
        {
            get { return _InternationalLicenseID; }
        }

        private void LoadDriverImage()
        {
            string ImagePath = _InterLicense.DriverInfo.PersonInfo.Image;

            if (ImagePath != "")
            {
                if (File.Exists(_InterLicense.DriverInfo.PersonInfo.Image))
                {
                    pbImage.Load(_InterLicense.DriverInfo.PersonInfo.Image);
                    return;
                }
            }
            pbImage.Image = _InterLicense.DriverInfo.PersonInfo.Gendor == 0 ? Resources.worker : Resources.female_worker;
        }
        public void LoadInternationalinfo(int InterLicenseID)
        {
            _InterLicense = clsInterLicense.Find(InterLicenseID);

            if (_InterLicense != null)
            {
                _InternationalLicenseID = InterLicenseID;

                lblInterLicenseID.Text = InterLicenseID.ToString();

                lblLocalLicenseID.Text = _InterLicense.IssuedUsingLocalLicenseID.ToString();
                lblIsActive.Text = _InterLicense.IsActive.ToString();
                lblDriverID.Text = _InterLicense.DriverID.ToString();
                lblissueDate.Text = _InterLicense.IssueDate.ToString("dd-MM-yyyy");
                lblExpirationDate.Text = _InterLicense.ExpirationDate.ToString("dd-MM-yyyy");

                lblName.Text = _InterLicense.DriverInfo.PersonInfo.FullName;
                lblNo.Text = _InterLicense.DriverInfo.PersonInfo.NO;
                lblGendor.Text = _InterLicense.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";
                lblDateOfBirth.Text = clsFormat.DateToShort(_InterLicense.DriverInfo.PersonInfo.DateOfBirth);

                LoadDriverImage();
            }
            else
                MessageBox.Show("Can't found International License with ID : " + InterLicenseID);

        }
    }
}
