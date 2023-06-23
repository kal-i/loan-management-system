using LoanManagementSystem.Model;
using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoanManagementSystem.Repositories
{
    internal class LoanRepository
    {
        private DBConnection dbConnection;

        public LoanRepository(DBConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public int GetNumberOfActiveLoans()
        {
            int count = 0;

            try
            {
                dbConnection.Open();

                SqlCommand cmd = dbConnection.CreateCommand();

                cmd.CommandText = "SELECT COUNT(*) FROM Loans WHERE Status = 'Active'";

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

        public List<Loan> GetApprovedLoans()
        {
            List<Loan> loans = new List<Loan>();

            try
            {
                dbConnection.Open();

                SqlCommand cmd = dbConnection.CreateCommand();

                cmd.CommandText = @"
                    SELECT Loans.*,
                           Clients.*, Clients.client_id, CONCAT(Clients.first_name, ' ', Clients.middle_name, ' ', Clients.last_name) AS client_name, ClientEmployment.*, ClientFinancials.*,
                           LoanTypes.loan_type_id, LoanTypes.loan_type_name,
                           Collaterals.*,
                           Guarantors.*, CONCAT(Guarantors.first_name, ' ', Guarantors.middle_name, ' ', Guarantors.last_name) AS guarantor_name,
                           LoanOfficers.*, CONCAT(LoanOfficers.first_name, ' ', LoanOfficers.middle_name, ' ', LoanOfficers.last_name) AS officer_name
                    FROM Loans
                    INNER JOIN Clients ON Loans.client_id = Clients.client_id
                    INNER JOIN ClientFinancials ON Loans.client_id = ClientFinancials.client_id
                    INNER JOIN ClientEmployment ON Loans.client_id = ClientEmployment.client_id
                    INNER JOIN LoanTypes ON Loans.loan_type_id = LoanTypes.loan_type_id
                    INNER JOIN Collaterals ON Collaterals.loan_id = Loans.loan_id
                    INNER JOIN Guarantors ON Guarantors.guarantor_id = Loans.guarantor_id
                    INNER JOIN LoanOfficers ON LoanOfficers.officer_id = Loans.officer_id
                    WHERE Loans.status = 'Approved'
                    ORDER BY Loans.loan_id;";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Loan loan = new Loan();

                    loan.Borrower = new Client();
                    loan.LoanType = new LoanType();
                    loan.Collateral = new Collateral();
                    loan.Guarantor = new Guarantor();
                    loan.AssignedOfficer = new LoanOfficer();

                    loan.LoanId = Convert.ToInt32(reader["loan_id"]);

                    loan.LoanType.LoanTypeId = Convert.ToInt32(reader["loan_type_id"]);
                    loan.LoanType.LoanName = reader["loan_type_name"].ToString();

                    loan.Borrower.ID = Convert.ToInt32(reader["client_id"]);
                    loan.Borrower.FullName = reader["client_name"].ToString();
                    loan.Borrower.BirthDate = Convert.ToDateTime(reader["date_of_birth"].ToString());
                    loan.Borrower.Address = reader["address"].ToString();
                    loan.Borrower.Phone = reader["phone"].ToString();
                    loan.Borrower.Email = reader["email"].ToString();
                    loan.Borrower.EmploymentId = Convert.ToInt32(reader["employment_id"].ToString());
                    loan.Borrower.EmployerName = reader["employer_name"].ToString();
                    loan.Borrower.JobTitle = reader["job_title"].ToString();
                    loan.Borrower.EmploymentStartDate = Convert.ToDateTime(reader["employment_start_date"].ToString());
                    loan.Borrower.EmploymentStatus = reader["employment_status"].ToString();
                    loan.Borrower.IncomeAmount = Convert.ToDouble(reader["income_amount"].ToString());
                    loan.Borrower.IncomeFrequency = reader["income_frequency"].ToString();
                    loan.Borrower.FinancialID = Convert.ToInt32(reader["financials_id"].ToString());
                    loan.Borrower.AnnualIncome = Convert.ToDouble(reader["annual_income"].ToString());
                    loan.Borrower.IncomeSource = reader["income_source"].ToString();
                    loan.Borrower.ExpensesAmount = Convert.ToDouble(reader["expenses_amount"].ToString());
                    loan.Borrower.TotalAssets = Convert.ToDouble(reader["asset_value"]);
                    loan.Borrower.TotalLiabilities = Convert.ToDouble(reader["liabilities_amount"]);
                    loan.Borrower.CreditScore = Convert.ToInt32(reader["credit_score"]);

                    loan.LoanAmount = Convert.ToDouble(reader["loan_amount"]);
                    loan.PaymentFrequency = reader["payment_frequency"].ToString();
                    loan.InterestRate = Convert.ToDouble(reader["interest_Rate"]);
                    loan.LoanTerm = Convert.ToInt32(reader["loan_term"]);
                    loan.StartDate = Convert.ToDateTime(reader["start_date"]);
                    loan.EndDate = Convert.ToDateTime(reader["end_date"]);

                    loan.Collateral.Id = Convert.ToInt32(reader["collateral_id"]);
                    loan.Collateral.CollateralType = reader["collateral_type"].ToString();
                    loan.Collateral.CollateralValue = Convert.ToDouble(reader["collateral_value"]);
                    loan.Collateral.CollateralLocation = reader["collateral_location"].ToString();

                    loan.Guarantor.ID = Convert.ToInt32(reader["guarantor_id"]);
                    loan.Guarantor.FullName = reader["guarantor_name"].ToString();
                    loan.Guarantor.BirthDate = Convert.ToDateTime(reader["date_of_birth"].ToString());
                    loan.Guarantor.Address = reader["address"].ToString();
                    loan.Guarantor.Phone = reader["phone"].ToString();
                    loan.Guarantor.Email = reader["email"].ToString();

                    loan.AssignedOfficer.ID = Convert.ToInt32(reader["officer_id"]);
                    loan.AssignedOfficer.FullName = reader["officer_name"].ToString();
                    loan.AssignedOfficer.BirthDate = Convert.ToDateTime(reader["date_of_birth"].ToString());
                    loan.AssignedOfficer.Address = reader["address"].ToString();
                    loan.AssignedOfficer.Phone = reader["phone"].ToString();
                    loan.AssignedOfficer.Email = reader["email"].ToString();

                    loan.Status = reader["status"].ToString();

                    loans.Add(loan);
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

            return loans;
        }

        public List<Loan> GetActiveLoans()
        {
            List<Loan> loans = new List<Loan>();

            try
            {
                dbConnection.Open();

                SqlCommand cmd = dbConnection.CreateCommand();

                cmd.CommandText = @"
                    SELECT Loans.*,
                           Clients.*, Clients.client_id, CONCAT(Clients.first_name, ' ', Clients.middle_name, ' ', Clients.last_name) AS client_name, ClientEmployment.*, ClientFinancials.*,
                           LoanTypes.loan_type_id, LoanTypes.loan_type_name,
                           Collaterals.*,
                           Guarantors.*, CONCAT(Guarantors.first_name, ' ', Guarantors.middle_name, ' ', Guarantors.last_name) AS guarantor_name,
                           LoanOfficers.*, CONCAT(LoanOfficers.first_name, ' ', LoanOfficers.middle_name, ' ', LoanOfficers.last_name) AS officer_name
                    FROM Loans
                    INNER JOIN Clients ON Loans.client_id = Clients.client_id
                    INNER JOIN ClientFinancials ON Loans.client_id = ClientFinancials.client_id
                    INNER JOIN ClientEmployment ON Loans.client_id = ClientEmployment.client_id
                    INNER JOIN LoanTypes ON Loans.loan_type_id = LoanTypes.loan_type_id
                    INNER JOIN Collaterals ON Collaterals.loan_id = Loans.loan_id
                    INNER JOIN Guarantors ON Guarantors.guarantor_id = Loans.guarantor_id
                    INNER JOIN LoanOfficers ON LoanOfficers.officer_id = Loans.officer_id
                    WHERE Loans.status = 'Active'
                    ORDER BY Loans.loan_id;";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Loan loan = new Loan();

                    loan.Borrower = new Client();
                    loan.LoanType = new LoanType();
                    loan.Collateral = new Collateral();
                    loan.Guarantor = new Guarantor();
                    loan.AssignedOfficer = new LoanOfficer();

                    loan.LoanId = Convert.ToInt32(reader["loan_id"]);

                    loan.LoanType.LoanTypeId = Convert.ToInt32(reader["loan_type_id"]);
                    loan.LoanType.LoanName = reader["loan_type_name"].ToString();

                    loan.Borrower.ID = Convert.ToInt32(reader["client_id"]);
                    loan.Borrower.FullName = reader["client_name"].ToString();
                    loan.Borrower.BirthDate = Convert.ToDateTime(reader["date_of_birth"].ToString());
                    loan.Borrower.Address = reader["address"].ToString();
                    loan.Borrower.Phone = reader["phone"].ToString();
                    loan.Borrower.Email = reader["email"].ToString();
                    loan.Borrower.EmploymentId = Convert.ToInt32(reader["employment_id"].ToString());
                    loan.Borrower.EmployerName = reader["employer_name"].ToString();
                    loan.Borrower.JobTitle = reader["job_title"].ToString();
                    loan.Borrower.EmploymentStartDate = Convert.ToDateTime(reader["employment_start_date"].ToString());
                    loan.Borrower.EmploymentStatus = reader["employment_status"].ToString();
                    loan.Borrower.IncomeAmount = Convert.ToDouble(reader["income_amount"].ToString());
                    loan.Borrower.IncomeFrequency = reader["income_frequency"].ToString();
                    loan.Borrower.FinancialID = Convert.ToInt32(reader["financials_id"].ToString());
                    loan.Borrower.AnnualIncome = Convert.ToDouble(reader["annual_income"].ToString());
                    loan.Borrower.IncomeSource = reader["income_source"].ToString();
                    loan.Borrower.ExpensesAmount = Convert.ToDouble(reader["expenses_amount"].ToString());
                    loan.Borrower.TotalAssets = Convert.ToDouble(reader["asset_value"]);
                    loan.Borrower.TotalLiabilities = Convert.ToDouble(reader["liabilities_amount"]);
                    loan.Borrower.CreditScore = Convert.ToInt32(reader["credit_score"]);

                    loan.LoanAmount = Convert.ToDouble(reader["loan_amount"]);
                    loan.PaymentFrequency = reader["payment_frequency"].ToString();
                    loan.InterestRate = Convert.ToDouble(reader["interest_Rate"]);
                    loan.LoanTerm = Convert.ToInt32(reader["loan_term"]);
                    loan.StartDate = Convert.ToDateTime(reader["start_date"]);
                    loan.EndDate = Convert.ToDateTime(reader["end_date"]);

                    loan.Collateral.Id = Convert.ToInt32(reader["collateral_id"]);
                    loan.Collateral.CollateralType = reader["collateral_type"].ToString();
                    loan.Collateral.CollateralValue = Convert.ToDouble(reader["collateral_value"]);
                    loan.Collateral.CollateralLocation = reader["collateral_location"].ToString();

                    loan.Guarantor.ID = Convert.ToInt32(reader["guarantor_id"]);
                    loan.Guarantor.FullName = reader["guarantor_name"].ToString();
                    loan.Guarantor.BirthDate = Convert.ToDateTime(reader["date_of_birth"].ToString());
                    loan.Guarantor.Address = reader["address"].ToString();
                    loan.Guarantor.Phone = reader["phone"].ToString();
                    loan.Guarantor.Email = reader["email"].ToString();

                    loan.AssignedOfficer.ID = Convert.ToInt32(reader["officer_id"]);
                    loan.AssignedOfficer.FullName = reader["officer_name"].ToString();
                    loan.AssignedOfficer.BirthDate = Convert.ToDateTime(reader["date_of_birth"].ToString());
                    loan.AssignedOfficer.Address = reader["address"].ToString();
                    loan.AssignedOfficer.Phone = reader["phone"].ToString();
                    loan.AssignedOfficer.Email = reader["email"].ToString();

                    loan.Status = reader["status"].ToString();

                    loans.Add(loan);
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

            return loans;
        }

        public List<Loan> GetSettledLoans()
        {
            List<Loan> loans = new List<Loan>();

            try
            {
                dbConnection.Open();

                SqlCommand cmd = dbConnection.CreateCommand();

                cmd.CommandText = @"
                    SELECT Loans.*,
                           Clients.*, Clients.client_id, CONCAT(Clients.first_name, ' ', Clients.middle_name, ' ', Clients.last_name) AS client_name, ClientEmployment.*, ClientFinancials.*,
                           LoanTypes.loan_type_id, LoanTypes.loan_type_name,
                           Collaterals.*,
                           Guarantors.*, CONCAT(Guarantors.first_name, ' ', Guarantors.middle_name, ' ', Guarantors.last_name) AS guarantor_name,
                           LoanOfficers.*, CONCAT(LoanOfficers.first_name, ' ', LoanOfficers.middle_name, ' ', LoanOfficers.last_name) AS officer_name
                    FROM Loans
                    INNER JOIN Clients ON Loans.client_id = Clients.client_id
                    INNER JOIN ClientFinancials ON Loans.client_id = ClientFinancials.client_id
                    INNER JOIN ClientEmployment ON Loans.client_id = ClientEmployment.client_id
                    INNER JOIN LoanTypes ON Loans.loan_type_id = LoanTypes.loan_type_id
                    INNER JOIN Collaterals ON Collaterals.loan_id = Loans.loan_id
                    INNER JOIN Guarantors ON Guarantors.guarantor_id = Loans.guarantor_id
                    INNER JOIN LoanOfficers ON LoanOfficers.officer_id = Loans.officer_id
                    WHERE Loans.status = 'Settled'
                    ORDER BY Loans.loan_id;";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Loan loan = new Loan();

                    loan.Borrower = new Client();
                    loan.LoanType = new LoanType();
                    loan.Collateral = new Collateral();
                    loan.Guarantor = new Guarantor();
                    loan.AssignedOfficer = new LoanOfficer();

                    loan.LoanId = Convert.ToInt32(reader["loan_id"]);

                    loan.LoanType.LoanTypeId = Convert.ToInt32(reader["loan_type_id"]);
                    loan.LoanType.LoanName = reader["loan_type_name"].ToString();

                    loan.Borrower.ID = Convert.ToInt32(reader["client_id"]);
                    loan.Borrower.FullName = reader["client_name"].ToString();
                    loan.Borrower.BirthDate = Convert.ToDateTime(reader["date_of_birth"].ToString());
                    loan.Borrower.Address = reader["address"].ToString();
                    loan.Borrower.Phone = reader["phone"].ToString();
                    loan.Borrower.Email = reader["email"].ToString();
                    loan.Borrower.EmploymentId = Convert.ToInt32(reader["employment_id"].ToString());
                    loan.Borrower.EmployerName = reader["employer_name"].ToString();
                    loan.Borrower.JobTitle = reader["job_title"].ToString();
                    loan.Borrower.EmploymentStartDate = Convert.ToDateTime(reader["employment_start_date"].ToString());
                    loan.Borrower.EmploymentStatus = reader["employment_status"].ToString();
                    loan.Borrower.IncomeAmount = Convert.ToDouble(reader["income_amount"].ToString());
                    loan.Borrower.IncomeFrequency = reader["income_frequency"].ToString();
                    loan.Borrower.FinancialID = Convert.ToInt32(reader["financials_id"].ToString());
                    loan.Borrower.AnnualIncome = Convert.ToDouble(reader["annual_income"].ToString());
                    loan.Borrower.IncomeSource = reader["income_source"].ToString();
                    loan.Borrower.ExpensesAmount = Convert.ToDouble(reader["expenses_amount"].ToString());
                    loan.Borrower.TotalAssets = Convert.ToDouble(reader["asset_value"]);
                    loan.Borrower.TotalLiabilities = Convert.ToDouble(reader["liabilities_amount"]);
                    loan.Borrower.CreditScore = Convert.ToInt32(reader["credit_score"]);

                    loan.LoanAmount = Convert.ToDouble(reader["loan_amount"]);
                    loan.PaymentFrequency = reader["payment_frequency"].ToString();
                    loan.InterestRate = Convert.ToDouble(reader["interest_Rate"]);
                    loan.LoanTerm = Convert.ToInt32(reader["loan_term"]);
                    loan.StartDate = Convert.ToDateTime(reader["start_date"]);
                    loan.EndDate = Convert.ToDateTime(reader["end_date"]);

                    loan.Collateral.Id = Convert.ToInt32(reader["collateral_id"]);
                    loan.Collateral.CollateralType = reader["collateral_type"].ToString();
                    loan.Collateral.CollateralValue = Convert.ToDouble(reader["collateral_value"]);
                    loan.Collateral.CollateralLocation = reader["collateral_location"].ToString();

                    loan.Guarantor.ID = Convert.ToInt32(reader["guarantor_id"]);
                    loan.Guarantor.FullName = reader["guarantor_name"].ToString();
                    loan.Guarantor.BirthDate = Convert.ToDateTime(reader["date_of_birth"].ToString());
                    loan.Guarantor.Address = reader["address"].ToString();
                    loan.Guarantor.Phone = reader["phone"].ToString();
                    loan.Guarantor.Email = reader["email"].ToString();

                    loan.AssignedOfficer.ID = Convert.ToInt32(reader["officer_id"]);
                    loan.AssignedOfficer.FullName = reader["officer_name"].ToString();
                    loan.AssignedOfficer.BirthDate = Convert.ToDateTime(reader["date_of_birth"].ToString());
                    loan.AssignedOfficer.Address = reader["address"].ToString();
                    loan.AssignedOfficer.Phone = reader["phone"].ToString();
                    loan.AssignedOfficer.Email = reader["email"].ToString();

                    loan.Status = reader["status"].ToString();

                    loans.Add(loan);
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

            return loans;
        }

        public void SetLoanToActive(int loanId)
        {
            try
            {
                dbConnection.Open();

                SqlCommand cmd = dbConnection.CreateCommand();
                cmd.CommandText = "UPDATE Loans SET status = 'Active' WHERE loan_id = @loan_id";
                cmd.Parameters.AddWithValue("@loan_id", loanId);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Loan is set to Active state.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
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
        }
    }
}