using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Data
{
    public class clsDetainData
    {
        public static bool GetDetainedLicenseInfoByID(int DetainID,
            ref int LicenseID, ref DateTime DetainDate,
            ref float FineFees, ref int CreatedByUserID,
            ref bool IsReleased, ref DateTime ReleaseDate,
            ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    LicenseID = (int)reader["LicenseID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = Convert.ToSingle(reader["FineFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    IsReleased = (bool)reader["IsReleased"];

                    if (reader["ReleaseDate"] == DBNull.Value)

                        ReleaseDate = DateTime.MaxValue;
                    else
                        ReleaseDate = (DateTime)reader["ReleaseDate"];


                    if (reader["ReleasedByUserID"] == DBNull.Value)

                        ReleasedByUserID = -1;
                    else
                        ReleasedByUserID = (int)reader["ReleasedByUserID"];

                    if (reader["ReleaseApplicationID"] == DBNull.Value)

                        ReleaseApplicationID = -1;
                    else
                        ReleaseApplicationID = (int)reader["ReleaseApplicationID"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static bool GetDetainedLicenseInfoByLicenseID(int LicenseID,
            ref int DetainID, ref DateTime DetainDate,
            ref float FineFees, ref int CreatedByUserID,
            ref bool IsReleased, ref DateTime ReleaseDate,
            ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT top 1 * FROM DetainedLicenses WHERE LicenseID = @LicenseID order by DetainID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    DetainID = (int)reader["DetainID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = Convert.ToSingle(reader["FineFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    IsReleased = (bool)reader["IsReleased"];

                    if (reader["ReleaseDate"] == DBNull.Value)

                        ReleaseDate = DateTime.MaxValue;
                    else
                        ReleaseDate = (DateTime)reader["ReleaseDate"];


                    if (reader["ReleasedByUserID"] == DBNull.Value)

                        ReleasedByUserID = -1;
                    else
                        ReleasedByUserID = (int)reader["ReleasedByUserID"];

                    if (reader["ReleaseApplicationID"] == DBNull.Value)

                        ReleaseApplicationID = -1;
                    else
                        ReleaseApplicationID = (int)reader["ReleaseApplicationID"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static DataTable GetAllDeatainedLicenses()
        {

            DataTable Table = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            // Using Inner Join
            string Query = "SELECT  " +
                                "DL.DetainID AS [Detain ID], " +
                                "DL.LicenseID AS [License ID] , " +
                                "DL.DetainDate , " +
                                "DL.IsReleased AS [Is Released] , " +
                                "DL.FineFees , " +
                                "DL.ReleaseDate , " +
                                "P.NationalNo , " +
                                "[Full Name] = P.FirstName + ' ' + P.SecondName + ' ' + ISNULL(P.ThirdName,'') + ' ' + P.LastName " +
                           "FROM DetainedLicenses DL " +
                           "INNER JOIN Licenses L ON " +
                           "DL.LicenseID = L.LicenseID " +
                           "INNER JOIN Applications App ON " +
                           "L.ApplicationID = App.ApplicationID " +
                           "INNER JOIN People P " +
                           "ON App.ApplicantPersonID = P.PersonID";

            // Using Left Outer Join
            string Query2 = "SELECT  " +
                               "DL.DetainID , " +
                               "DL.LicenseID , " +
                               "DL.DetainDate , " +
                               "DL.IsReleased , " +
                               "DL.FineFees , " +
                               "DL.ReleaseDate , " +
                               "P.NationalNo , " +
                               "[Full Name] = P.FirstName + ' ' + P.SecondName + ' ' + ISNULL(P.ThirdName,'') + ' ' + P.LastName " +
                          "FROM DetainedLicenses DL " +
                          "LEFT OUTER JOIN Licenses L ON " +
                          "DL.LicenseID = L.LicenseID " +
                          "INNER JOIN Applications App ON " +
                          "L.ApplicationID = App.ApplicationID " +
                          "INNER JOIN People P " +
                          "ON App.ApplicantPersonID = P.PersonID";

            // Using View
            string Query3 = "SELECT * FROM DetainedLicenses_View";

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
        public static int AddDetainedLicense(int LicenseID,  Double FineFees, int CreatedByUserID)
        {
            int ID = -1;
            SqlConnection Connection = new SqlConnection((clsDataAccessSettings.ConnectionString));

            string Query = @"INSERT INTO DetainedLicenses (LicenseID, DetainDate,FineFees,CreatedByUserID,IsReleased) 
                                VALUES
                                (@LicenseID, @DetainDate,@FineFees, @CreatedByUserID,0) SELECT SCOPE_IDENTITY();";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@DetainDate", DateTime.Now);
            Command.Parameters.AddWithValue("@FineFees", FineFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);



            try
            {
                Connection.Open();
                object RowAffectedID = Command.ExecuteScalar();

                if (RowAffectedID != null && int.TryParse(RowAffectedID.ToString(), out int InsertedID))
                {
                    ID = InsertedID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }
            return ID;
        }
        public static bool UpdateDetainedLicense(int DetainID,
             int LicenseID, DateTime DetainDate,
             float FineFees, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE dbo.DetainedLicenses
                              SET LicenseID = @LicenseID, 
                              DetainDate = @DetainDate, 
                              FineFees = @FineFees,
                              CreatedByUserID = @CreatedByUserID,   
                              WHERE DetainID=@DetainID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainedLicenseID", DetainID);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


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

        public static bool ReleaseLicense(int DetainID, int ReleasedByUserID, int ReleaseApplicationID)
        {

            Int32 RowsAffected = 0;
            SqlConnection Connection = new SqlConnection((clsDataAccessSettings.ConnectionString));

            string Query = @"UPDATE DetainedLicenses SET IsReleased = 1 ,ReleaseDate = @ReleaseDate ,
                            ReleasedByUserID = @ReleasedByUserID , 
                            ReleaseApplicationID = @ReleaseApplicationID
                            WHERE DetainID = @DetainID";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@DetainID", DetainID);
            Command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);
            Command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            Command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);

            try
            {
                Connection.Open();
                RowsAffected = Command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }
            return (RowsAffected > 0);
        }
        public static bool IsLicenseDetained(int LicenseID)
        {
            bool IsDetained = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select IsDetained=1 
                            from detainedLicenses 
                            where 
                            LicenseID=@LicenseID 
                            and IsReleased=0;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    IsDetained = Convert.ToBoolean(result);
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


            return IsDetained;
            ;

        }

    }
}
