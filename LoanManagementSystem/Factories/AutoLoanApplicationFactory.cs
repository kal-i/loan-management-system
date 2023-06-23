using LoanManagementSystem.Model;
using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Factories
{
    internal class AutoLoanApplicationFactory : LoanApplicationFactory
    {
        public override LoanApplication CreateLoanApplication()
        {
            return new AutoLoanApplication();
        }
    }
}
