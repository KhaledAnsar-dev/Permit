using DVLD___V1._0.Properties;
using DVLD_Business;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using System.Runtime.InteropServices;
using DVLD___V1._0.GlobalClasses;

namespace DVLD___V1._0
{
    public partial class frmRePeople : Form
    {

        enum enPerson { Add, Update };
        public enum enGendor { Male = 0, Female = 1 };

        enPerson _Mode = new enPerson();
        int _PersonID;
        clsPerson _Person;

        public delegate void PersonCreated(object sender, int PersonID);
        public event PersonCreated DataBack;


        public frmRePeople()
        {
            InitializeComponent();

            _Mode = enPerson.Add;
        }
        public frmRePeople(int ID)
        {
            InitializeComponent();

            _Mode = enPerson.Update;
            _PersonID = ID;
        }

        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values
            _LoadCountries();

            if (_Mode == enPerson.Add)
            {
                lblPersonRecordEditor.Text = "Add New Person";
                _Person = new clsPerson();
            }
            else
            {
                lblPersonRecordEditor.Text = "Update Person";
            }

            //set default image for the person.
            if (rbMale.Checked)
                pbImage.Image = Resources.worker;
            else
                pbImage.Image = Resources.female_worker;

            //hide/show the remove linke incase there is no image for the person.
            btnRemoveImg.Visible = (pbImage.ImageLocation != null);

            //we set the max date to 18 years from today, and set the default value the same.
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            //should not allow adding age more than 100 years
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            //this will set default country to jordan.
            cbCountry.SelectedIndex = cbCountry.FindString("Algeria");

            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            //txtNationalNo.Text = "";
            rbMale.Checked = true;
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAdress.Text = "";


        }
        private void _LoadData()
        {

            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("No Person with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            //the following code will not be executed if the person was not found
            txtPerson.Text = _PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            dtpDateOfBirth.Value = _Person.DateOfBirth;

            if (_Person.Gendor == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            txtAdress.Text = _Person.Address;
            txtPhone.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;
            cbCountry.SelectedIndex = cbCountry.FindString(_Person.Country.CountryName);


            //load person image incase it was set.
            if (_Person.Image != "")
            {
                pbImage.ImageLocation = _Person.Image;

            }

            //hide/show the remove button incase there is no image for the person.
            btnRemoveImg.Visible = (_Person.Image != "");

        }
        private void _LoadCountries()
        {
            DataTable dataTable = clsCountry.GetAllCountries();
            foreach (DataRow Row in dataTable.Rows)
            {
                cbCountry.Items.Add(Row["CountryName"].ToString());
            }
        }
        private void _CopyDataToPersonObject()
        {

            int CountryID = clsCountry.Find(cbCountry.Text).ID;

            _Person.NO = txtNO.Text.Trim();
            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Address = txtAdress.Text.Trim();

            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.CountryID = CountryID;

            if (rbMale.Checked)
                _Person.Gendor = (short)enGendor.Male;
            else
                _Person.Gendor = (short)enGendor.Female;

            if (pbImage.ImageLocation != null)
                _Person.Image = pbImage.ImageLocation;
            else
                _Person.Image = "";
        }
        private void _GetPicture()
        {
            openFileDialog1.Title = "Choose a picture";
            openFileDialog1.DefaultExt = "PNG";
            openFileDialog1.Multiselect = false;
            openFileDialog1.InitialDirectory = "C:'\'Users'\'pc'\'Desktop";
            openFileDialog1.Filter = "Image Files(*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected fil
                string selectedFilePath = openFileDialog1.FileName;
                pbImage.SizeMode = PictureBoxSizeMode.StretchImage;
                pbImage.ImageLocation = selectedFilePath;
            }
        }
        private bool _HandlePersonImage()
        {
            // We Copy the image to the People Images folder
            // only when there is a new image for the person

            // Check if the image has changed
            if(_Person.Image != pbImage.ImageLocation)
            {
                // Check if the person had an old image
                if(_Person.Image != "")
                {
                    try
                    {
                        // Delete the image to replace or leave it empty
                        File.Delete(_Person.Image);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error");
                    }
                }
                // Check if there is a new image 
                if(pbImage.ImageLocation != null)
                {
                    string SourceFile = pbImage.ImageLocation;
                    try
                    {
                        if (clsUtil.CopyImageToProjectImagesFolder(ref SourceFile))
                            pbImage.ImageLocation = SourceFile;
                        return true;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error");
                        return false;
                    }
                }

            }
            return true;
        }
        private void PeopleRecordEditor_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

           if(_Mode == enPerson.Update)
            {
                _LoadData();
            }

            
        }


        private void pbImage_Click(object sender, EventArgs e)
        {
           _GetPicture();
        }
        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if(rbMale.Checked) 
            {
                pbImage.Image = Resources.worker;
            }
            else
            { 
                pbImage.Image = Resources.female_worker;
            }

        }
        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFemale.Checked)
            {
                pbImage.Image = Resources.female_worker;
            }
        }
        private void btnRemoveImg_Click(object sender, EventArgs e)
        {

            pbImage.ImageLocation = null;

            if (rbMale.Checked)
                pbImage.Image = Resources.worker;
            else
                pbImage.Image = Resources.female_worker;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (this.ValidateChildren()) // Validation Form
            {

                // Handle image

                if (!_HandlePersonImage())
                    return;

                _CopyDataToPersonObject();

                if (_Person.Save())
                {
                    MessageBox.Show("Data saved successfully");

                    _Mode = enPerson.Update;
                    lblPersonRecordEditor.Text = "Update Person";
                    txtPerson.Text = _Person.ID.ToString();
                    _PersonID = _Person.ID;
                    // Trigger the event to send data back to the caller form.
                    DataBack?.Invoke(this ,_PersonID);  
                }
                else
                {
                    MessageBox.Show("Eror : Data is not saved Data successfully");
                    this.Close();
                    return;
                }

            }
            else
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // Input Validdation
        private void txtNO_Validating(object sender, CancelEventArgs e)
        {
            string Text = txtNO.Text.Trim();

            if (string.IsNullOrEmpty(Text))
            {

                e.Cancel = true;
                errorProvider1.SetError(txtNO, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtNO, "");

            }

            if (txtNO.Text.ToUpper() != _Person.NO.ToUpper() && clsPerson.DoesNOExists(txtNO.Text))
            {
                e.Cancel = true;
                //txtNO.Focus();
                errorProvider1.SetError(txtNO, "NO Exists , enter another one");
            }
            else
            {
                errorProvider1.SetError(txtNO, "");
            }
        }
        private void txtMandatortyName_Validating(object sender, CancelEventArgs e)
        {
            Guna2TextBox TempControl = (Guna2TextBox)sender;

            string Text = TempControl.Text.Trim();


            if (!string.IsNullOrEmpty(Text.Trim()) && clsValidation.IsValidName(Text.ToUpper()))
            {
                errorProvider1.SetError(TempControl, "");

            }
            else
            {
                e.Cancel = true;
                TempControl.Focus();
                errorProvider1.SetError(TempControl, "Please enter a valid name");
            }
        }
        private void txtOptionalName_Validating(object sender, CancelEventArgs e)
        {
            Guna2TextBox TempControl = (Guna2TextBox)sender;

            string Text = TempControl.Text.Trim();

            if (string.IsNullOrEmpty(Text.Trim()))
                return;

            if (clsValidation.IsValidName(Text.ToUpper()))
            {
                errorProvider1.SetError(TempControl, "");
            }
            else
            {
                e.Cancel = true;
                TempControl.Text = "";
            }

        }
        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            Guna2TextBox TempControl = (Guna2TextBox)sender;

            string Text = TempControl.Text.Trim();

            if (!string.IsNullOrEmpty(Text.Trim()) && clsValidation.CheckPhone(Text.ToUpper()))
            {
                errorProvider1.SetError(TempControl, "");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TempControl, "Please enter a valid phone");
                TempControl.Text = "";
                TempControl.Focus();

            }
        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            string Text = txtEmail.Text.Trim();


            if (string.IsNullOrEmpty(Text.Trim()))
                return;

            if (clsValidation.ValidateEmail(Text.ToUpper()))
            {
                errorProvider1.SetError(txtEmail, "");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, "Please enter a valid email");
                txtEmail.Text = "";
            }
        }

    }
}
