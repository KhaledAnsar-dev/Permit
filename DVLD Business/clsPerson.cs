using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Business
{
    public class clsPerson
    {
        enum enPerson { Add , Update};
        enPerson Mode = enPerson.Add;

        public int ID;
        public string NO { get; set; }  // (Auto-Implemented Properties)
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName
        { 
            get
            { 
                return FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
            }
        }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CountryID { get; set; }
        public short Gendor { get; set; }

        private string _Image; // Private Field
        public string Image 
        {
            get { return _Image; }
            set { _Image = value; }
        } // (Auto-Implemented Properties) For Private Field


        public clsCountry Country;
        private clsPerson(int iD, string nO, string firstName, string secondName, string thirdName, string lastName, string phone, string email, string address, DateTime dateOfBirth, int country, short gendor, string image)
        {
            ID = iD;
            NO = nO;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            Phone = phone;
            Email = email;
            Address = address;
            DateOfBirth = dateOfBirth;
            CountryID = country;
            Gendor = gendor;
            Image = image;

            this.Country = clsCountry.Find(CountryID);


            Mode = enPerson.Update;
        }

        public clsPerson()
        {
            ID = -1;
            NO = "";
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            Phone = "";
            Email = "";
            Address = "";
            DateOfBirth = new DateTime();
            CountryID = -1;
            Gendor = -1;
            Image = "";
            Mode = enPerson.Add;
        }

        private bool _AddPerson()
        {
            this.ID = clsPersonData.AddNewPerson(NO, FirstName, SecondName, ThirdName, LastName, Phone, Email, Address, DateOfBirth, CountryID, Gendor, Image);
            return this.ID != -1;
        }
        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(ID, NO, FirstName, SecondName, ThirdName, LastName, Phone, Email, Address, DateOfBirth, CountryID, Gendor, Image);
        }
        public static clsPerson Find(int ID)
        {
            string NO = ""; string FirstName = "";
            string SecondName = ""; string ThirdName = "";
            string LastName = ""; string Phone = ""; string Email = "";
            string Address = ""; DateTime DateOfBirth = new DateTime();
            int Country = -1; short Gendor = -1; string Image = "";

            if (clsPersonData.GetPersonByID(ID, ref NO, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref Phone, ref Email, ref Address, ref DateOfBirth, ref Country, ref Gendor, ref Image))
            {
                return new clsPerson(ID, NO, FirstName, SecondName, ThirdName, LastName, Phone, Email, Address, DateOfBirth, Country, Gendor, Image);
            }
            else
                return null;
            
        }
        public static clsPerson Find(string NO)
        {
            int ID = -1; string FirstName = "";
            string SecondName = ""; string ThirdName = "";
            string LastName = ""; string Phone = ""; string Email = "";
            string Address = ""; DateTime DateOfBirth = new DateTime();
            int Country = -1; short Gendor = -1; string Image = "";

            if (clsPersonData.GetPersonByNO(ref ID, NO, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref Phone, ref Email, ref Address, ref DateOfBirth, ref Country, ref Gendor, ref Image))
            {
                return new clsPerson(ID, NO, FirstName, SecondName, ThirdName, LastName, Phone, Email, Address, DateOfBirth, Country, Gendor, Image);
            }
            else
                return null;

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enPerson.Add:
                {
                    if (_AddPerson())
                    {
                        Mode = enPerson.Update;
                        return true;
                    }
                    else
                        return false;
                }
                default:
                {
                        return _UpdatePerson();
                }  
            }
        }
        public static bool DeletePerson(int ID)
        {
            return clsPersonData.DeletePerson(ID);
        }
        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }
        public static bool DoesExists(int ID)
        {
            return clsPersonData.DoesPersonExists(ID);
        }
        public static bool DoesNOExists(string NO)
        {
            return clsPersonData.DoesPersonNOExists(NO);
        }

        public static DataTable Filter_DateOfBirth(DateTime Start, DateTime End)
        {
            return clsPersonData.Filter_DateOfBirth(Start, End);
        }

    }
}
