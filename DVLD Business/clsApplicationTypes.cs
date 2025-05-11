using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsApplicationTypes
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public float ApplicationFees { get; set; }
        private clsApplicationTypes(int ID, string Title, float Fees)
        {
            ApplicationTypeID = ID;
            ApplicationTypeTitle = Title;
            ApplicationFees = Fees;

            Mode = enMode.Update;
        }
        public clsApplicationTypes()

        {
            this.ApplicationTypeID = -1;
            this.ApplicationTypeTitle = "";
            this.ApplicationFees = 0;

            Mode = enMode.AddNew;

        }

        public static clsApplicationTypes Find(int ID)
        {
            string Title = ""; float Fees = 0;
            if (clsAppTypesData.GetAppTypeByID(ID,ref Title ,ref Fees))
            {
                return new clsApplicationTypes(ID, Title ,Fees);
            }
            else
                return null;
        }

        private bool _AddNewApplicationType()
        {
            //call DataAccess Layer 

            this.ApplicationTypeID = clsAppTypesData.AddNewApplicationType(this.ApplicationTypeTitle, this.ApplicationFees);


            return (this.ApplicationTypeID != -1);
        }
        private bool _UpdateApplicationType()
        {
            //call DataAccess Layer 

            return clsAppTypesData.Update(this.ApplicationTypeID, this.ApplicationTypeTitle, this.ApplicationFees);
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsAppTypesData.GetAllAppTypes();
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplicationType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateApplicationType();

            }

            return false;
        }
    }
}
