using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public class clsLicenseClassesData
    {
        public static Boolean GetLicenseClassByID(int ClassID, ref string ClassName, ref string ClassDescription, ref byte DefaultValidityLength, ref byte MinAllowedAge , ref float ClassFees)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM LicenseClasses WHERE LicenseClassID = @ClassID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ClassID", ClassID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if ((Reader.Read()))
                {
                    IsFound = true;
                    ClassName = Reader["ClassName"].ToString();
                    ClassDescription = Reader["ClassDescription"].ToString();
                    DefaultValidityLength = Convert.ToByte(Reader["DefaultValidityLength"]);
                    MinAllowedAge = Convert.ToByte(Reader["MinimumAllowedAge"]);
                    ClassFees = Convert.ToSingle(Reader["ClassFees"]);

                }
                else
                {
                    IsFound = false;
                }

                Reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsFound;

        }
        public static Boolean GetLicenseClassByName(ref int ClassID, string ClassName, ref string ClassDescription, ref byte DefaultValidityLength, ref byte MinAllowedAge, ref float ClassFees)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM LicenseClasses WHERE ClassName = @ClassName";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if ((Reader.Read()))
                {
                    IsFound = true;
                    ClassID = Convert.ToInt32(Reader["LicenseClassID"]);
                    ClassDescription = Reader["ClassDescription"].ToString();
                    DefaultValidityLength = Convert.ToByte(Reader["DefaultValidityLength"]);
                    MinAllowedAge = Convert.ToByte(Reader["MinimumAllowedAge"]);
                    ClassFees = Convert.ToSingle(Reader["ClassFees"]);
                }
                else
                {
                    IsFound = false;
                }

                Reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsFound;

        }
        public static DataTable GetAllClasses()
        {

            DataTable Table = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM LicenseClasses";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    Table.Load(Reader);
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Connection.Close();
            }

            return Table;

        }

        public static int AddNewLicenseClass(string ClassName, string ClassDescription,
            byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
            int LicenseClassID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Insert Into LicenseClasses 
           (
            ClassName,ClassDescription,MinimumAllowedAge, 
            DefaultValidityLength,ClassFees)
                            Values ( 
            @ClassName,@ClassDescription,@MinimumAllowedAge, 
            @DefaultValidityLength,@ClassFees)
                            where LicenseClassID = @LicenseClassID;
                            SELECT SCOPE_IDENTITY();";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            command.Parameters.AddWithValue("@ClassFees", ClassFees);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseClassID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return LicenseClassID;

        }

        public static bool UpdateLicenseClass(int LicenseClassID, string ClassName,
            string ClassDescription,
            byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  LicenseClasses  
                            set ClassName = @ClassName,
                                ClassDescription = @ClassDescription,
                                MinimumAllowedAge = @MinimumAllowedAge,
                                DefaultValidityLength = @DefaultValidityLength,
                                ClassFees = @ClassFees
                                where LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            command.Parameters.AddWithValue("@ClassFees", ClassFees);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

    }
}
