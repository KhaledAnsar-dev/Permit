using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD___V1._0.GlobalClasses
{
    public class clsUtil
    {
        private static bool CreateFolderIfNotExists(string DirectoryPath)
        {
            if (!Directory.Exists(DirectoryPath))
            {
                try
                {
                    // It doesn't exist, so create the folder
                    Directory.CreateDirectory(DirectoryPath);
                    return true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
             
            }
            return true;
        }
        private static string GenerateGUID()
        {
            // Generate a new GUID
            Guid newGuid = Guid.NewGuid();

            // convert the GUID to a string
            return newGuid.ToString();
        }
        private static string ReplaceFileNameWithGuid(string SourceFile)
        {
            // Get the file extension
            FileInfo fileInfo = new FileInfo(SourceFile);
            string extension = fileInfo.Extension;

            // Generate a new GUID and append the file extension
            return GenerateGUID() + extension;
        }
        public static bool CopyImageToProjectImagesFolder(ref string SourceFile)
        {

            // this funciton will copy the image to the
            // project images foldr after renaming it
            // with GUID with the same extention, then it
            // will update the sourceFileName with the new name.


            string DestinationFolder = @"C:\Permit_People_Images\";

            // Check if the folder exists
            if (!CreateFolderIfNotExists(DestinationFolder))
            {
                return false;
            }

            // Generate a new name for the file copy
            string FileName = ReplaceFileNameWithGuid(SourceFile);


            // Prepare Destination File for the new file name
            string DestinationFile = DestinationFolder + FileName;

            try
            {
                // Copy fileImage to the new folder with new name

                File.Copy(SourceFile, DestinationFile, true);

            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            SourceFile = DestinationFile;
            return true;
        }
    }
}
