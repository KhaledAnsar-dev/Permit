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
    public class clsDriverData
    {
        public static bool GetDriverByPersonID(ref int DriverID, int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM Drivers WHERE PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if ((Reader.Read()))
                {
                    IsFound = true;

                    DriverID = Convert.ToInt32(Reader["DriverID"]);
                    CreatedByUserID = Convert.ToInt32(Reader["CreatedByUserID"]);
                    CreatedDate = Convert.ToDateTime(Reader["CreatedDate"]);
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

            return IsFound;

        }
        public static bool GetDriverByDriverID(int DriverID,
        ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Drivers WHERE DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];


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
        public static int AddNewDriver(int PersonID, int CreatedByUserID)
        {
            int ID = -1;
            SqlConnection Connection = new SqlConnection((clsDataAccessSettings.ConnectionString));

            string Query = @"INSERT INTO Drivers (PersonID ,CreatedByUserID ,CreatedDate) 
                                VALUES
                                (@PersonID ,@CreatedByUserID ,@CreatedDate) SELECT SCOPE_IDENTITY();";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

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
        public static bool UpdateDriver(int DriverID, int PersonID, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //we dont update the createddate for the driver.
            string query = @"Update  Drivers  
                            set PersonID = @PersonID,
                                CreatedByUserID = @CreatedByUserID
                                where DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
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
        public static DataTable GetAllDrivers()
        {

            DataTable Table = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT D.DriverID AS [Driver ID] , " +
                                "P.PersonID AS [Person ID], " +
                                "P.NationalNo AS No, " +
                                "[Full Name] = P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName , " +
                                "D.CreatedDate AS [Created Date] , " +
                                "(SELECT COUNT(Licenses.LicenseID) FROM Licenses WHERE Licenses.IsActive = 1 AND Licenses.DriverID = D.DriverID) AS  [Active Licenses] " +
                            "FROM Drivers D INNER JOIN People P ON " +
                            "D.PersonID = P.PersonID";

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
 

    }
}
