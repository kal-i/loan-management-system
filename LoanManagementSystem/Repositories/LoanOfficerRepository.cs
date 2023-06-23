using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoanManagementSystem
{
    internal class LoanOfficerRepository
    {
        private DBConnection dbConnection;

        public LoanOfficerRepository(DBConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        // A method that retrieves all the loan officers data and return as a list of LoanOfficer object
        public List<LoanOfficer> GetOfficers() 
        {
            List<LoanOfficer> officers = new List<LoanOfficer>();

            try
            {
                dbConnection.Open(); // Invoke method Open() to establish the database connection

                SqlCommand cmd = dbConnection.CreateCommand(); // Invoke method  CreateCommand() to create a SqlCommand Object

                // A query for retrieving data from the LoanOfficers table
                cmd.CommandText = "SELECT * FROM LoanOfficers";

                // Create an instance of SqlDataReader to read the data from  the database
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LoanOfficer officer = new LoanOfficer(); // Create an instance of LoanOfficer object where each col of a row from the db will be stored

                    // Assign column values to LoanOfficer attributes
                    officer.ID = Convert.ToInt32(reader["officer_id"]);
                    officer.LastName = reader["last_name"].ToString();
                    officer.FirstName = reader["first_name"].ToString();
                    officer.MiddleName = reader["middle_name"].ToString();
                    officer.BirthDate = Convert.ToDateTime(reader["date_of_birth"].ToString());
                    officer.Address = reader["address"].ToString();
                    officer.Phone = reader["phone"].ToString();
                    officer.Email = reader["email"].ToString();

                    officers.Add(officer); // To add Loan Officer object to the list
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show($"Database error: {e.Message}"); // Separate catch block for SqlException so that we can determine specific Sql-related errors
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
            finally
            {
                dbConnection.Close(); // Invoke method Close() to terminate the database connection
            }

            return officers; // return a list of officer objects
        }

        public bool CheckIfExist(LoanOfficer officer)
        {
            bool count = false;
            try
            {
                dbConnection.Open();

                SqlCommand cmd = dbConnection.CreateCommand();

                cmd.CommandText = "SELECT COUNT(*) FROM LoanOfficers WHERE last_name = @last_name AND first_name = @first_name";
                cmd.Parameters.AddWithValue("@last_name", officer.LastName);
                cmd.Parameters.AddWithValue("@first_name", officer.FirstName);

                count = (int)cmd.ExecuteScalar() > 0 ? true : false;
            }
            catch (SqlException e)
            {
                MessageBox.Show($"{e.Message}");
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message}");
            }
            finally { dbConnection.Close(); }

            return count;
        }

        // A method to insert a Loan Officer in the database
        public void Insert(LoanOfficer officer)
        {
            try
            {
                dbConnection.Open(); // Invoke method Open() from dbConnection class to establish database connection

                SqlCommand cmd = dbConnection.CreateCommand(); // Invoke method CreateCommand() from dbConnection class to create a SqlCommand object

                // A query to insert data in the database
                cmd.CommandText = "INSERT INTO LoanOfficers (last_name, first_name, middle_name, date_of_birth, address, phone, email) VALUES (@last_name, @first_name, @middle_name, @date_of_birth, @address, @phone, @email)";

                // Set parameter values
                cmd.Parameters.AddWithValue("@last_name", officer.LastName);
                cmd.Parameters.AddWithValue("@first_name", officer.FirstName);
                cmd.Parameters.AddWithValue("@middle_name", officer.MiddleName);
                cmd.Parameters.AddWithValue("@date_of_birth", officer.BirthDate);
                cmd.Parameters.AddWithValue("@address", officer.Address);
                cmd.Parameters.AddWithValue("@phone", officer.Phone);
                cmd.Parameters.AddWithValue("@email", officer.Email);

                // Execute the query
                int rowsAffected = cmd.ExecuteNonQuery();

                // if rowsAffected is greater than 0, the data is added successfully
                // Otherwise, data insertion failed
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Record added successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Record added unsuccessfully.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show($"Database error: {e.Message}"); // Separate catch block for SqlException so that we can determine specific Sql-related errors
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
            finally
            {
                dbConnection.Close(); // Invoke method Close() from dbConnection class to terminate the database connection
            }
        }

        // A method to update existing record in the database
        public void Update(LoanOfficer officer)
        {
            try
            {
                dbConnection.Open(); // Invoke method Open() from dbConnection class to establish database connection

                SqlCommand cmd = dbConnection.CreateCommand(); // Invoke method CreateCommand() from dbConnection class to create a SqlCommand object

                // A query to update existing data in the database table, where officer_id is used to identify the specific loan officer to update
                cmd.CommandText = "UPDATE LoanOfficers SET last_name = @last_name, first_name = @first_name, middle_name = @middle_name, date_of_birth = @date_of_birth, address = @address, phone = @phone, email = @email WHERE officer_id = @officer_id";

                // Set parameter values for the update query
                // '@last_id', etc... placeholders correspond with the respective properties of the LoanOfficer object
                cmd.Parameters.AddWithValue("@last_name", officer.LastName);
                cmd.Parameters.AddWithValue("@first_name", officer.FirstName);
                cmd.Parameters.AddWithValue("@middle_name", officer.MiddleName);
                cmd.Parameters.AddWithValue("@date_of_birth", officer.BirthDate);
                cmd.Parameters.AddWithValue("@address", officer.Address);
                cmd.Parameters.AddWithValue("@phone", officer.Phone);
                cmd.Parameters.AddWithValue("@email", officer.Email);
                cmd.Parameters.AddWithValue("@officer_id", officer.ID);

                // Execute the query
                int rowsAffected = cmd.ExecuteNonQuery();

                // If rowsAffected is greater than 0, the data is updated successfully
                // Otherwise, data update failed
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Record updated successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Record updated unsuccessfully.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } 
            catch (SqlException e)
            {
                MessageBox.Show($"Database error: {e.Message}"); // Separate catch block for SqlException so that we can determine specific Sql-related errors
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
            finally
            {
                dbConnection.Close(); // Invoke method Close() from dbConnection class to terminate the database connection
            }
        }

        // A method to remove existing record in the database
        public void Delete(LoanOfficer officer)
        {
            try
            {
                dbConnection.Open(); // Invoke method Open() from dbConnection class to establish a database connection

                SqlCommand cmd = dbConnection.CreateCommand(); // Invoke method CreateCommand() from dbConnection class to create a SqlCommand object

                // A query to remove existing record in the database table, where officer_id is used to identify the specific loan officer to remove
                cmd.CommandText = "DELETE FROM LoanOfficers WHERE officer_id = @officer_id";

                // Set parameter value for the delete query
                // '@officer_id' placeholder correspond with the respective property of the LoanOfficer object
                cmd.Parameters.AddWithValue("@officer_id", officer.ID);

                // Execute the query
                int rowsAffected = cmd.ExecuteNonQuery();

                // If rowsAffected is greater than 0, the data is deleted successfully
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Record deleted successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show($"Database Error: {e.Message}"); // Separate catch block for SqlException so that we can determine specific Sql-related errors
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
            finally
            {
                dbConnection.Close(); // Invoke method Close() from dbConnection class to terminate the database connection
            }
        }

        public List<LoanOfficer> GetFilteredOfficers(int value)
        {
            List<LoanOfficer> filteredResult = new List<LoanOfficer>();

            try
            {
                dbConnection.Open(); // Invoke method Open() to establish the database connection

                SqlCommand cmd = dbConnection.CreateCommand(); // Invoke method  CreateCommand() to create a SqlCommand Object

                // A query for retrieving data from the LoanOfficers table
                cmd.CommandText = "SELECT * FROM LoanOfficers " +
                    "WHERE officer_id = @value";

                // Set parameter value for search query
                cmd.Parameters.AddWithValue("@value", value);

                // Create an instance of SqlDataReader to read the data from  the database
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LoanOfficer officer = new LoanOfficer(); // Create an instance of LoanOfficer object where each col of a row from the db will be stored

                    // Assign column values to LoanOfficer attributes
                    officer.ID = Convert.ToInt32(reader["officer_id"]);
                    officer.LastName = reader["last_name"].ToString();
                    officer.FirstName = reader["first_name"].ToString();
                    officer.MiddleName = reader["middle_name"].ToString();
                    officer.BirthDate = Convert.ToDateTime(reader["date_of_birth"].ToString());
                    officer.Address = reader["address"].ToString();
                    officer.Phone = reader["phone"].ToString();
                    officer.Email = reader["email"].ToString();

                    filteredResult.Add(officer); // To add Loan Officer object to the list
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show($"Database error: {e.Message}"); // Separate catch block for SqlException so that we can determine specific Sql-related errors
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
            finally
            {
                dbConnection.Close(); // Invoke method Close() to terminate the database connection
            }

            return filteredResult; // return a list of officer objects
        }

        public List<LoanOfficer> GetFilteredOfficers(string value)
        {
            List<LoanOfficer> filteredResult = new List<LoanOfficer>();

            try
            {
                dbConnection.Open(); // Invoke method Open() to establish the database connection

                SqlCommand cmd = dbConnection.CreateCommand(); // Invoke method  CreateCommand() to create a SqlCommand Object

                // A query for retrieving data from the LoanOfficers table
                cmd.CommandText = "SELECT * FROM LoanOfficers " +
                    "WHERE CONCAT(last_name, ' ', first_name, ' ', middle_name) LIKE '%' + @value + '%'";

                // Set parameter value for search query
                cmd.Parameters.AddWithValue("@value", value);

                // Create an instance of SqlDataReader to read the data from  the database
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LoanOfficer officer = new LoanOfficer(); // Create an instance of LoanOfficer object where each col of a row from the db will be stored

                    // Assign column values to LoanOfficer attributes
                    officer.ID = Convert.ToInt32(reader["officer_id"]);
                    officer.LastName = reader["last_name"].ToString();
                    officer.FirstName = reader["first_name"].ToString();
                    officer.MiddleName = reader["middle_name"].ToString();
                    officer.BirthDate = Convert.ToDateTime(reader["date_of_birth"].ToString());
                    officer.Address = reader["address"].ToString();
                    officer.Phone = reader["phone"].ToString();
                    officer.Email = reader["email"].ToString();

                    filteredResult.Add(officer); // To add Loan Officer object to the list
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show($"Database error: {e.Message}"); // Separate catch block for SqlException so that we can determine specific Sql-related errors
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
            finally
            {
                dbConnection.Close(); // Invoke method Close() to terminate the database connection
            }

            return filteredResult; // return a list of officer objects
        }
    }
}
