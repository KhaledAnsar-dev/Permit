using DVLD_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
namespace DVLD_Business
{
    public class clsLicense
    {

        public enum enMode { Add = 0, Update = 1 }
        public enMode Mode = enMode.Add;

        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };


        public int LicenseID { set; get; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public float PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }
        public string IssueReasonText
        {
            get { return GetIssueReasonText(IssueReason); }
        }
        public int CreatedByUserID { get; set; }
        public bool IsDetained
        {
            get { return clsDetain.IsLicenseDetained(this.LicenseID); }
        }

        public clsDriver DriverInfo { set; get; }
        public clsLicenseClasses LicenseClassInfo { set; get; }
        public clsDetain DetainedInfo { set; get; }


        private clsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate,
           DateTime ExpirationDate, string Notes, float PaidFees, bool IsActive, enIssueReason IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.DetainedInfo = clsDetain.FindByLicenseID(LicenseID);
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.DriverInfo = clsDriver.FindByDriverID(DriverID);
            this.LicenseClassID = LicenseClass;
            this.LicenseClassInfo = clsLicenseClasses.Find(LicenseClassID);
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }
        public clsLicense()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClassID = -1;
            this.IssueDate = new DateTime();
            this.ExpirationDate = new DateTime();
            this.Notes = "";
            this.PaidFees = 0;
            this.IsActive = false;
            this.IssueReason = enIssueReason.FirstTime;
            this.CreatedByUserID = -1;

            Mode = enMode.Add;

        }

        private bool _AddLicense()
        {
            this.LicenseID = clsLicensesData.AddNewLicense(ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, (byte)IssueReason, CreatedByUserID);
            return this.LicenseID != -1;
        }
        private bool _UpdateLicense()
        {
            return clsLicensesData.UpdateLicense(this.LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, (byte)IssueReason, CreatedByUserID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddLicense())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLicense();

            }

            return false;
        }
        public static clsLicense Find(int LicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1;
            int LicenseClass = -1;
            DateTime IssueDate = DateTime.Today;
            DateTime ExpirationDate = DateTime.Today;
            string Notes = "";
            float PaidFees = 0;
            bool IsActive = false;
            byte IssueReason = 1;
            int CreatedByUserID = -1;

            if (clsLicensesData.GetLicenseByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass, ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            }
            else
                return null;

        }
        public static DataTable GetAllLicenses()
        {
            return clsLicensesData.GetAllLicenses();
        }

        public static string GetIssueReasonText(enIssueReason IssueReason)
        {

            switch (IssueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.DamagedReplacement:
                    return "Replacement for Damaged";
                case enIssueReason.LostReplacement:
                    return "Replacement for Lost";
                default:
                    return "First Time";
            }
        }
        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {
            return (GetActiveLicenseIDByPersonID(PersonID, LicenseClassID) != -1);
        }
        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {

            return clsLicensesData.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);

        }
        public static DataTable GetDriverLicenses(int DriverID)
        {
            return clsLicensesData.GetDriverLicenses(DriverID);
        }
        public Boolean IsLicenseExpired()
        {

            return (this.ExpirationDate < DateTime.Now);

        }
        public bool DeactivateCurrentLicense()
        {
            return (clsLicensesData.DeactivateLicense(this.LicenseID));
        }

        public int Detain(float FineFees, int CreatedByUserID)
        {
            clsDetain DetainLicense = new clsDetain();

            DetainLicense.LicenseID = this.LicenseID;
            DetainLicense.DetainDate = DateTime.Now;
            DetainLicense.FineFees = FineFees;
            DetainLicense.CreatedByUserID = CreatedByUserID;

            if (DetainLicense.Save())
            {
                return DetainLicense.DetainID;
            }
            else
                return -1;
        }
        public bool ReleaseDetainedLicense(int CreatedByUserID , ref int ApplicationID)
        {
            clsApplications Application = new clsApplications();

            Application.ApplicantPersonID = DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplications.enApplicationType.ReleaseDetainedDrivingLicsense;
            Application.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = Convert.ToSingle(this.DetainedInfo.FineFees);
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
            {
                ApplicationID = -1;
                return false;
            }


            ApplicationID = Application.ApplicationID;
            return this.DetainedInfo.ReleaseDetainedLicense(CreatedByUserID, Application.ApplicationID);
   

        }
        public clsLicense Renew(int CreatedByUserID, string Notes)
        {
            // Create an application than desactivate the current license than isseu a renewed license

            clsApplications ApplicationForRenw = new clsApplications();

            ApplicationForRenw.ApplicantPersonID = DriverInfo.PersonID;
            ApplicationForRenw.ApplicationDate = DateTime.Now;
            ApplicationForRenw.ApplicationTypeID = (int)clsApplications.enApplicationType.RenewDrivingLicense;
            ApplicationForRenw.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
            ApplicationForRenw.LastStatusDate = DateTime.Now;
            ApplicationForRenw.PaidFees = clsApplicationTypes.Find((int)clsApplications.enApplicationType.RenewDrivingLicense).ApplicationFees;
            ApplicationForRenw.CreatedByUserID = CreatedByUserID;

            if (ApplicationForRenw.Save())
            {
                clsLicense RenewedLicense = new clsLicense();

                RenewedLicense.ApplicationID = ApplicationForRenw.ApplicationID;
                RenewedLicense.DriverID = this.DriverID;
                RenewedLicense.LicenseClassID = this.LicenseClassID;
                RenewedLicense.IssueDate = DateTime.Now;
                RenewedLicense.ExpirationDate = IssueDate.AddYears(this.LicenseClassInfo.DefaultValidityLength);
                RenewedLicense.Notes = Notes;
                RenewedLicense.PaidFees = LicenseClassInfo.ClassFees;
                RenewedLicense.IsActive = true;
                RenewedLicense.IssueReason = enIssueReason.Renew;
                RenewedLicense.CreatedByUserID = CreatedByUserID;

                if (RenewedLicense.Save())
                {
                    this.DeactivateCurrentLicense();
                    return RenewedLicense;
                }
                else
                    return null;
            }
            return null;
        }

        public clsLicense Replace(int CreatedByUserID, enIssueReason IssueReason)
        {
            // Create an application than desactivate the current license than isseu a renewed license

            clsApplications ApplicationForReplace = new clsApplications();

            ApplicationForReplace.ApplicantPersonID = DriverInfo.PersonID;
            ApplicationForReplace.ApplicationDate = DateTime.Now;
            ApplicationForReplace.ApplicationTypeID = 
                (IssueReason == enIssueReason.DamagedReplacement)?
                (int)enIssueReason.DamagedReplacement : (int)enIssueReason.LostReplacement;


            ApplicationForReplace.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
            ApplicationForReplace.LastStatusDate = DateTime.Now;
            ApplicationForReplace.PaidFees = clsApplicationTypes.Find((int)clsApplications.enApplicationType.RenewDrivingLicense).ApplicationFees;
            ApplicationForReplace.CreatedByUserID = CreatedByUserID;

            if (ApplicationForReplace.Save())
            {
                clsLicense ReplacedLicense = new clsLicense();

                ReplacedLicense.ApplicationID = ApplicationForReplace.ApplicationID;
                ReplacedLicense.DriverID = this.DriverID;
                ReplacedLicense.LicenseClassID = this.LicenseClassID;
                ReplacedLicense.IssueDate = DateTime.Now;
                ReplacedLicense.ExpirationDate = ExpirationDate;
                ReplacedLicense.Notes = Notes;
                ReplacedLicense.PaidFees = LicenseClassInfo.ClassFees;
                ReplacedLicense.IsActive = true;
                ReplacedLicense.IssueReason = IssueReason;
                ReplacedLicense.CreatedByUserID = CreatedByUserID;

                if (ReplacedLicense.Save())
                {
                    this.DeactivateCurrentLicense();
                    return ReplacedLicense;
                }
                else
                    return null;
            }
            return null;
        }

    }
}
