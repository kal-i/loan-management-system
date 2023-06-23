using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.ComponentModel;

namespace LoanManagementSystem
{
    internal class DBConnection
    {
        private SqlConnection connection;

        public DBConnection(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public void Open() { connection.Open(); }
        public void Close() { connection.Close(); } 
        public SqlCommand CreateCommand() { return connection.CreateCommand(); }
    }
}