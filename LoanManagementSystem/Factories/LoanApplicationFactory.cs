using LoanManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Factories
{
    internal abstract class LoanApplicationFactory
    {
        public abstract LoanApplication CreateLoanApplication();
    }
}