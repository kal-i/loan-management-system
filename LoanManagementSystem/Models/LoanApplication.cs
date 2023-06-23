using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Model
{
    internal abstract class LoanApplication
    {
        public int ApplicationId { get; set; }
        public Client Client { get; set; }
        public LoanType LoanType { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; }

        // Computed properties
        public int ClientId => (int) Client?.ID;
        public string ClientFullName => Client?.FullName;
        public DateTime BirthDate => (DateTime) Client?.BirthDate;
        public string Address => Client?.Address;
        public string Phone => Client?.Phone;
        public string Email => Client?.Email;
        public string EmployerName => Client?.EmployerName;
        public string JobTitle => Client?.JobTitle;
        public DateTime EmploymentStartDate => (DateTime) Client?.EmploymentStartDate;
        public string EmploymentStatus => Client?.EmploymentStatus;
        public double IncomeAmount => (double) Client?.IncomeAmount;
        public string IncomeFrequency => Client?.IncomeFrequency;
        public double AnnualIncome => (double) Client?.AnnualIncome;
        public string IncomeSource => Client?.IncomeSource;
        public double ExpensesAmount => (double) Client?.ExpensesAmount;
        public double AssetValue => (double) Client?.TotalAssets;
        public double LiabilitiesAmount => (double) Client?.TotalLiabilities;
        public int CreditScore => (int) Client?.CreditScore;
        //public string CreditHistory => Client?.CreditHistory;

        public int LoanTypeId => (int)LoanType?.LoanTypeId;
        public string LoanTypeName => LoanType?.LoanName;

        public abstract void ProcessApplication();
    }
}