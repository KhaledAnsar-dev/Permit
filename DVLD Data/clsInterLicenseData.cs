using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public class clsInterLicenseData
    {
        public static bool GetInterLicenseByID(int InternationalLicenseID, ref int ApplicationID, ref int DriverID, ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if ((Reader.Read()))
                {
                    IsFound = true;
                    ApplicationID = Convert.ToInt32(Reader["ApplicationID"]);
                    DriverID = Convert.ToInt32(Reader["DriverID"]);
                    IssuedUsingLocalLicenseID = Convert.ToInt32(Reader["IssuedUsingLocalLicenseID"]);
                    IssueDate = Convert.ToDateTime(Reader["IssueDate"]);
                    ExpirationDate = Convert.ToDateTime(Reader["ExpirationDate"]);
                    IsActive = Convert.ToBoolean(Reader["IsActive"]);
                    CreatedByUserID = Convert.ToInt32(Reader["CreatedByUserID"]);
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
        public static int AddNewInterLicense(int ApplicationID, int DriverID , int IssuedUsingLocalLicenseID,DateTime IssueDate , DateTime ExpirationDate , bool IsActive , int CreatedByUserID)
        {
            int ID = -1;
            SqlConnection Connection = new SqlConnection((clsDataAccessSettings.ConnectionString));

            string Query = @" Update InternationalLicenses 
                               set IsActive=0
                               where DriverID=@DriverID; 
                                INSERT INTO InternationalLicenses (ApplicationID, DriverID,IssuedUsingLocalLicenseID,IssueDate,ExpirationDate,IsActive , CreatedByUserID) 
                                VALUES
                                (@ApplicationID, @DriverID,@IssuedUsingLocalLicenseID, @IssueDate,@ExpirationDate, @IsActive,@CreatedByUserID) SELECT SCOPE_IDENTITY();";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            Command.Parameters.AddWithValue("@IssueDate", IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            Command.Parameters.AddWithValue("@IsActive", IsActive);
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
        public static bool UpdateInternationalLicense(
            int InternationalLicenseID, int ApplicationID,
            int DriverID, int IssuedUsingLocalLicenseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE InternationalLicenses
                           SET 
                              ApplicationID=@ApplicationID,
                              DriverID = @DriverID,
                              IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID,
                              IssueDate = @IssueDate,
                              ExpirationDate = @ExpirationDate,
                              IsActive = @IsActive,
                              CreatedByUserID = @CreatedByUserID
                         WHERE InternationalLicenseID=@InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            command.Parameters.AddWithValue("@IsActive", IsActive);
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

        public static DataTable GetAllInternationalLicenses()
        {

            DataTable Table = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT " +
                                "InternationalLicenseID AS [Inter LicenseID], " +
                                "ApplicationID , " +
                                "DriverID , " +
                                "IssuedUsingLocalLicenseID AS [Local LicenseID], " +
                                "IssueDate , " +
                                "ExpirationDate AS [Exp date], " +
                                "IsActive AS Active " +
                            "FROM InternationalLicenses";

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
        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {

            DataTable Table = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT IL.InternationalLicenseID AS [Inter LicID] , " +
                               "IL.IssuedUsingLocalLicenseID AS [Local ID], " +
                               "IL.ApplicationID AS AppID, " +
                               "IL.DriverID AS [Driver ID], " +
                               "IL.IssueDate , " +
                               "IL.ExpirationDate AS [EXP Date], " +
                               "IL.IsActive AS Active " +
                           "FROM InternationalLicenses IL " +                      
                           "WHERE IL.DriverID = @DriverID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@DriverID", DriverID);
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
        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {
            int InternationalLicenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"  
                            SELECT Top 1 InternationalLicenseID
                            FROM InternationalLicenses 
                            where DriverID=@DriverID and GetDate() between IssueDate and ExpirationDate 
                            order by ExpirationDate Desc;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    InternationalLicenseID = insertedID;
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


            return InternationalLicenseID;
        }
    }
}
