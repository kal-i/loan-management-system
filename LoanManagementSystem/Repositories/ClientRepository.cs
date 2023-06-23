using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace LoanManagementSystem.ViewController
{
    internal class ClientRepository
    {
        // private field which represents a database connection
        private DBConnection dbConnection;

        // Parameterized constructor that accepts a DBConnection object as a parameter
        // used to initialized the dbConnection field with the provided DBConnection object
        public ClientRepository(DBConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        // A method that retrieves all the client data and return as a list of Client object
        public List<Client> GetClients()
        {
            List<Client> clients = new List<Client>();

            try
            {
                dbConnection.Open(); // Invoke method Open() from dbConnection class to establish a database connection

                SqlCommand cmd = dbConnection.CreateCommand(); // Invoke method CreateCommand() from dbConnection class to create a SqlCommand object

                // Set the SQL query for retrieving data from the Clients table and ClientsFinancial table
                // Used the INNER JOIN to returns rows that gave matching values in both tables
                cmd.CommandText = "SELECT Clients.*, ClientFinancials.*, ClientEmployment.* FROM Clients" +
                    " INNER JOIN ClientFinancials ON Clients.client_id = ClientFinancials.client_id" +
                    " INNER JOIN ClientEmployment ON Clients.client_id = ClientEmployment.client_id";

                // Create an instance of SqlDataReader to read the data from the database
                SqlDataReader reader = cmd.ExecuteReader();

                // Iterate through each row while there is a row in the Clients and ClientFinancials table
                while (reader.Read())
                {
                    // Crate an instance of Client object where each col from the db will be stored
                    Client client = new Client();

                    // Assign col values to Client attributes
                    client.ID = Convert.ToInt32(reader["client_id"]);
                    client.LastName = reader["last_name"].ToString();
                    client.FirstName = reader["first_name"].ToString();
                    client.MiddleName = reader["middle_name"].ToString();
                    client.BirthDate = Convert.ToDateTime(reader["date_of_birth"].ToString());
                    client.Address = reader["address"].ToString();
                    client.Phone = reader["phone"].ToString();
                    client.Email = reader["email"].ToString();
                    client.EmploymentId = Convert.ToInt32(reader["employment_id"]);
                    client.EmployerName = reader["employer_name"].ToString();
                    client.JobTitle = reader["job_title"].ToString();
                    client.EmploymentStartDate = Convert.ToDateTime(reader["employment_start_date"]);
                    client.EmploymentStatus = reader["employment_status"].ToString();
                    client.IncomeAmount = Convert.ToDouble(reader["income_amount"]);
                    client.IncomeFrequency = reader["income_frequency"].ToString();
                    client.FinancialID = Convert.ToInt32(reader["financials_id"]);
                    client.AnnualIncome = Convert.ToDouble(reader["annual_income"]);
                    client.IncomeSource = reader["income_source"].ToString();
                    client.ExpensesAmount = Convert.ToDouble(reader["expenses_amount"]);
                    client.TotalAssets = Convert.ToDouble(reader["asset_value"]);
                    client.TotalLiabilities = Convert.ToDouble(reader["liabilities_amount"]);
                    client.CreditScore = Convert.ToInt32(reader["credit_score"]);
                    client.CreditHistory = reader["credit_history"].ToString();

                    clients.Add(client); // To add Client object to the list
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show($"Database error: {e.Message}"); // Separate catch block to specifically determine Sql-related errors
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
            finally
            {
                dbConnection.Close(); // Invoke method Close() from dbConnection class to terminate the database connection
            }

            return clients; // return a list of client objects
        }

        public int GetNumberOfClients()
        {
            int count = 0;

            try
            {
                dbConnection.Open(); // Establish db connection

                SqlCommand cmd = dbConnection.CreateCommand();

                cmd.CommandText = "SELECT COUNT(*) FROM Clients";

                // ExecuteScalar() is used to retrieve a single value (in this case, the count)
                object result = cmd.ExecuteScalar();

                // Check if the result is not null and can be converted to an integer
                if (result != null && int.TryParse(result.ToString(), out int rowCount))
                {
                    count = rowCount;
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
                dbConnection.Close(); // Close db connection
            }

            return count;
        }

        public bool CheckIfExist(Client client)
        {
            bool count = false;
            try
            {
                dbConnection.Open();

                SqlCommand cmd = dbConnection.CreateCommand();

                cmd.CommandText = "SELECT COUNT(*) FROM Clients WHERE last_name = @last_name AND first_name = @first_name";
                cmd.Parameters.AddWithValue("@last_name", client.LastName);
                cmd.Parameters.AddWithValue("@first_name", client.FirstName);

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

        // A method to insert a new client in the database table
        public void Insert(Client client)
        {
            try
            {
                dbConnection.Open(); // Invoke method Open() from dbConnection class to establish a database connection

                SqlCommand clientCmd = dbConnection.CreateCommand(); // Invoke method CreateCommand() from dbConnection class to create a SqlCommand object

                // A query to insert data in the database
                clientCmd.CommandText = "INSERT INTO Clients (last_name, first_name, middle_name, date_of_birth, address, email, phone)" +
                    "OUTPUT INSERTED.client_id" +
                    " VALUES (@last_name, @first_name, @middle_name, @date_of_birth, @address, @email, @phone)";

                // Set parameter values for the insert query
                // '@last_name', etc... placeholders correspond with the respective properties of the Client object
                clientCmd.Parameters.AddWithValue("@last_name", client.LastName);
                clientCmd.Parameters.AddWithValue("@first_name", client.FirstName);
                clientCmd.Parameters.AddWithValue("@middle_name", client.MiddleName);
                clientCmd.Parameters.AddWithValue("@date_of_birth", client.BirthDate);
                clientCmd.Parameters.AddWithValue("@address", client.Address);
                clientCmd.Parameters.AddWithValue("@phone", client.Phone);
                clientCmd.Parameters.AddWithValue("@email", client.Email);

                // Retrieve the primary key of the inserted
                // Then assign the retrieved value to client ID property, which will be used as fk when inserting client financial info
                client.ID = Convert.ToInt32(clientCmd.ExecuteScalar());

                clientCmd.Dispose(); // Dispose the client command

                SqlCommand employmentCmd = dbConnection.CreateCommand();

                employmentCmd.CommandText = "INSERT INTO ClientEmployment (client_id, employer_name, job_title, employment_start_date, employment_status, income_amount, income_frequency) VALUES (@client_id, @employer_name, @job_title, @employment_start_date, @employment_status, @income_amount, @income_frequency)";

                employmentCmd.Parameters.AddWithValue("@client_id", client.ID);
                employmentCmd.Parameters.AddWithValue("@employer_name", client.EmployerName);
                employmentCmd.Parameters.AddWithValue("@job_title", client.JobTitle);
                employmentCmd.Parameters.AddWithValue("@employment_start_date", client.EmploymentStartDate);
                employmentCmd.Parameters.AddWithValue("@employment_status", client.EmploymentStatus);
                employmentCmd.Parameters.AddWithValue("@income_amount", client.IncomeAmount);
                employmentCmd.Parameters.AddWithValue("@income_frequency", client.IncomeFrequency);

                employmentCmd.ExecuteNonQuery();

                employmentCmd.Dispose();

                SqlCommand financialCmd = dbConnection.CreateCommand();

                // A query to insert in the ClientFinancial table
                financialCmd.CommandText = "INSERT INTO ClientFinancials (client_id, annual_income, income_source, expenses_amount, asset_value, liabilities_amount, credit_score) VALUES (@client_id, @annual_income, @income_source, @expenses_amount, @asset_value, @liabilities_amount, @credit_score)";

                // Set parameter values
                financialCmd.Parameters.AddWithValue("@client_id", client.ID);
                financialCmd.Parameters.AddWithValue("@annual_income", client.AnnualIncome);
                financialCmd.Parameters.AddWithValue("@income_source", client.IncomeSource);
                financialCmd.Parameters.AddWithValue("@expenses_amount", client.ExpensesAmount);
                financialCmd.Parameters.AddWithValue("@asset_value", client.TotalAssets);
                financialCmd.Parameters.AddWithValue("@liabilities_amount", client.TotalLiabilities);
                financialCmd.Parameters.AddWithValue("@credit_score", client.CreditScore);

                int rowsAffected = financialCmd.ExecuteNonQuery();

                financialCmd.Dispose();

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

        // A method to update an existing record in the database
        public void Update(Client client)
        {
            try
            {
                dbConnection.Open(); // Establish a database connection

                // Update the client information
                SqlCommand clientCmd = dbConnection.CreateCommand();
                clientCmd.CommandText = "UPDATE Clients SET last_name = @last_name, first_name = @first_name, middle_name = @middle_name, date_of_birth = @date_of_birth, address = @address, phone = @phone, email = @email WHERE client_id = @client_id";
                clientCmd.Parameters.AddWithValue("@last_name", client.LastName);
                clientCmd.Parameters.AddWithValue("@first_name", client.FirstName);
                clientCmd.Parameters.AddWithValue("@middle_name", client.MiddleName);
                clientCmd.Parameters.AddWithValue("@date_of_birth", client.BirthDate);
                clientCmd.Parameters.AddWithValue("@address", client.Address);
                clientCmd.Parameters.AddWithValue("@phone", client.Phone);
                clientCmd.Parameters.AddWithValue("@email", client.Email);
                clientCmd.Parameters.AddWithValue("@client_id", client.ID);
                clientCmd.ExecuteNonQuery();
                clientCmd.Dispose();

                // Update the client employment information
                SqlCommand employmentCmd = dbConnection.CreateCommand();
                employmentCmd.CommandText = "UPDATE ClientEmployment SET employer_name = @employer_name, job_title = @job_title, employment_start_date = @employment_start_date, employment_status = @employment_status, income_amount = @income_amount, income_frequency = @income_frequency WHERE employment_id = @employment_id";
                employmentCmd.Parameters.AddWithValue("@employer_name", client.EmployerName);
                employmentCmd.Parameters.AddWithValue("@job_title", client.JobTitle);
                employmentCmd.Parameters.AddWithValue("@employment_start_date", client.EmploymentStartDate);
                employmentCmd.Parameters.AddWithValue("@employment_status", client.EmploymentStatus);
                employmentCmd.Parameters.AddWithValue("@income_amount", client.IncomeAmount);
                employmentCmd.Parameters.AddWithValue("@income_frequency", client.IncomeFrequency);
                employmentCmd.Parameters.AddWithValue("@employment_id", client.EmploymentId);
                employmentCmd.ExecuteNonQuery();
                employmentCmd.Dispose();

                // Update the client financial information
                SqlCommand financialCmd = dbConnection.CreateCommand();
                financialCmd.CommandText = "UPDATE ClientFinancials SET annual_income = @annual_income, income_source = @income_source, expenses_amount = @expenses_amount, asset_value = @asset_value, liabilities_amount = @liabilities_amount, credit_score = @credit_score WHERE financials_id = @financials_id";
                financialCmd.Parameters.AddWithValue("@annual_income", client.AnnualIncome);
                financialCmd.Parameters.AddWithValue("@income_source", client.IncomeSource);
                financialCmd.Parameters.AddWithValue("@expenses_amount", client.ExpensesAmount);
                financialCmd.Parameters.AddWithValue("@asset_value", client.TotalAssets);
                financialCmd.Parameters.AddWithValue("@liabilities_amount", client.TotalLiabilities);
                financialCmd.Parameters.AddWithValue("@credit_score", client.CreditScore);
                financialCmd.Parameters.AddWithValue("@financials_id", client.FinancialID);
                int rowsAffected = financialCmd.ExecuteNonQuery();
                financialCmd.Dispose();

                // Check if the update was successful
                // Otherwise, the update was unsuccessful
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Record updated successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information); 
                }
                else
                {
                    MessageBox.Show("Record updated unsuccessfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error"); // Separate catch block to catch Sql-related exceptions
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
            finally
            {
                dbConnection.Close(); // Terminate the database connection
            }
        }

        public void Delete(Client client)
        {
            try
            {
                dbConnection.Open(); // Invoke method Open() from dbConnection class to establish a database connection

                SqlCommand financialCmd = dbConnection.CreateCommand(); // Invoke method CreateCommand() from dbConnection class to create a SqlCommand object

                // A query to remove existing record in the database table, where client_id is used to identify the specific client to remove
                // Delete associated records from various table b4 removing the main record
                // '@client_id' placeholder correspond with the respective property of the Client Object
                financialCmd.CommandText = "DELETE FROM ClientFinancials WHERE client_id = @client_id";
                financialCmd.Parameters.AddWithValue("@client_id", client.ID);
                financialCmd.ExecuteNonQuery();
                financialCmd.Dispose(); 

                SqlCommand employmentCmd = dbConnection.CreateCommand();
                employmentCmd.CommandText = "DELETE FROM ClientEmployment WHERE client_id = @client_id";
                employmentCmd.Parameters.AddWithValue("@client_id", client.ID);
                employmentCmd.ExecuteNonQuery();
                employmentCmd.Dispose(); 

                SqlCommand loanApplicationCmd = dbConnection.CreateCommand();
                loanApplicationCmd.CommandText = "DELETE FROM LoanApplications WHERE client_id = @client_id";
                loanApplicationCmd.Parameters.AddWithValue("@client_id", client.ID);
                loanApplicationCmd.ExecuteNonQuery();
                loanApplicationCmd.Dispose();

                SqlCommand loanCmd = dbConnection.CreateCommand();
                loanCmd.CommandText = "DELETE FROM Loans WHERE client_id = @client_id";
                loanCmd.Parameters.AddWithValue("@client_id", client.ID);
                loanCmd.ExecuteNonQuery();
                loanCmd.Dispose();

                // Delete the main record from Clients table
                SqlCommand clientCmd = dbConnection.CreateCommand();
                clientCmd.CommandText = "DELETE FROM Clients WHERE client_id = @client_id";

                // Set parameter value for the delete query
                clientCmd.Parameters.AddWithValue("@client_id", client.ID);
                int rowsAffected =  clientCmd.ExecuteNonQuery(); // Execute the query
                clientCmd.Dispose();

                // if rowsAffected is greater than 0, the data is deleted successfully
                if (rowsAffected > 0)
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

        // Overloaded Search() method where a method accepts string and the other int
        // A Search() method that accepts int as its parameter
        public List<Client> GetFilteredClients(int value)
        {
            List<Client> filteredResult = new List<Client>();

            try
            {
                dbConnection.Open(); // To establish database connection

                SqlCommand cmd = dbConnection.CreateCommand();

                // A query to search in the database table
                cmd.CommandText = "SELECT Clients.*, ClientFinancials.*, ClientEmployment.* FROM Clients" +
                    " INNER JOIN ClientFinancials ON Clients.client_id = ClientFinancials.client_id" +
                    " INNER JOIN ClientEmployment ON Clients.client_id = ClientEmployment.client_id" +
                    " WHERE Clients.client_id = @value";

                // Set parameter value for search query
                cmd.Parameters.AddWithValue("@value", value);

                SqlDataReader reader = cmd.ExecuteReader();

                // Iterate through each row while there is a row in the Clients and ClientFinancials table
                while (reader.Read())
                {
                    // Create an instance of Client object where each col from the db will be stored
                    Client client = new Client();

                    // Assign col values to Client attributes
                    client.ID = Convert.ToInt32(reader["client_id"]);
                    client.LastName = reader["last_name"].ToString();
                    client.FirstName = reader["first_name"].ToString();
                    client.MiddleName = reader["middle_name"].ToString();
                    client.BirthDate = Convert.ToDateTime(reader["date_of_birth"].ToString());
                    client.Address = reader["address"].ToString();
                    client.Phone = reader["phone"].ToString();
                    client.Email = reader["email"].ToString();
                    client.EmploymentId = Convert.ToInt32(reader["employment_id"]);
                    client.EmployerName = reader["employer_name"].ToString();
                    client.JobTitle = reader["job_title"].ToString();
                    client.EmploymentStartDate = Convert.ToDateTime(reader["employment_start_date"]);
                    client.EmploymentStatus = reader["employment_status"].ToString();
                    client.IncomeAmount = Convert.ToDouble(reader["income_amount"]);
                    client.IncomeFrequency = reader["income_frequency"].ToString();
                    client.FinancialID = Convert.ToInt32(reader["financials_id"]);
                    client.AnnualIncome = Convert.ToDouble(reader["annual_income"]);
                    client.IncomeSource = reader["income_source"].ToString();
                    client.ExpensesAmount = Convert.ToDouble(reader["expenses_amount"]);
                    client.TotalAssets = Convert.ToDouble(reader["asset_value"]);
                    client.TotalLiabilities = Convert.ToDouble(reader["liabilities_amount"]);
                    client.CreditScore = Convert.ToInt32(reader["credit_score"]);
                    client.CreditHistory = reader["credit_history"].ToString();

                    filteredResult.Add(client); // To add Client object to the list
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
                dbConnection.Close(); // To terminate database connection
            }

            return filteredResult;
        }

        // A Search() method that accepts string as its parameter
        public List<Client> GetFilteredClients(string value)
        {
            List<Client> filteredResult = new List<Client>();

            try
            {
                dbConnection.Open(); // To establish database connection

                SqlCommand cmd = dbConnection.CreateCommand();

                // A query to search in the database table
                cmd.CommandText = "SELECT Clients.*, ClientFinancials.*, ClientEmployment.* FROM Clients" +
                    " INNER JOIN ClientFinancials ON Clients.client_id = ClientFinancials.client_id" +
                    " INNER JOIN ClientEmployment ON Clients.client_id = ClientEmployment.client_id" +
                    " WHERE CONCAT(last_name, ' ', first_name, ' ', middle_name) LIKE '%' + @value + '%'";

                // Set parameter value for search query
                cmd.Parameters.AddWithValue("@value", value);

                SqlDataReader reader = cmd.ExecuteReader();

                // Iterate through each row while there is a row in the Clients and ClientFinancials table
                while (reader.Read())
                {
                    // Create an instance of Client object where each col from the db will be stored
                    Client client = new Client();

                    // Assign col values to Client attributes
                    client.ID = Convert.ToInt32(reader["client_id"]);
                    client.LastName = reader["last_name"].ToString();
                    client.FirstName = reader["first_name"].ToString();
                    client.MiddleName = reader["middle_name"].ToString();
                    client.BirthDate = Convert.ToDateTime(reader["date_of_birth"].ToString());
                    client.Address = reader["address"].ToString();
                    client.Phone = reader["phone"].ToString();
                    client.Email = reader["email"].ToString();
                    client.EmploymentId = Convert.ToInt32(reader["employment_id"]);
                    client.EmployerName = reader["employer_name"].ToString();
                    client.JobTitle = reader["job_title"].ToString();
                    client.EmploymentStartDate = Convert.ToDateTime(reader["employment_start_date"]);
                    client.EmploymentStatus = reader["employment_status"].ToString();
                    client.IncomeAmount = Convert.ToDouble(reader["income_amount"]);
                    client.IncomeFrequency = reader["income_frequency"].ToString();
                    client.FinancialID = Convert.ToInt32(reader["financials_id"]);
                    client.AnnualIncome = Convert.ToDouble(reader["annual_income"]);
                    client.IncomeSource = reader["income_source"].ToString();
                    client.ExpensesAmount = Convert.ToDouble(reader["expenses_amount"]);
                    client.TotalAssets = Convert.ToDouble(reader["asset_value"]);
                    client.TotalLiabilities = Convert.ToDouble(reader["liabilities_amount"]);
                    client.CreditScore = Convert.ToInt32(reader["credit_score"]);
                    client.CreditHistory = reader["credit_history"].ToString();

                    filteredResult.Add(client); // To add Client object to the list
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
                dbConnection.Close(); // To terminate database connection
            }

            return filteredResult;
        }
    }
}
