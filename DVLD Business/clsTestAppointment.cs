using DVLD_Data;
using System;
using System.Data;


namespace DVLD_Business
{
    public class clsTestAppointment
    {
        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LicenseAppID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUser { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { set; get; }
        public clsApplications RetakeTestAppInfo { set; get; }

        public int TestID
        {
            get { return _GetTestID(); }

        }

        enum enMode { Add, Update}
        enMode Mode;

        public clsTestAppointment() 
        {
            TestAppointmentID = -1;
            TestTypeID = -1;
            LicenseAppID = -1;
            AppointmentDate = new DateTime();
            PaidFees = 0;
            CreatedByUser = -1;
            RetakeTestApplicationID = -1;

            Mode = enMode.Add;
        }
        private clsTestAppointment(int testAppointmentID, int testTypeID, int licenseAppID, DateTime appointmentDate, float paidFees, int createdByUser, bool isLocked, int retakeTestApplicationID)
        {
            TestAppointmentID = testAppointmentID;
            TestTypeID = testTypeID;
            LicenseAppID = licenseAppID;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            CreatedByUser = createdByUser;
            IsLocked = isLocked;
            RetakeTestApplicationID = retakeTestApplicationID;
            RetakeTestAppInfo = clsApplications.FindBaseApplication(retakeTestApplicationID);
            Mode = enMode.Update;
        }

        private int _GetTestID()
        {
            return clsTestAppointmentData.GetTestID(TestAppointmentID);
        }
        private bool _AddTestAppointment()
        {
            this.TestAppointmentID = clsTestAppointmentData.AddNewTestAppointment(TestTypeID , LicenseAppID , AppointmentDate , PaidFees , CreatedByUser,RetakeTestApplicationID);
            return this.TestAppointmentID != -1;
        }
        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentData.UpdateTestAppointment(TestAppointmentID , TestTypeID, LicenseAppID, AppointmentDate, PaidFees, CreatedByUser, IsLocked,RetakeTestApplicationID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    {
                        if (_AddTestAppointment())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                default:
                    {
                        return _UpdateTestAppointment();
                    }
            }
        }

        public static clsTestAppointment Find(int ID)
        {
            int TestTypeID = -1;
            int LicenseAppID = -1;
            DateTime AppointmentDate = new DateTime();
            float PaidFees = 0;
            int CreatedByUser = -1;
            bool IsLocked = false;
            int RetakeTestApp = -1;

            if (clsTestAppointmentData.GetTestAppointmentByID(ID, ref TestTypeID ,ref LicenseAppID ,ref AppointmentDate,ref PaidFees , ref CreatedByUser ,ref IsLocked , ref RetakeTestApp))
            {
                return new clsTestAppointment(ID, TestTypeID, LicenseAppID, AppointmentDate, PaidFees, CreatedByUser, IsLocked, RetakeTestApp);
            }
            else
                return null;
        }
        public static clsTestAppointment GetLastTestAppointment(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)
        {
            int TestAppointmentID = -1;
            DateTime AppointmentDate = DateTime.Now; float PaidFees = 0;
            int CreatedByUserID = -1; bool IsLocked = false; int RetakeTestApplicationID = -1;

            if (clsTestAppointmentData.GetLastTestAppointment(LocalDrivingLicenseApplicationID, (int)TestTypeID,
                ref TestAppointmentID, ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))

                return new clsTestAppointment(TestAppointmentID, (int)TestTypeID, LocalDrivingLicenseApplicationID,
             AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            else
                return null;

        }
        
        public static DataTable GetAllTestAppointments()
        {
            return clsTestAppointmentData.GetAllTestAppointments();
        }
        public DataTable GetApplicationTestAppointmentsPerTestType(clsTestTypes.enTestType TestTypeID)
        {
            return clsTestAppointmentData.GetApplicationTestAppointmentsPerTestType(this.LicenseAppID, (int)TestTypeID);
        }
        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)
        {
            return clsTestAppointmentData.GetApplicationTestAppointmentsPerTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }



    }
}
