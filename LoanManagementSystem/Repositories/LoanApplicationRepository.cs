using LoanManagementSystem.Factories;
using LoanManagementSystem.Model;
using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoanManagementSystem.Repositories
{
    internal class LoanApplicationRepository
    {
        private DBConnection dbConnection;

        public LoanApplicationRepository(DBConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        // return the no. of pending request
        public int GetNumberOfPendingRequests()
        {
            int count = 0;

            try
            {
                dbConnection.Open();

                SqlCommand cmd = dbConnection.CreateCommand();

                cmd.CommandText = "SELECT COUNT(*) FROM LoanApplications WHERE Status = 'pending'";

                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int rowCount))
                {
                    count = rowCount;
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show($"Database error: {e.Message}");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
            finally { dbConnection.Close(); }

            return count;
        }

        public List<LoanApplication> GetPendingLoanApplications()
        {
            List<LoanApplication> loanApplications = new List<LoanApplication>();

            try
            {
                dbConnection.Open();

                SqlCommand cmd = dbConnection.CreateCommand();

                cmd.CommandText = "SELECT LoanApplications.application_id, Clients.*, ClientFinancials.*, ClientEmployment.*, LoanTypes.loan_type_id, LoanTypes.loan_type_name, LoanApplications.application_date, LoanApplications.status FROM LoanApplications" +
                    " INNER JOIN Clients ON LoanApplications.client_id = Clients.client_id" +
                    " INNER JOIN ClientFinancials ON LoanApplications.client_id = ClientFinancials.client_id" +
                    " INNER JOIN ClientEmployment ON LoanApplications.client_id = ClientEmployment.client_id" +
                    " INNER JOIN LoanTypes ON LoanApplications.loan_type_id = LoanTypes.loan_type_id" +
                    " WHERE status = 'Pending'";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LoanApplicationFactory factory = null;
                    string loanType = reader["loan_type_name"].ToString();

                    if (loanType == "Personal Loan")
                    {
                        factory = new PersonalLoanApplicationFactory();
                    }
                    else if (loanType == "Mortgage Loan")
                    {
                        factory = new MortgageLoanApplicationFactory();
                    }
                    else if (loanType == "Auto Loan")
                    {
                        factory = new AutoLoanApplicationFactory();
                    }
                    else if (loanType == "Student Loan")
                    {
                        factory = new StudentLoanApplicationFactory();
                    }
                    else if (loanType == "Small Business Loan")
                    {
                        factory = new SmallBusinessLoanApplicationFactory();
                    }

                    if (factory != null)
                    {
                        LoanApplication loanApplication = factory.CreateLoanApplication();

                        loanApplication.Client = new Client();
                        loanApplication.LoanType = new LoanType();

                        // Manually concatenate client's full name
                        string firstName = reader["first_name"].ToString();
                        string middleName = reader["middle_name"].ToString();
                        string lastName = reader["last_name"].ToString();

                        loanApplication.ApplicationId = Convert.ToInt32(reader["application_id"]);
                        loanApplication.Client.ID = Convert.ToInt32(reader["client_id"]);
                        loanApplication.Client.FullName = string.Concat(firstName, " ", middleName, " ", lastName);
                        loanApplication.Client.BirthDate = Convert.ToDateTime(reader["date_of_birth"].ToString());
                        loanApplication.Client.Address = reader["address"].ToString();
                        loanApplication.Client.Phone = reader["phone"].ToString();
                        loanApplication.Client.Email = reader["email"].ToString();
                        loanApplication.Client.EmploymentId = Convert.ToInt32(reader["employment_id"].ToString());
                        loanApplication.Client.EmployerName = reader["employer_name"].ToString();
                        loanApplication.Client.JobTitle = reader["job_title"].ToString();
                        loanApplication.Client.EmploymentStartDate = Convert.ToDateTime(reader["employment_start_date"].ToString());
                        loanApplication.Client.EmploymentStatus = reader["employment_status"].ToString();
                        loanApplication.Client.IncomeAmount = Convert.ToDouble(reader["income_amount"].ToString());
                        loanApplication.Client.IncomeFrequency = reader["income_frequency"].ToString();
                        loanApplication.Client.FinancialID = Convert.ToInt32(reader["financials_id"].ToString());
                        loanApplication.Client.AnnualIncome = Convert.ToDouble(reader["annual_income"].ToString());
                        loanApplication.Client.IncomeSource = reader["income_source"].ToString();
                        loanApplication.Client.ExpensesAmount = Convert.ToDouble(reader["expenses_amount"].ToString());
                        loanApplication.Client.TotalAssets = Convert.ToDouble(reader["asset_value"]);
                        loanApplication.Client.TotalLiabilities = Convert.ToDouble(reader["liabilities_amount"]);
                        loanApplication.Client.CreditScore = Convert.ToInt32(reader["credit_score"]);
                        loanApplication.LoanType.LoanTypeId = Convert.ToInt32(reader["loan_type_id"]);
                        loanApplication.LoanType.LoanName = reader["loan_type_name"].ToString();
                        loanApplication.ApplicationDate = Convert.ToDateTime(reader["application_date"]);
                        loanApplication.Status = reader["status"].ToString();

                        loanApplications.Add(loanApplication);
                    }
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show($"Database error: {e.Message}");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
            finally { dbConnection.Close(); }

            return loanApplications;
        }

        // A method to return denied loan application
        public List<LoanApplication> GetDeniedLoanApplications()
        {
            List<LoanApplication> loanApplications = new List<LoanApplication> ();

            try
            {
                dbConnection.Open();

                SqlCommand cmd = dbConnection.CreateCommand();

                cmd.CommandText = "SELECT LoanApplications.application_id, Clients.*, ClientFinancials.*, ClientEmployment.*, LoanTypes.loan_type_id, LoanTypes.loan_type_name, LoanApplications.application_date, LoanApplications.status FROM LoanApplications" +
                    " INNER JOIN Clients ON LoanApplications.client_id = Clients.client_id" +
                    " INNER JOIN ClientFinancials ON LoanApplications.client_id = ClientFinancials.client_id" +
                    " INNER JOIN ClientEmployment ON LoanApplications.client_id = ClientEmployment.client_id" +
                    " INNER JOIN LoanTypes ON LoanApplications.loan_type_id = LoanTypes.loan_type_id" +
                    " WHERE status = 'Denied'";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LoanApplicationFactory factory = null;
                    string loanType = reader["loan_type_name"].ToString();

                    if (loanType == "Personal Loan")
                    {
                        factory = new PersonalLoanApplicationFactory();
                    }
                    else if (loanType == "Mortgage Loan")
                    {
                        factory = new MortgageLoanApplicationFactory();
                    }
                    else if (loanType == "Auto Loan")
                    {
                        factory = new AutoLoanApplicationFactory();
                    }
                    else if (loanType == "Student Loan")
                    {
                        factory = new StudentLoanApplicationFactory();
                    }
                    else if (loanType == "Small Business Loan")
                    {
                        factory = new SmallBusinessLoanApplicationFactory();
                    }

                    if (factory != null)
                    {
                        LoanApplication loanApplication = factory.CreateLoanApplication();

                        loanApplication.Client = new Client();
                        loanApplication.LoanType = new LoanType();

                        // Manually concatenate client's full name
                        string firstName = reader["first_name"].ToString();
                        string middleName = reader["middle_name"].ToString();
                        string lastName = reader["last_name"].ToString();

                        loanApplication.ApplicationId = Convert.ToInt32(reader["application_id"]);
                        loanApplication.Client.ID = Convert.ToInt32(reader["client_id"]);
                        loanApplication.Client.FullName = string.Concat(firstName, " ", middleName, " ", lastName);
                        loanApplication.Client.BirthDate = Convert.ToDateTime(reader["date_of_birth"].ToString());
                        loanApplication.Client.Address = reader["address"].ToString();
                        loanApplication.Client.Phone = reader["phone"].ToString();
                        loanApplication.Client.Email = reader["email"].ToString();
                        loanApplication.Client.EmploymentId = Convert.ToInt32(reader["employment_id"].ToString());
                        loanApplication.Client.EmployerName = reader["employer_name"].ToString();
                        loanApplication.Client.JobTitle = reader["job_title"].ToString();
                        loanApplication.Client.EmploymentStartDate = Convert.ToDateTime(reader["employment_start_date"].ToString());
                        loanApplication.Client.EmploymentStatus = reader["employment_status"].ToString();
                        loanApplication.Client.IncomeAmount = Convert.ToDouble(reader["income_amount"].ToString());
                        loanApplication.Client.IncomeFrequency = reader["income_frequency"].ToString();
                        loanApplication.Client.FinancialID = Convert.ToInt32(reader["financials_id"].ToString());
                        loanApplication.Client.AnnualIncome = Convert.ToDouble(reader["annual_income"].ToString());
                        loanApplication.Client.IncomeSource = reader["income_source"].ToString();
                        loanApplication.Client.ExpensesAmount = Convert.ToDouble(reader["expenses_amount"].ToString());
                        loanApplication.Client.TotalAssets = Convert.ToDouble(reader["asset_value"]);
                        loanApplication.Client.TotalLiabilities = Convert.ToDouble(reader["liabilities_amount"]);
                        loanApplication.Client.CreditScore = Convert.ToInt32(reader["credit_score"]);
                        loanApplication.LoanType.LoanTypeId = Convert.ToInt32(reader["loan_type_id"]);
                        loanApplication.LoanType.LoanName = reader["loan_type_name"].ToString();
                        loanApplication.ApplicationDate = Convert.ToDateTime(reader["application_date"]);
                        loanApplication.Status = reader["status"].ToString();

                        loanApplications.Add(loanApplication);
                    }
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show($"Sql Error: {e.Message}");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
            finally { dbConnection.Close(); }

            return loanApplications;
        }

        public bool CheckIfExist(LoanApplication application)
        {
            bool count = false;
            try
            {
                dbConnection.Open();

                SqlCommand cmd = dbConnection.CreateCommand();

                // cmd.CommandText = "SELECT COUNT(*) FROM LoanApplications WHERE client_id = @client_id AND status = 'Pending'";
                cmd.CommandText = "SELECT (SELECT COUNT(*) FROM LoanApplications WHERE client_id = @client_id AND status = 'Pending') + (SELECT COUNT(*) FROM Loans WHERE client_id = @client_id AND (status = 'Approved' OR status = 'Active')) AS TotalCount";
                cmd.Parameters.AddWithValue("@client_id", application.Client.ID);

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

        // A method to insert loan application
        public void Insert(LoanApplication loanApplication)
        {
            try
            {
                dbConnection.Open();

                SqlCommand cmd = dbConnection.CreateCommand();

                cmd.CommandText = "INSERT INTO LoanApplications (client_id, loan_type_id, application_date, status) VALUES (@client_id, @loan_type_id, @application_date, @status)";

                cmd.Parameters.AddWithValue("@client_id", loanApplication.Client.ID);
                cmd.Parameters.AddWithValue("@loan_type_id", loanApplication.LoanType.LoanTypeId);
                cmd.Parameters.AddWithValue("@application_date", loanApplication.ApplicationDate);
                cmd.Parameters.AddWithValue("@status", loanApplication.Status);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Application submitted successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Application submitted unsuccessfully.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show($"Database error: {e.Message}");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
            finally
            {
                dbConnection.Close();
            }
        }

        // A method to approve the loan application then create a loan entity
        public void ApproveLoanProcess(LoanApplication loanApplication, Loan loan, List<Payment> payments, Collateral collateral)
        {
            try
            {
                dbConnection.Open();

                // Approving the loan application
                SqlCommand cmd = dbConnection.CreateCommand();

                int applicationId = loanApplication.ApplicationId;

                cmd.CommandText = "UPDATE LoanApplications" +
                    " SET status = 'Approved'" +
                    " WHERE application_id = @application_id";

                cmd.Parameters.AddWithValue("@application_id", applicationId);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                // Create a loan entity
                SqlCommand loanCmd = dbConnection.CreateCommand();

                int clientId = loan.Borrower.ID;

                loanCmd.CommandText = "INSERT INTO Loans (client_id, loan_type_id, guarantor_id, officer_id, loan_amount, payment_frequency, interest_rate, loan_term, start_date, end_date, status) " +
                    "VALUES (@client_id, @loan_type_id, @guarantor_id, @officer_id, @loan_amount, @payment_frequency, @interest_rate, @loan_term, @start_date, @end_date, @status); " +
                    "SELECT SCOPE_IDENTITY();";

                loanCmd.Parameters.AddWithValue("@client_id", clientId);
                loanCmd.Parameters.AddWithValue("@loan_type_id", loan.LoanType.LoanTypeId);
                loanCmd.Parameters.AddWithValue("@guarantor_id", loan.Guarantor.ID);
                loanCmd.Parameters.AddWithValue("@officer_id", loan.AssignedOfficer.ID);
                loanCmd.Parameters.AddWithValue("@loan_amount", loan.LoanAmount);
                loanCmd.Parameters.AddWithValue("@payment_frequency", loan.PaymentFrequency);
                loanCmd.Parameters.AddWithValue("@interest_rate", loan.InterestRate);
                loanCmd.Parameters.AddWithValue("@loan_term", loan.LoanTerm);
                loanCmd.Parameters.AddWithValue("@start_date", loan.StartDate);
                loanCmd.Parameters.AddWithValue("@end_date", loan.EndDate);
                loanCmd.Parameters.AddWithValue("@status", loan.Status);

                int loanId = Convert.ToInt32(loanCmd.ExecuteScalar());
                loanCmd.Dispose();

                // Create a payment entity
                SqlCommand paymentCmd = dbConnection.CreateCommand();

                foreach (Payment payment in payments)
                {
                    // Clear the parameters collection before adding new parameters
                    paymentCmd.Parameters.Clear();

                    paymentCmd.CommandText = "INSERT INTO Payments (loan_id, payment_number, payment_date, principal_amount, interest_amount, remaining_balance, is_paid)" +
                        " VALUES (@loan_id, @payment_number, @payment_date, @principal_amount, @interest_amount, @remaining_balance, 0)";
                    paymentCmd.Parameters.AddWithValue("@loan_id", loanId);
                    paymentCmd.Parameters.AddWithValue("@payment_number", payment.PaymentNumber);
                    paymentCmd.Parameters.AddWithValue("@payment_date", payment.PaymentDate);
                    paymentCmd.Parameters.AddWithValue("@principal_amount", payment.PrincipalAmount);
                    paymentCmd.Parameters.AddWithValue("@interest_amount", payment.InterestAmount);
                    paymentCmd.Parameters.AddWithValue("@remaining_balance", payment.RemainingBalance);
                    paymentCmd.ExecuteNonQuery();
                }
                paymentCmd.Dispose();

                // Create a collateral entity
                SqlCommand collateralCmd = dbConnection.CreateCommand();
                collateralCmd.CommandText = "INSERT INTO Collaterals (loan_id, collateral_type, collateral_value, collateral_location) " +
                    "VALUES (@loan_id, @collateral_type, @collateral_value, @collateral_location)";

                collateralCmd.Parameters.AddWithValue("@loan_id", loanId);
                collateralCmd.Parameters.AddWithValue("@collateral_type", collateral.CollateralType);
                collateralCmd.Parameters.AddWithValue("@collateral_value", collateral.CollateralValue);
                collateralCmd.Parameters.AddWithValue("@collateral_location", collateral.CollateralLocation);

                int rowsAffected = collateralCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Loan application was approved.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Loan application's approval was unsuccessful.", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
                }                
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"SQL Exception: {ex.Message}\n\nStack Trace: {ex.StackTrace}");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Exception: {e.Message}");
            }
            finally
            {
                dbConnection.Close();
            }
        }

        // A method to deny the loan application
        public void DenyLoanProcess(LoanApplication loanApplication)
        {
            try 
            {
                dbConnection.Open();

                SqlCommand cmd = dbConnection.CreateCommand();

                cmd.CommandText = "UPDATE LoanApplications" +
                    " SET status = 'Denied'" +
                    " WHERE application_id = @application_id";

                cmd.Parameters.AddWithValue("@application_id", loanApplication.ApplicationId);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Application was denied.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Something went wrong during the denial process.", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show($"Sql error: {e.Message}");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
            finally
            {
                dbConnection.Close();
            }
        }
    }
}