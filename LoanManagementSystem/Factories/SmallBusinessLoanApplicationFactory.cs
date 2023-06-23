using LoanManagementSystem.Model;
using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Factories
{
    internal class SmallBusinessLoanApplicationFactory : LoanApplicationFactory
    {
        public override LoanApplication CreateLoanApplication()
        {
            return new SmallBusinessLoanApplication(); // Will only return the SmallBusinessLoanApplication object
        }
    }
}
