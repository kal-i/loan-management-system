using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Model
{
    internal class LoanType
    {
        public int LoanTypeId { get; set; }
        public string LoanName { get; set; }
        public string LoanDescription { get; set; }

        public LoanType() { }

        public LoanType (int loanTypeId, string loanName)
        {
            LoanTypeId = loanTypeId;
            LoanName = loanName;
        }
    }
}
