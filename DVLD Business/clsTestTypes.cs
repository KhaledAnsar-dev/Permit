using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsTestTypes
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };

        private clsTestTypes(enTestType ID, string Title, string Description, float Fees)
        {
            TestTypeID = ID;
            TestTypeTitle = Title;
            TestTypeDescription = Description;
            TestTypeFees = Fees;

            Mode = enMode.Update;
        }
        private clsTestTypes()
        {
            TestTypeID = enTestType.VisionTest;
            TestTypeTitle = "";
            TestTypeDescription = "";
            TestTypeFees = 0;

            Mode = enMode.AddNew;
        }

        public clsTestTypes.enTestType TestTypeID { set; get; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public float TestTypeFees { get; set; }

        public static clsTestTypes Find(int ID)
        {
            string Title = ""; string Description = ""; float Fees = 0;
            if (clsTestTypesData.GetTestTypeByID(ID, ref Title, ref Description, ref Fees))
            {
                return new clsTestTypes((enTestType)ID, Title, Description, Fees);
            }
            else
                return null;
        }
        private bool _AddNewTestType()
        {
            //call DataAccess Layer 
            int Result = clsTestTypesData.AddNewTestType(this.TestTypeTitle
                , this.TestTypeDescription , this.TestTypeFees);

            if (Result != -1)
            {
                this.TestTypeID = (enTestType)Result;
                return true;
            }
            return false;
        }
        private bool _UpdateTestType()
        {
            //call DataAccess Layer 

            return clsTestTypesData.Update((int)this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
        }
        public static DataTable GetAllTestTypes()
        {
            return clsTestTypesData.GetAllTestTypes();
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTestType();

            }

            return false;
        }

    }
}
