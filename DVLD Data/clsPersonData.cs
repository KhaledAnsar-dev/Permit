using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_Data
{
    public class clsPersonData
    {
        public static Boolean GetPersonByID(int ID , ref string NO , ref string FirstName , ref string SecondName , ref string ThirdName , ref string LastName , ref string Phone , ref string Email , ref string Address , ref DateTime DateOfBirth , ref int Country , ref short Gendor , ref string Image)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM People WHERE PersonID = @PersonID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", ID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if((Reader.Read()))
                {
                    IsFound = true;
                    NO = Reader["NationalNO"].ToString();
                    FirstName = Reader["FirstName"].ToString();
                    SecondName = Reader["SecondName"].ToString();

                    if (Reader["ThirdName"] != DBNull.Value)
                        ThirdName = Reader["ThirdName"].ToString();
                    else
                        ThirdName = "";

                    LastName = Reader["LastName"].ToString();
                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    Gendor = Convert.ToInt16(Reader["Gendor"]);
                    Address = Reader["Address"].ToString();
                    Phone = Reader["Phone"].ToString();

                    if (Reader["Email"] != DBNull.Value)
                        Email = Reader["Email"].ToString();
                    else
                        Email = "";

                    Country = (int)Reader["NationalityCountryID"];

                    if(Reader["ImagePath"] != DBNull.Value)
                    {
                        Image = Reader["ImagePath"].ToString();
                    }
                    else
                    {
                        Image = "";
                    }
                }

                else
                {
                    IsFound = false;
                }
                Reader.Close();
            }
            catch(Exception ex) 
            {
                IsFound = false;
            }
            finally 
            {
                Connection.Close();
            }

            return IsFound;
            
        }
        public static Boolean GetPersonByNO(ref int ID, string NO, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref string Phone, ref string Email, ref string Address, ref DateTime DateOfBirth, ref int Country, ref short Gendor, ref string Image)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM People WHERE NationalNO = @NationalNO";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@NationalNO", NO);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if ((Reader.Read()))
                {
                    IsFound = true;
                    ID = Convert.ToInt32(Reader["PersonID"]);
                    FirstName = Reader["FirstName"].ToString();
                    SecondName = Reader["SecondName"].ToString();

                    if (Reader["ThirdName"] != DBNull.Value)
                        ThirdName = Reader["ThirdName"].ToString();
                    else
                        ThirdName = "";

                    LastName = Reader["LastName"].ToString();
                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    Gendor = Convert.ToInt16(Reader["Gendor"]);
                    Address = Reader["Address"].ToString();
                    Phone = Reader["Phone"].ToString();

                    if (Reader["Email"] != DBNull.Value)
                        Email = Reader["Email"].ToString();
                    else
                        Email = "";

                    Country = (int)Reader["NationalityCountryID"];

                    if (Reader["ImagePath"] != DBNull.Value)
                    {
                        Image = Reader["ImagePath"].ToString();
                    }
                    else
                    {
                        Image = "";
                    }
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

        public static int AddNewPerson(string NO, string FirstName, string SecondName, string ThirdName, string LastName, string Phone, string Email, string Address, DateTime DateOfBirth, int Country, short Gendor, string Image)
        {
            int ID = -1;
            SqlConnection Connection = new SqlConnection((clsDataAccessSettings.ConnectionString));

            string Query = @"INSERT INTO People (NationalNO ,FirstName ,SecondName ,ThirdName ,LastName ,Phone ,Email ,Address ,DateOfBirth ,NationalityCountryID ,Gendor ,ImagePath) 
                                VALUES
                                (@NationalNO ,@FirstName ,@SecondName , @ThirdName , @LastName , @Phone , @Email
                                , @Address , @DateOfBirth , @NationalityCountryID , @Gendor , @ImagePath) SELECT SCOPE_IDENTITY();";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@NationalNO", NO);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);

            if (ThirdName != "")
                Command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                Command.Parameters.AddWithValue("@ThirdName", DBNull.Value);

            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@Phone", Phone);

            if (Email != "")
                Command.Parameters.AddWithValue("@Email", Email);
            else
                Command.Parameters.AddWithValue("@Email", DBNull.Value);

            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@NationalityCountryID", Country);
            Command.Parameters.AddWithValue("@Gendor", Gendor);
  


            if (Image != "")
                Command.Parameters.AddWithValue("@ImagePath", Image);
            else
                Command.Parameters.AddWithValue("@ImagePath", DBNull.Value);



            try
            {
                Connection.Open();
                object RowAffectedID = Command.ExecuteScalar();

                if(RowAffectedID != null && int.TryParse(RowAffectedID.ToString() , out int InsertedID))
                {
                    ID = InsertedID;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }
            return ID;
        }
        public static bool UpdatePerson(int ID , string NO, string FirstName, string SecondName, string ThirdName, string LastName, string Phone, string Email, string Address, DateTime DateOfBirth, int Country, short Gendor, string Image)
        {

            Int32 RowsAffected = 0;
            SqlConnection Connection = new SqlConnection((clsDataAccessSettings.ConnectionString));

            string Query = @"UPDATE People SET NationalNO = @NationalNO ,FirstName = @FirstName ,SecondName = @SecondName , 
                            ThirdName = @ThirdName , LastName = @LastName , Phone = @Phone , Email = @Email,
                            Address = @Address , DateOfBirth = @DateOfBirth , 
                            NationalityCountryID = @NationalityCountryID , Gendor = @Gendor , ImagePath = @ImagePath 
                            WHERE PersonID = @PersonID";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", ID);
            Command.Parameters.AddWithValue("@NationalNO", NO);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);

            if (ThirdName != "")
                Command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                Command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@Phone", Phone);

            if (Email != "")
                Command.Parameters.AddWithValue("@Email", Email);
            else
                Command.Parameters.AddWithValue("@Email", DBNull.Value);

            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@NationalityCountryID", Country);
            Command.Parameters.AddWithValue("@Gendor", Gendor);

            if (Image != "")
                Command.Parameters.AddWithValue("@ImagePath", Image);
            else
                Command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
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
        public static bool DeletePerson(int ID)
        {

            Int32 RowsAffected = 0;
            SqlConnection Connection = new SqlConnection((clsDataAccessSettings.ConnectionString));

            string Query = @"DELETE FROM People WHERE PersonID = @PersonID";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", ID);
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
        public static DataTable GetAllPeople()
        {

            DataTable Table = new DataTable();  

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query =
              @"SELECT People.PersonID, People.NationalNo,
              People.FirstName, People.SecondName, People.ThirdName, People.LastName,
			  People.DateOfBirth, People.Gendor,  
				  CASE
                  WHEN People.Gendor = 0 THEN 'Male'

                  ELSE 'Female'

                  END as GendorCaption ,
			  People.Address, People.Phone, People.Email, 
              People.NationalityCountryID, Countries.CountryName, People.ImagePath
              FROM            People INNER JOIN
                         Countries ON People.NationalityCountryID = Countries.CountryID
                ORDER BY People.FirstName";

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
        public static Boolean DoesPersonExists(int ID)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT Found = 1 FROM People WHERE PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", ID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                IsFound = Reader.HasRows;

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
        public static Boolean DoesPersonNOExists(string NO)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT Found = 1 FROM People WHERE NationalNO = @NationalNO";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@NationalNO", NO);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                IsFound = Reader.HasRows;

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
      
        public static DataTable Filter_DateOfBirth(DateTime Start , DateTime End)
        {

            DataTable Table = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT PersonID , NationalNO , FirstName , SecondName ,ThirdName , LastName , Email , Phone FROM People WHERE DateOfBirth BETWEEN @Start AND @End";

            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("@Start", Start);
            Command.Parameters.AddWithValue("@End", End);

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
