using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Models
{
    internal class LoanAmortization
    {
        public int PaymentNumber { get; set; }
        public DateTime PaymentDate { get; set; }
        public double PaymentAmount { get; set; }
        public double Principal { get; set; }
        public double Interest { get; set; }
        public double RemainingBalance { get; set; }
    }
}