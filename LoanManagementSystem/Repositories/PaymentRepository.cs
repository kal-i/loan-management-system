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
    internal class PaymentRepository
    {
        private DBConnection dbConnection;

        public PaymentRepository(DBConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public int GetOverDues()
        {
            int count = 0;

            try
            {
                dbConnection.Open();

                SqlCommand cmd = dbConnection.CreateCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM Payments WHERE payment_date < GETDATE()";

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
                MessageBox.Show($"Database error: {e.Message}");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
            finally { dbConnection.Close(); }

            return count;
        }

        public List<Payment> GetLoanPayments(int loanId)
        {
            List<Payment> payments = new List<Payment>();

            try
            {
                dbConnection.Open();

                SqlCommand cmd = dbConnection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Payments" +
                    " WHERE loan_id = @loan_id";
                cmd.Parameters.AddWithValue("@loan_id", loanId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Payment payment = new Payment();

                    payment.Id = Convert.ToInt32(reader["payment_id"]);
                    payment.LoanId = Convert.ToInt32(reader["loan_id"]);
                    payment.PaymentNumber = Convert.ToInt32(reader["payment_number"]);
                    payment.PaymentDate = Convert.ToDateTime(reader["payment_date"]);
                    payment.PrincipalAmount = Convert.ToDouble(reader["principal_amount"]);
                    payment.InterestAmount = Convert.ToDouble(reader["interest_amount"]);
                    payment.RemainingBalance = Convert.ToDouble(reader["remaining_balance"]);
                    payment.Is_Paid = Convert.ToInt32(reader["is_paid"]);

                    payments.Add(payment);
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

            return payments;
        }

        public List<Payment> GetLoanToPay(int loanId)
        {
            List<Payment> payments = new List<Payment>();

            try
            {
                dbConnection.Open();

                SqlCommand cmd = dbConnection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Payments" +
                    " WHERE loan_id = @loan_id AND is_paid = 0";
                cmd.Parameters.AddWithValue("@loan_id", loanId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Payment payment = new Payment();

                    payment.Id = Convert.ToInt32(reader["payment_id"]);
                    payment.LoanId = Convert.ToInt32(reader["loan_id"]);
                    payment.PaymentNumber = Convert.ToInt32(reader["payment_number"]);
                    payment.PaymentDate = Convert.ToDateTime(reader["payment_date"]);
                    payment.PrincipalAmount = Convert.ToDouble(reader["principal_amount"]);
                    payment.InterestAmount = Convert.ToDouble(reader["interest_amount"]);
                    payment.RemainingBalance = Convert.ToDouble(reader["remaining_balance"]);
                    payment.Is_Paid = Convert.ToInt32(reader["is_paid"]);

                    payments.Add(payment);
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

            return payments;
        }

        public List<Payment> GetPaymentsHistory(int loanId)
        {
            List<Payment> payments = new List<Payment>();

            try
            {
                dbConnection.Open();

                SqlCommand cmd = dbConnection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Payments" +
                    " WHERE loan_id = @loan_id AND is_paid = 1";
                cmd.Parameters.AddWithValue("@loan_id", loanId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Payment payment = new Payment();

                    payment.Id = Convert.ToInt32(reader["payment_id"]);
                    payment.LoanId = Convert.ToInt32(reader["loan_id"]);
                    payment.PaymentNumber = Convert.ToInt32(reader["payment_number"]);
                    payment.PaymentDate = Convert.ToDateTime(reader["payment_date"]);
                    payment.PrincipalAmount = Convert.ToDouble(reader["principal_amount"]);
                    payment.InterestAmount = Convert.ToDouble(reader["interest_amount"]);
                    payment.RemainingBalance = Convert.ToDouble(reader["remaining_balance"]);
                    payment.Is_Paid = Convert.ToInt32(reader["is_paid"]);

                    payments.Add(payment);
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

            return payments;
        }

        public void MakeTransaction(Payment payment)
        {
            try
            {
                dbConnection.Open();

                SqlCommand cmd = dbConnection.CreateCommand();
                cmd.CommandText = "UPDATE Payments SET is_paid = 1" +
                    " WHERE payment_id = @payment_id AND loan_id = @loan_id AND payment_number = @payment_number";

                cmd.Parameters.AddWithValue("@payment_id", payment.Id);
                cmd.Parameters.AddWithValue("@loan_id", payment.LoanId);
                cmd.Parameters.AddWithValue("@payment_number", payment.PaymentNumber);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Transaction Successful.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                SqlCommand loanCmd = dbConnection.CreateCommand();
                loanCmd.CommandText = "UPDATE Loans SET status = 'Settled' " +
                    " WHERE NOT EXISTS (" +
                    " SELECT *  FROM Payments" +
                    " WHERE Payments.loan_id = Loans.loan_id AND (Payments.is_paid = 0));";

                loanCmd.ExecuteNonQuery();

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