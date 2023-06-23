using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanManagementSystem.Model;

namespace LoanManagementSystem.Factories
{
    internal abstract class LoanFactory
    {
        public abstract Loan CreateLoan();
    }
}
