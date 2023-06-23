using LoanManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoanManagementSystem.Repositories
{
    internal class LoanTypeRepository
    {
        private DBConnection dbConnection;

        public LoanTypeRepository(DBConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public List<LoanType> GetLoanTypes()
        {
            List<LoanType> loanTypes = new List<LoanType>();

            try
            {
                dbConnection.Open();

                SqlCommand cmd = dbConnection.CreateCommand();

                cmd.CommandText = "SELECT * FROM LoanTypes";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LoanType loanType = new LoanType();
                    loanType.LoanTypeId = Convert.ToInt32(reader["loan_type_id"]);
                    loanType.LoanName = reader["loan_type_name"].ToString();
                    loanType.LoanDescription = reader["description"].ToString();

                    loanTypes.Add(loanType);
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

            return loanTypes;
        }

        // A method that returns a filtered list based on the parameter value passed
        public List<LoanType> FilteredLoanTypes(string value)
        {
            List<LoanType> loanTypes = new List<LoanType>();

            try
            {
                dbConnection.Open();

                SqlCommand cmd = dbConnection.CreateCommand();

                cmd.CommandText = "SELECT * FROM LoanTypes WHERE loan_type_name = @value";

                cmd.Parameters.AddWithValue("@value", value);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LoanType loanType = new LoanType();

                    loanType.LoanTypeId = Convert.ToInt32(reader["loan_type_id"]);
                    loanType.LoanName = reader["loan_type_name"].ToString();
                    loanType.LoanDescription = reader["description"].ToString();

                    loanTypes.Add(loanType);
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

            return loanTypes;
        }
    }
}
