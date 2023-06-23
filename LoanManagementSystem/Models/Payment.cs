using LoanManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Models
{
    internal class Payment
    {
        public int Id { get; set; }
        public int LoanId { get; set; }
        public int PaymentNumber { get; set; }
        public DateTime PaymentDate { get; set; }
        public double PrincipalAmount { get; set; }
        public double InterestAmount { get; set; }
        public double RemainingBalance { get; set; }
        public int Is_Paid { get; set; }
    }
}