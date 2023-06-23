using LoanManagementSystem.Model;
using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoanManagementSystem.Factories
{
    internal class StudentLoanApplicationFactory : LoanApplicationFactory
    {
        public override LoanApplication CreateLoanApplication()
        {
            return new StudentLoanApplication();
        }
    }
}
