using DVLD___V1._0.Properties;
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

namespace DVLD___V1._0
{
    public partial class ucPersonDetails : UserControl
    {
        public ucPersonDetails()
        {
            InitializeComponent();
        }

        private clsPerson _Person;
        private int _PersonId;

        // Use Properties Get To Expose Data For Read Only

        public clsPerson SelectedPersonInfo
        {
            get { return _Person;}
        }

        public int PersonID
        {
            get { return _PersonId; }
        }

        public void ResetPersonInfo()
        {

            lblPersonID.Text = "";
            lblNO.Text = "";
            lblName.Text = "";
            lblPhone.Text = "";
            lblEmail.Text = "";
            lblGendor.Text = "";
            lblAddress.Text = "";
            lblBirth.Text = "";
            lblCountry.Text = "";
            pbImage.Image = Resources.worker;
        }

        private void _LoadPersonImage()
        {

            if (_Person.Image != "")
            {
                pbImage.ImageLocation = _Person.Image;
            }
            else
                pbImage.Image = _Person.Gendor == 0 ? Resources.worker : Resources.female_worker;

        }

        private void _FillPersonInfo()
        {
            _PersonId = _Person.ID;

            lblPersonID.Text = _Person.ID.ToString();
            lblNO.Text = _Person.NO;
            lblName.Text = _Person.FullName;
            lblPhone.Text = _Person.Phone;
            lblEmail.Text = _Person.Email;
            lblGendor.Text = _Person.Gendor == 0 ? "Male" : "Female";
            lblAddress.Text = _Person.Address;
            lblBirth.Text = _Person.DateOfBirth.ToString("dd/MM/yyyy");
            lblCountry.Text = clsCountry.Find(_Person.CountryID).CountryName;

            _LoadPersonImage();

        }

        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);

            if(_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }

        public void LoadPersonInfo(string NO)
        {
            _Person = clsPerson.Find(NO);

            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with NO = " + NO, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmRePeople PRE = new frmRePeople(_PersonId);
            PRE.ShowDialog();

            // Refresh
            LoadPersonInfo(_PersonId);
        }


    }
}