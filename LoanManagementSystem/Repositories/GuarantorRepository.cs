using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoanManagementSystem.Repositories
{
    internal class GuarantorRepository
    {
        // Private field which represents a database connection
        private DBConnection dbConnection;

        // Parameterized constructor that accepts a DbConnection object as a parameter
        // used to initialized the dbConnection field with the provided DBConnection object
        public GuarantorRepository(DBConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        // A method that retrieves all the guarantors data and return as a list of Guarantor object
        public List<Guarantor> GetGuarantors()
        {
            List<Guarantor> guarantors = new List<Guarantor>();

            try
            {
                dbConnection.Open(); // Invoke method Open() from dbConnection class to establish a database connection

                SqlCommand cmd = dbConnection.CreateCommand(); // Invoke method CreateCommand() to create a SqlCommand Object

                // Set the SQL query for retrieving data from the Guarantors table
                cmd.CommandText = "SELECT * FROM Guarantors";

                // Create an instance of SqlDataReader to read the data from the database
                SqlDataReader reader = cmd.ExecuteReader();

                // Iterate through each row while there is a row in the Guarantors table
                while (reader.Read())
                {
                    // Create an instance of Guarantor object where each col of a row from the db will be stored
                    Guarantor guarantor = new Guarantor();

                    // Assign column values to Guarantor attributes
                    guarantor.ID = Convert.ToInt32(reader["guarantor_id"]);
                    guarantor.GuarantorType = reader["guarantor_type"].ToString();
                    guarantor.LastName = reader["last_name"].ToString();
                    guarantor.FirstName = reader["first_name"].ToString();
                    guarantor.MiddleName = reader["middle_name"].ToString();
                    guarantor.BirthDate = Convert.ToDateTime(reader["date_of_birth"].ToString());
                    guarantor.Address = reader["address"].ToString();
                    guarantor.Phone = reader["phone"].ToString();
                    guarantor.Email = reader["email"].ToString();

                    guarantors.Add(guarantor); // To add Guarantor object to the list
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show($"Database error: {e.Message}"); // Exception handling specific to Sql-related errors
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
            finally
            {
                dbConnection.Close(); // Invoke method Close() from dbConnection class to terminate database connection
            }

            return guarantors; // return a list of guarantor objects
        }

        public bool CheckIfExist(Guarantor guarantor)
        {
            bool count = false;
            try
            {
                dbConnection.Open();

                SqlCommand cmd = dbConnection.CreateCommand();

                cmd.CommandText = "SELECT COUNT(*) FROM Guarantors WHERE last_name = @last_name AND first_name = @first_name";
                cmd.Parameters.AddWithValue("@last_name", guarantor.LastName);
                cmd.Parameters.AddWithValue("@first_name", guarantor.FirstName);

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

        // A method to insert a new record in the database table
        public void Insert(Guarantor guarantor)
        {
            try
            {
                dbConnection.Open(); // Invoke method Open() from dbConnection class to establish a database connection

                SqlCommand cmd = dbConnection.CreateCommand(); // Invoke method CreateCommand() from dbConnection class to create a SqlCommand object

                // A query to insert data in the database
                cmd.CommandText = "INSERT INTO Guarantors (last_name, first_name, middle_name, date_of_birth, address, phone, email, guarantor_type) VALUES (@last_name, @first_name, @middle_name, @date_of_birth, @address, @phone, @email, @guarantor_type)";

                // Set parameter values for the insert query
                // '@last_id', etc... placeholders correspond with the respective properties of the Guarantor object
                cmd.Parameters.AddWithValue("@last_name", guarantor.LastName);
                cmd.Parameters.AddWithValue("@first_name", guarantor.FirstName);
                cmd.Parameters.AddWithValue("@middle_name", guarantor.MiddleName);
                cmd.Parameters.AddWithValue("@date_of_birth", guarantor.BirthDate);
                cmd.Parameters.AddWithValue("@address", guarantor.Address);
                cmd.Parameters.AddWithValue("@phone", guarantor.Phone);
                cmd.Parameters.AddWithValue("@email", guarantor.Email);
                cmd.Parameters.AddWithValue("@guarantor_type", guarantor.GuarantorType);

                // Execute the query
                int rowsAffected = cmd.ExecuteNonQuery();

                // if rowsAffected is greater than 0, the data is successfully added
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
        public void Update(Guarantor guarantor)
        {
            try
            {
                dbConnection.Open(); // Invoke method Open() from dbConnection class to establish a database connection

                SqlCommand cmd = dbConnection.CreateCommand(); // Invoke method CreateCommand() from dbConnection class to create a SqlCommand object

                // A query update existing data in the database table, where guarantor_id is used to identify the specific guarantor to update
                cmd.CommandText = "UPDATE Guarantors SET guarantor_type = @guarantor_type, last_name = @last_name, first_name = @first_name, middle_name = @middle_name, date_of_birth = @date_of_birth, address = @address, phone = @phone, email = @email WHERE guarantor_id = @guarantor_id";

                // Set parameter values for the update query
                // '@guarantor_type', etc... placeholders correspond with the respective properties of the Guarantor object
                cmd.Parameters.AddWithValue("@guarantor_type", guarantor.GuarantorType);
                cmd.Parameters.AddWithValue("@last_name", guarantor.LastName);
                cmd.Parameters.AddWithValue("@first_name", guarantor.FirstName);
                cmd.Parameters.AddWithValue("@middle_name", guarantor.MiddleName);
                cmd.Parameters.AddWithValue("@date_of_birth", guarantor.BirthDate);
                cmd.Parameters.AddWithValue("@address", guarantor.Address);
                cmd.Parameters.AddWithValue("@phone", guarantor.Phone);
                cmd.Parameters.AddWithValue("@email", guarantor.Email);
                cmd.Parameters.AddWithValue("@guarantor_id", guarantor.ID);

                // Execute the query
                int rowsAffected = cmd.ExecuteNonQuery();

                // if rowsAffected is greater than 0, the data is updated successfully
                // Otherwise, data update failed
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Record updated successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Record updated unsuccessfully", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show($"Database error: {e.Message}"); // Separate catch block for SqlException so that we can determine specific Sql-related erros
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

        // A method to delete existing record in the database
        public void Delete(Guarantor guarantor)
        {
            try
            {
                dbConnection.Open(); // Invoke method Open() from dbConnection class to establish a database connection

                SqlCommand cmd = dbConnection.CreateCommand(); // Invoke method CreateCommand() from dbConnection class to create a SqlCommand object

                // A query to remove existing record in the database table, where guarantor_id is used to identify the specific guarantor to remove
                cmd.CommandText = "DELETE FROM Guarantors WHERE guarantor_id = @guarantor_id";

                // Set parameter value for the delete query
                // '@guarantor_id' placeholder correspond with the respective property of the Guarantor Object
                cmd.Parameters.AddWithValue("@guarantor_id", guarantor.ID);

                // Execute the query
                int rowsAffected = cmd.ExecuteNonQuery();

                // if rowsAffected is greater than 0, the data is deleted successfully
                if (rowsAffected > 0 )
                {
                    MessageBox.Show("Record deleted successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
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

        public List<Guarantor> GetFilteredGuarantors(int value)
        {
            List<Guarantor> filteredResult = new List<Guarantor>(); // Create an empty list of Guarantor object

            try
            {
                dbConnection.Open(); // To establish db conn

                SqlCommand cmd = dbConnection.CreateCommand();

                // A query to search in the database table
                cmd.CommandText = "SELECT * FROM Guarantors " +
                    "WHERE guarantor_id = @value";

                // Set parameter value for search query
                cmd.Parameters.AddWithValue("@value", value);

                // Create an instance of SqlDataReader to read the data from the database
                SqlDataReader reader = cmd.ExecuteReader();

                // Iterate through each row while there is a row in the Guarantors table
                while (reader.Read())
                {
                    // Create an instance of Guarantor object where each col of a row from the db will be stored
                    Guarantor guarantor = new Guarantor();

                    // Assign column values to Guarantor attributes
                    guarantor.ID = Convert.ToInt32(reader["guarantor_id"]);
                    guarantor.GuarantorType = reader["guarantor_type"].ToString();
                    guarantor.LastName = reader["last_name"].ToString();
                    guarantor.FirstName = reader["first_name"].ToString();
                    guarantor.MiddleName = reader["middle_name"].ToString();
                    guarantor.BirthDate = Convert.ToDateTime(reader["date_of_birth"].ToString());
                    guarantor.Address = reader["address"].ToString();
                    guarantor.Phone = reader["phone"].ToString();
                    guarantor.Email = reader["email"].ToString();

                    filteredResult.Add(guarantor); // To add Guarantor object to the list
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show($"Database error: {e.Message}"); // Exception handling specific to Sql-related errors
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
            finally
            {
                dbConnection.Close(); // Invoke method Close() from dbConnection class to terminate database connection
            }

            return filteredResult;
        }

        public List<Guarantor> GetFilteredGuarantors(string value)
        {
            List<Guarantor> filteredResult = new List<Guarantor>(); // Create an empty list of Guarantor object

            try
            {
                dbConnection.Open(); // To establish db conn

                SqlCommand cmd = dbConnection.CreateCommand();

                // A query to search in the database table
                cmd.CommandText = "SELECT * FROM Guarantors " +
                    "WHERE CONCAT(last_name, ' ', first_name, ' ', middle_name) LIKE '%' + @value + '%'";

                // Set parameter value for search query
                cmd.Parameters.AddWithValue("@value", value);

                // Create an instance of SqlDataReader to read the data from the database
                SqlDataReader reader = cmd.ExecuteReader();

                // Iterate through each row while there is a row in the Guarantors table
                while (reader.Read())
                {
                    // Create an instance of Guarantor object where each col of a row from the db will be stored
                    Guarantor guarantor = new Guarantor();

                    // Assign column values to Guarantor attributes
                    guarantor.ID = Convert.ToInt32(reader["guarantor_id"]);
                    guarantor.GuarantorType = reader["guarantor_type"].ToString();
                    guarantor.LastName = reader["last_name"].ToString();
                    guarantor.FirstName = reader["first_name"].ToString();
                    guarantor.MiddleName = reader["middle_name"].ToString();
                    guarantor.BirthDate = Convert.ToDateTime(reader["date_of_birth"].ToString());
                    guarantor.Address = reader["address"].ToString();
                    guarantor.Phone = reader["phone"].ToString();
                    guarantor.Email = reader["email"].ToString();

                    filteredResult.Add(guarantor); // To add Guarantor object to the list
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show($"Database error: {e.Message}"); // Exception handling specific to Sql-related errors
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
            finally
            {
                dbConnection.Close(); // Invoke method Close() from dbConnection class to terminate database connection
            }

            return filteredResult;
        }
    }
}