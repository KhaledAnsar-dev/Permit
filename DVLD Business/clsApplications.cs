using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsApplications
    {
        public enum enMode { Add, Update };
        public enMode Mode;
        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 8
        };
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };

        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public string ApplicantFullName
        {
            get
            {
                return clsPerson.Find(ApplicantPersonID).FullName;
            }
        }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public enApplicationStatus ApplicationStatus { get; set; }
        public string StatusText
        {
            get
            {
                switch(ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        {
                            return "New";
                        }
                    case enApplicationStatus.Cancelled:
                        {
                            return "Cancelled";
                        }
                    case enApplicationStatus.Completed:
                        {
                            return "Completed";
                        }
                    default:
                        {
                            return "Unknown";
                        }
                }
                ;
            }
        }
        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }


        public clsApplicationTypes ApplicationTypeInfo;
        public clsUser CreatedByUserInfo;


        private clsApplications(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
            byte ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.PersonInfo = clsPerson.Find(ApplicantPersonID);
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeInfo = clsApplicationTypes.Find(ApplicationTypeID);
            this.ApplicationStatus = (enApplicationStatus)ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUserInfo = clsUser.FindByUserID(CreatedByUserID);


            Mode = enMode.Update;
        }

        public clsApplications()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;

            Mode = enMode.Add;
        }

        private bool _AddApp()
        {
            this.ApplicationID = clsApplicationsData.AddNewApplication(ApplicantPersonID, ApplicationDate, ApplicationTypeID, (byte)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            return this.ApplicationID != -1;
        }
        private bool _UpdateApp()
        {
            return clsApplicationsData.UpdateApplication(ApplicationID,ApplicantPersonID, ApplicationDate , ApplicationTypeID , (byte)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
        }
        public static clsApplications FindBaseApplication(int ID)
        {
            int ApplicantPersonID = -1; DateTime ApplicationDate = new DateTime(); int ApplicationTypeID = -1;
            byte ApplicationStatus = 1; DateTime LastStatusDate = new DateTime(); float PaidFees = -1; int CreatedByUserID = -1;

            if (clsApplicationsData.GetApplicationByID(ID, ref ApplicantPersonID,ref ApplicationDate,ref ApplicationTypeID, ref ApplicationStatus,ref LastStatusDate, ref PaidFees,ref CreatedByUserID))
            {
                return new clsApplications(ID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            }
            else
                return null;
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    {
                        if (_AddApp())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                default:
                    {
                        return _UpdateApp();
                    }
            }
        }
        public bool DeleteApplication()
        {
            return clsApplicationsData.DeleteApplication(this.ApplicationID);
        }

        public bool Cancel()
        {
            return clsApplicationsData.UpdateStatus(ApplicationID, 2);
        }
        public bool Complete()
        {
            return clsApplicationsData.UpdateStatus(ApplicationID, 3);
        }


        public static bool IsApplicationExist(int ApplicationID)
        {
            return clsApplicationsData.IsApplicationExist(ApplicationID);
        }

        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return clsApplicationsData.DoesPersonHaveActiveApplication(PersonID, ApplicationTypeID);
        }

        public bool DoesPersonHaveActiveApplication(int ApplicationTypeID)
        {
            return DoesPersonHaveActiveApplication(this.ApplicantPersonID, ApplicationTypeID);
        }

        public static int GetActiveApplicationID(int PersonID, clsApplications.enApplicationType ApplicationTypeID)
        {
            return clsApplicationsData.GetActiveApplicationID(PersonID, (int)ApplicationTypeID);
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, clsApplications.enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return clsApplicationsData.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationTypeID, LicenseClassID);
        }

        public int GetActiveApplicationID(clsApplications.enApplicationType ApplicationTypeID)
        {
            return GetActiveApplicationID(this.ApplicantPersonID, ApplicationTypeID);
        }
    }
}
