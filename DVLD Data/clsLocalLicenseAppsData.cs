using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public class clsLocalLicenseAppsData
    {
        public static Boolean GetLocalDLAppByLocalDLAppID(int LocalDrivingLicenseApplicationID, ref int ApplicationID, ref int LicenseClassID)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if ((Reader.Read()))
                {
                    IsFound = true;
                    ApplicationID = Convert.ToInt32(Reader["ApplicationID"]);
                    LicenseClassID = Convert.ToInt32(Reader["LicenseClassID"]);
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
        public static Boolean GetLocalDLAppByApplicationID(ref int LocalDrivingLicenseApplicationID, int ApplicationID, ref int LicenseClassID)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM LocalDrivingLicenseApplications WHERE ApplicationID = @ApplicationID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if ((Reader.Read()))
                {
                    IsFound = true;
                    LocalDrivingLicenseApplicationID = Convert.ToInt32(Reader["LocalDrivingLicenseApplicationID"]);
                    LicenseClassID = Convert.ToInt32(Reader["LicenseClassID"]);
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
        public static int AddNewLocalLicenseApp(int ApplicationID, int LicenseClassID)
        {
            int ID = -1;
            SqlConnection Connection = new SqlConnection((clsDataAccessSettings.ConnectionString));

            string Query = @"INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID) 
                                VALUES
                                (@ApplicationID, @LicenseClassID) SELECT SCOPE_IDENTITY();";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
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
        public static bool UpdateLocalLicenseApp(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {

            Int32 RowsAffected = 0;
            SqlConnection Connection = new SqlConnection((clsDataAccessSettings.ConnectionString));

            string Query = @"UPDATE LocalDrivingLicenseApplications SET ApplicationID = @ApplicationID, LicenseClassID = @LicenseClassID  
                            WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
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
        public static bool DeleteLocalLicenseApp(int LocalDrivingLicenseApplicationID)
        {

            Int32 RowsAffected = 0;
            SqlConnection Connection = new SqlConnection((clsDataAccessSettings.ConnectionString));

            string Query = @"DELETE FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
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
        public static DataTable GetAllLocalLicenseApps()
        {
            DataTable Table = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT 
                                 LDLA.LocalDrivingLicenseApplicationID AS LocalLicID,
                                 LC.ClassName AS Class,
                                 People.NationalNo AS NO,
                                 'Full Name' = People.FirstName + ' ' + People.SecondName + ' ' + ISNULL(People.ThirdName,'') + ' ' + People.LastName,
                                 Apps.ApplicationDate,
                                 'Passed Tests' = (
                                     SELECT COUNT(TestID)
                                     FROM Tests T
                                     INNER JOIN TestAppointments TApp ON T.TestAppointmentID = TApp.TestAppointmentID
                                     WHERE TApp.LocalDrivingLicenseApplicationID = LDLA.LocalDrivingLicenseApplicationID 
                                           AND T.TestResult = 1
                                 ),
                                 Status = CASE
                                     WHEN Apps.ApplicationStatus = 1 THEN 'New'
                                     WHEN Apps.ApplicationStatus = 2 THEN 'Canceled'
                                     ELSE 'Completed'
                                 END
                             FROM LocalDrivingLicenseApplications LDLA
                             INNER JOIN LicenseClasses LC ON LDLA.LicenseClassID = LC.LicenseClassID
                             INNER JOIN Applications Apps ON LDLA.ApplicationID = Apps.ApplicationID
                             INNER JOIN People ON Apps.ApplicantPersonID = People.PersonID";

            //string ViewQuery = "SELECT * FROM LicenseAppStatusView";

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
        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool Result = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @" SELECT TOP 1 T.TestResult FROM Tests T 
                              INNER JOIN TestAppointments TA
                              ON T.TestAppointmentID = TA.TestAppointmentID 
                              INNER JOIN LocalDrivingLicenseApplications LDLA
                              ON TA.LocalDrivingLicenseApplicationID = LDLA.LocalDrivingLicenseApplicationID
                              WHERE 
                                    LDLA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
                                    AND TA.TestTypeID = @TestTypeID 
                              ORDER BY TA.TestAppointmentID DESC";

            string query2 = @" SELECT FOUND = 1 FROM Tests T INNER JOIN TestAppointments TA 
                                ON T.TestAppointmentID = TA.TestAppointmentID INNER JOIN LocalDrivingLicenseApplications LDLA
                                ON LDLA.LocalDrivingLicenseApplicationID = TA.LocalDrivingLicenseApplicationID
                                WHERE LDLA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                                AND TA.TestTypeID = @TestTypeID
                                AND T.TestResult = 1";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && bool.TryParse(result.ToString(), out bool returnedResult))
                {
                    Result = returnedResult;
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

            return Result;

        }
        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";



            string query2 = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN Tests
                            ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            AND(TestAppointments.IsLocked = 1)
                            AND(Tests.TestResult = 0)
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query2, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    IsFound = true;
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

            return IsFound;

        }
        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {


            byte TotalTrialsPerTest = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @" SELECT TotalTrialsPerTest = count(TestID)
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                       ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte Trials))
                {
                    TotalTrialsPerTest = Trials;
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

            return TotalTrialsPerTest;

        }
        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {

            bool Result = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)  
                            AND(TestAppointments.TestTypeID = @TestTypeID) and isLocked=0
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null)
                {
                    Result = true;
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

            return Result;

        }

    }
}
