using DVLD_Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;
using DVLD___V1._0.GlobalClasses;

namespace DVLD___V1._0
{
    public class clsGlobalSettings
    {
        public static clsUser CurrentUser;

        [Obsolete("We will delete this method soon")]
        public static bool RememberLoginInfo(string UserName, string Password)
        {
            try
            { 
                // Get current directory 
                string CurrentDirectory = Directory.GetCurrentDirectory();

                // File name (Txt file)
                string FileName = "CurrentUserInfo.txt";


                // Get file full path
                string FileFullPath = Path.Combine(CurrentDirectory, FileName);


                // If Username is empty than delete the file
                if (string.IsNullOrEmpty(UserName))
                {
                    if (File.Exists(FileFullPath))
                    {
                        File.Delete(FileFullPath);
                        FileFullPath = null;
                    }
                    return true;
                }

                // Insure file exists
                if (!File.Exists(FileFullPath))
                {
                    File.Create(FileFullPath).Dispose();
                }

                // Prepare the Credential string
                string Credential = UserName + "#//#" + Password;

                // Save User info

                using (StreamWriter Writer = new StreamWriter(FileFullPath))
                {
                    Writer.WriteLine(Credential);
                    return true;
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Error : " + ex.Message);

                return false;
            }
            

        }
        public static bool StoreLoginCredentials(string UserName, string Password)
        {
            string Path = @"HKEY_CURRENT_USER\SOFTWARE\Permit";

            string username = "UserName";
            string usernameData = UserName;

            string password = "Password";
            string passwordData = Password;

            try
            {
                Registry.SetValue(Path , username, usernameData , RegistryValueKind.String);
                Registry.SetValue(Path, password, passwordData, RegistryValueKind.String);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);

                return false;
            }


        }

        [Obsolete("We will delete this method soon")]
        public static bool GetStoredCredential(ref string UserName , ref string Password)
        {
            try
            {
                // Get current directory 
                string CurrentDirectory = Directory.GetCurrentDirectory();

                // File name (Txt file)
                string FileName = "CurrentUserInfo.txt";

                // Get file full path
                string FileFullPath = Path.Combine(CurrentDirectory, FileName);

                if (File.Exists(FileFullPath))
                {

                    using (StreamReader Reader = new StreamReader(FileFullPath))
                    {
                        string Credential = Reader.ReadLine();

                        string[] UsernameAndPassword = Credential.Split(new string[] { "#//#" }, StringSplitOptions.None);
                        UserName = UsernameAndPassword[0];
                        Password = UsernameAndPassword[1];
                        return true;
                    }
                   

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured : " + ex.Message);
                return false;
            }
            
            return false;


        }
        public static bool RetrieveStoredCredentials(ref string UserName, ref string Password)
        {
            bool IsFound = false;
            string Path = @"HKEY_CURRENT_USER\SOFTWARE\Permit";

            string username = "UserName";
            string password = "Password";

            try
            {
                UserName = Registry.GetValue(Path, username, null) as string;
                Password = Registry.GetValue(Path, password, null) as string;

                if (UserName != null && Password != null)
                    IsFound = true; 

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured : " + ex.Message);
                IsFound =  false;
            }

            return IsFound;
        }

    }
}
