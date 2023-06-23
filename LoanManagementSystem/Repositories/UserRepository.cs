using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoanManagementSystem.Repositories
{
    internal class UserRepository
    {
        private DBConnection dbConnection;

        public UserRepository(DBConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        // A method that retrieve all the user data and returns a list of User objects
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            try
            {
                dbConnection.Open(); // Invoke method Open() to open the db connection

                SqlCommand cmd = dbConnection.CreateCommand(); // Invoke method CreateCommand() to create a SqlCommand object

                // SQL query for retrieving data from the Users table
                cmd.CommandText = "SELECT * FROM Users";

                // Instance of SqlDataReader object to read the data from the db
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User(); // Create an instance of User object

                    // Assign col values to User attributes
                    user.ID = Convert.ToInt32(reader["user_id"]);
                    user.Username = reader["username"].ToString();
                    user.Password = reader["password"].ToString();
                    user.LastName = reader["last_name"].ToString();
                    user.FirstName = reader["first_name"].ToString();
                    user.Address = reader["address"].ToString();
                    user.Phone = reader["phone"].ToString();
                    user.Email = reader["email"].ToString();

                    users.Add(user); // To add User object to the list
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally { dbConnection.Close(); }

            return users; // Return a list of User objects
        }

        public bool CheckIfExist(User user)
        {
            bool count = false;
            try
            {
                dbConnection.Open();

                SqlCommand cmd = dbConnection.CreateCommand();

                cmd.CommandText = "SELECT COUNT(*) FROM Users WHERE last_name = @last_name AND first_name = @first_name OR username = @username";
                cmd.Parameters.AddWithValue("@last_name", user.LastName);
                cmd.Parameters.AddWithValue("@first_name", user.FirstName);
                cmd.Parameters.AddWithValue("@username", user.Username);

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

        public void Insert(User user)
        {
            try
            {
                dbConnection.Open();

                SqlCommand cmd = dbConnection.CreateCommand();
                cmd.CommandText = "INSERT INTO Users (username, password, last_name, first_name, middle_name, date_of_birth, address, phone, email)" +
                    " VALUES (@username, @password, @last_name, @first_name, @middle_name, @date_of_birth, @address, @phone, @email)";
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@last_name", user.LastName);
                cmd.Parameters.AddWithValue("@first_name", user.FirstName);
                cmd.Parameters.AddWithValue("@middle_name", user.MiddleName);
                cmd.Parameters.AddWithValue("@date_of_birth", user.BirthDate);
                cmd.Parameters.AddWithValue("@address", user.Address);
                cmd.Parameters.AddWithValue("@phone", user.Phone);
                cmd.Parameters.AddWithValue("@email", user.Email);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("You have registered successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else 
                {
                    MessageBox.Show("You have registered unsuccessfully.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show($"Sql Error: {e.Message}");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally { dbConnection.Close(); }
        }
    }
}
