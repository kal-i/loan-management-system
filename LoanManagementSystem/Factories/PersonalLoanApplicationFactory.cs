using LoanManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Factories
{
    internal class PersonalLoanApplicationFactory : LoanApplicationFactory
    {
        public override LoanApplication CreateLoanApplication()
        {
            return new PersonalLoanApplication();
        }
    }
}
