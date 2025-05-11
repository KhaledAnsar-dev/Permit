using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsUser
    {
        enum enUser { Add, Update };
        enUser Mode;

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public clsPerson PersonInfo;

        //public clsPerson PersonInfo
        //{
        //    get { return _PersonInfo; }
        //}

        private clsUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            PersonInfo = clsPerson.Find(PersonID);
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;

            Mode = enUser.Update;
        }

        public clsUser()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = true;
            Mode = enUser.Add;
        }

        private bool _AddUser()
        {
            this.UserID = clsUserData.AddNewUser(PersonID, UserName, clsSecurity.ComputeHash(Password), IsActive);
            return this.UserID != -1;
        }
        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(UserID,PersonID, UserName,Password, IsActive);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enUser.Add:
                    {
                        if (_AddUser())
                        {
                            Mode = enUser.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                default:
                    {
                        return _UpdateUser();
                    }
            }
        }

        public static clsUser FindByUserID(int UserID)
        {
            int PersonID = -1; string UserName = "";
            string Password = ""; bool IsActive = false;
            if (clsUserData.GetUserByID(UserID, ref PersonID, ref UserName, ref Password, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }
            else
                return null;
        }
        public static clsUser FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByPersonID
                                (PersonID, ref UserID, ref UserName, ref Password, ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsUser(UserID, UserID, UserName, Password, IsActive);
            else
                return null;
        }
        public static clsUser FindByUsernameAndPassword(string UserName, string Password)
        {
            int UserID = -1;
            int PersonID = -1;

            bool IsActive = false;

            bool IsFound = clsUserData.GetUserByUserNameAndPassword
                                ( ref UserID, ref PersonID,UserName, clsSecurity.ComputeHash(Password), ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }
        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static bool DoesExists(int UserID)
        {
            return clsUserData.DoesUserExists(UserID);
        }
        public static bool DoesExists(string UserName)
        {
            return clsUserData.DoesUserExists(UserName);
        }
        public static bool IsUserExistForPersonID(int PersonID)
        {
            return clsUserData.IsUserExistForPersonID(PersonID);
        }
        public bool SavePassword()
        {
            return clsUserData.UpdatePassword(UserID, clsSecurity.ComputeHash(Password));
        }

        public static string GetUserFullName(int userID)
        {
            clsUser user = FindByUserID(userID);
            if (user != null)
            {
                return user.PersonInfo.FullName;
            }
            return string.Empty;
        }
    }
}
