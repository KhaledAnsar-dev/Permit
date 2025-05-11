using DVLD_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static DVLD_Business.clsLicense;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Business
{
    public class clsLocalLicenseApps : clsApplications
    {
        enum enMode { Add, Update };
        enMode Mode;

        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        public string PersonFullName
        {
            get { return base.PersonInfo.FullName; }
        }

        public clsLicenseClasses LicenseClassInfo;

        public clsLocalLicenseApps()
        {
            LocalDrivingLicenseApplicationID = -1;
            LicenseClassID = -1;


            Mode = enMode.Add;
        }
        private clsLocalLicenseApps(int LocalDrivingLicenseApplicationID, int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate, int ApplicationTypeID,
             enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
             float PaidFees, int CreatedByUserID, int LicenseClassID)

        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID; ;
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = (int)ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.LicenseClassID = LicenseClassID;
            this.LicenseClassInfo = clsLicenseClasses.Find(LicenseClassID);
            Mode = enMode.Update;
        }

        private bool _AddLocalLicenseApp()
        {
            this.LocalDrivingLicenseApplicationID = clsLocalLicenseAppsData.AddNewLocalLicenseApp(ApplicationID, LicenseClassID);
            return this.LocalDrivingLicenseApplicationID != -1;
        }
        private bool _UpdateLocalLicenseApp()
        {
            return clsLocalLicenseAppsData.UpdateLocalLicenseApp(LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID);
        }
        public static clsLocalLicenseApps FindByLocalDLAppID(int LocalDLAppID)
        {
            int ApplicationID = -1;
            int LicenseClassID = -1;
            Boolean IsFound = clsLocalLicenseAppsData.GetLocalDLAppByLocalDLAppID(LocalDLAppID, ref ApplicationID, ref LicenseClassID);
            if (IsFound)
            {
                //now we find the base application
                clsApplications Application = clsApplications.FindBaseApplication(ApplicationID);

                //we return new object of that person with the right data
                return new clsLocalLicenseApps(LocalDLAppID, ApplicationID, Application.ApplicantPersonID,
                    Application.ApplicationDate, Application.ApplicationTypeID, Application.ApplicationStatus
                    , Application.LastStatusDate, Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
            }
            else
                return null;
        }
        public static clsLocalLicenseApps FindByApplicationID(int ApplicationID)
        {
            int LocalDLAppID = -1;
            int LicenseClassID = -1;
            Boolean IsFound = clsLocalLicenseAppsData.GetLocalDLAppByApplicationID(ref LocalDLAppID, ApplicationID, ref LicenseClassID);

            if (IsFound)
            {
                //now we find the base application
                clsApplications Application = clsApplications.FindBaseApplication(ApplicationID);

                //we return new object of that person with the right data
                return new clsLocalLicenseApps(LocalDLAppID, ApplicationID, Application.ApplicantPersonID,
                    Application.ApplicationDate, Application.ApplicationTypeID, Application.ApplicationStatus
                    , Application.LastStatusDate, Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
            }
            else
                return null;
        }
        public bool Save()
        {
            //Because of inheritance first we call the save method in the base class,
            //it will take care of adding all information to the application table.

            base.Mode = (clsApplications.enMode)this.Mode;

            if (!base.Save())
                return false;

            switch (Mode)
            {
                case enMode.Add:
                    {
                        if (_AddLocalLicenseApp())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                default:
                    {
                        return _UpdateLocalLicenseApp();
                    }
            }
        }
        public bool DeleteLocalLicenseApp()
        {
            bool IsLocalDrivingApplicationDeleted = false;
            bool IsBaseApplicationDeleted = false;
            //First we delete the Local Driving License Application
            IsLocalDrivingApplicationDeleted = clsLocalLicenseAppsData.DeleteLocalLicenseApp(this.LocalDrivingLicenseApplicationID);

            if (!IsLocalDrivingApplicationDeleted)
                return false;
            //Then we delete the base Application
            IsBaseApplicationDeleted = base.DeleteApplication();
            return IsBaseApplicationDeleted;
        }
        public static DataTable GetAllLocalLicenseApps()
        {
            return clsLocalLicenseAppsData.GetAllLocalLicenseApps();
        }
        public bool DoesPassTestType(clsTestTypes.enTestType TestType)
        {
            return clsLocalLicenseAppsData.DoesPassTestType(this.LocalDrivingLicenseApplicationID, (int)TestType);
        }
        public bool DoesAttendTestType(clsTestTypes.enTestType TestType)
        {
            return clsLocalLicenseAppsData.DoesAttendTestType(LocalDrivingLicenseApplicationID, (int)TestType);
        }
        public byte TotalTrialsPerTest(clsTestTypes.enTestType TestType)
        {
            return clsLocalLicenseAppsData.TotalTrialsPerTest(LocalDrivingLicenseApplicationID, (int)TestType);
        }
        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalLicenseAppsData.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public bool IsThereAnActiveScheduledTest(clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalLicenseAppsData.IsThereAnActiveScheduledTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public clsTest GetLastTestPerTestType(clsTestTypes.enTestType TestType)
        {
            return clsTest.FindLastTestPerPersonAndLicenseClass(this.ApplicantPersonID, this.LicenseClassID, TestType);
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTestsData.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }

        public byte GetPassedTestCount()
        {
            return clsTestsData.GetPassedTestCount(this.LocalDrivingLicenseApplicationID);
        }
        public bool PassedAllTests()
        {
            return clsTest.PassedAllTests(this.LocalDrivingLicenseApplicationID);
        }
        public int GetActiveLicenseID()
        {//this will get the license id that belongs to this application
            return clsLicense.GetActiveLicenseIDByPersonID(this.ApplicantPersonID, this.LicenseClassID);
        }
        public bool IsLicenseIssued()
        {
            return clsLicense.GetActiveLicenseIDByPersonID(this.ApplicantPersonID, this.LicenseClassID) != -1;
        }
        public int IssueLicenseForFirstTime(string Notes, int CreatedByUserID)
        {
            clsDriver Driver = clsDriver.FindByPersonID(this.ApplicantPersonID);

                if (Driver == null)
                {
                    Driver = new clsDriver();

                    // Create driver if not exists
                    Driver.PersonID = this.ApplicantPersonID;
                    Driver.CreatedByUserID = CreatedByUserID;
                    Driver.CreatedDate = DateTime.Now;

                    if (!Driver.Save())
                        return -1;

                }
           
            // Create new license
            clsLicense License = new clsLicense();

            License.DriverID = Driver.DriverID;
            License.ApplicationID = this.ApplicationID;
            License.LicenseClassID = this.LicenseClassInfo.LicenseClassID;
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            License.Notes = Notes;
            License.PaidFees = this.LicenseClassInfo.ClassFees;
            License.IsActive = true;
            License.IssueReason = enIssueReason.FirstTime;
            License.CreatedByUserID = CreatedByUserID;

            if (License.Save())
            {
                this.Complete();
                return License.LicenseID;
            }
            else
            {
                return -1;
            }
        }
    }
    }

