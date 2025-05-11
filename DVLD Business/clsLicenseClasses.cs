using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsLicenseClasses
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte DefaultValidityLength { get; set; }
        public byte MinAllowedAge { get; set; }
        public float ClassFees { get; set; }

        private clsLicenseClasses()
        {
            this.LicenseClassID = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.DefaultValidityLength = 0;
            this.MinAllowedAge = 0;
            this.ClassFees = 0;

            Mode = enMode.AddNew;
        }

        private clsLicenseClasses(int LicenseClassID, string ClassName, string ClassDescription, byte DefaultValidityLength, byte MinAllowedAge, float ClassFees) 
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.DefaultValidityLength = DefaultValidityLength;
            this.MinAllowedAge = MinAllowedAge;
            this.ClassFees = ClassFees; 

            Mode = enMode.Update;
        }
        private bool _AddNewLicenseClass()
        {
            //call DataAccess Layer 

            this.LicenseClassID = clsLicenseClassesData.AddNewLicenseClass(this.ClassName, this.ClassDescription,
                this.MinAllowedAge, this.DefaultValidityLength, this.ClassFees);


            return (this.LicenseClassID != -1);
        }

        private bool _UpdateLicenseClass()
        {
            //call DataAccess Layer 

            return clsLicenseClassesData.UpdateLicenseClass(this.LicenseClassID, this.ClassName, this.ClassDescription,
                this.MinAllowedAge, this.DefaultValidityLength, this.ClassFees);
        }
        public static clsLicenseClasses Find(int ID)
        {
            string ClassName = ""; string ClassDescription = "";
            byte DefaultValidityLength = 0; byte MinAllowedAge = 0; float ClassFees = 0;

            if (clsLicenseClassesData.GetLicenseClassByID(ID ,ref ClassName , ref ClassDescription , ref DefaultValidityLength , ref MinAllowedAge , ref ClassFees))
            {
                return new clsLicenseClasses(ID, ClassName, ClassDescription, DefaultValidityLength, MinAllowedAge, ClassFees);
            }
            else
                return null;
        }
        public static clsLicenseClasses Find(string ClassName)
        {
            int ID = -1; string ClassDescription = ""; byte DefaultValidityLength = 0;
            byte MinAllowedAge = 0; float ClassFees = 0;

            if (clsLicenseClassesData.GetLicenseClassByName(ref ID, ClassName, ref ClassDescription, ref DefaultValidityLength, ref MinAllowedAge, ref ClassFees))
            {
                return new clsLicenseClasses(ID, ClassName, ClassDescription, DefaultValidityLength, MinAllowedAge, ClassFees);
            }
            else
                return null;
        }

        public static DataTable GetAllClasses()
        {
            return clsLicenseClassesData.GetAllClasses();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicenseClass())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLicenseClass();

            }

            return false;
        }

    }
}
