using LoanManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem
{
    // Client class will inherit all the public attributes and methods of Person class
    internal class Client : Person
    {
        public int EmploymentId { get; set; }
        public string EmployerName { get; set; }
        public string JobTitle { get; set; }
        public DateTime EmploymentStartDate { get; set; }
        public string EmploymentStatus { get; set; }
        public double IncomeAmount { get; set; }
        public string IncomeFrequency { get; set; }
        public int FinancialID { get; set; }
        public double AnnualIncome { get; set; }
        public string IncomeSource { get; set; }
        public double ExpensesAmount { get; set; }
        public double TotalAssets { get; set; }
        public double TotalLiabilities { get; set; }
        public int CreditScore { get; set; }
        public string CreditHistory { get; set; }

        public Client() { }

        public Client(string lastName, string firstName, string middleName, DateTime birthDate, string address, string phone, string email, string employerName, string jobTitle, DateTime employmentStartDate, string employmentStatus, double incomeAmount, string incomeFrequency, double annualIncome, string incomeSource, double expensesAmount, double totalAssets, double totalLiabilities, int creditScore, string creditHistory) : base(lastName, firstName, middleName, birthDate, address, phone, email)
        {
            this.EmployerName = employerName;
            this.JobTitle = jobTitle;
            this.EmploymentStartDate = employmentStartDate;
            this.EmploymentStatus = employmentStatus;
            this.IncomeAmount = incomeAmount;
            this.IncomeFrequency = incomeFrequency;
            this.AnnualIncome = annualIncome;
            this.IncomeSource = incomeSource;
            this.ExpensesAmount = expensesAmount;
            this.TotalAssets = totalAssets;
            this.TotalLiabilities = totalLiabilities;
            this.CreditScore = creditScore;
            this.CreditHistory = creditHistory;
        }

        public Client(string lastName, string firstName, string middleName, DateTime birthDate, string address, string phone, string email, string employerName, string jobTitle, DateTime employmentStartDate, string employmentStatus, double incomeAmount, string incomeFrequency, double annualIncome, string incomeSource, double expensesAmount, double totalAssets, double totalLiabilities, int creditScore) : base(lastName, firstName, middleName, birthDate, address, phone, email)
        {
            this.EmployerName = employerName;
            this.JobTitle = jobTitle;
            this.EmploymentStartDate = employmentStartDate;
            this.EmploymentStatus = employmentStatus;
            this.IncomeAmount = incomeAmount;
            this.IncomeFrequency = incomeFrequency;
            this.AnnualIncome = annualIncome;
            this.IncomeSource = incomeSource;
            this.ExpensesAmount = expensesAmount;
            this.TotalAssets = totalAssets;
            this.TotalLiabilities = totalLiabilities;
            this.CreditScore = creditScore;
        }

        public Client(int id, string fullName, DateTime birthDate, string address, string phone, string email, string employerName, string jobTitle, DateTime employmentStartDate, string employmentStatus, double incomeAmount, string incomeFrequency, double annualIncome, string incomeSource, double expensesAmount, double totalAssets, double totalLiabilities, int creditScore) : base(id, fullName, birthDate, address, phone, email)
        {
            this.EmployerName = employerName;
            this.JobTitle = jobTitle;
            this.EmploymentStartDate = employmentStartDate;
            this.EmploymentStatus = employmentStatus;
            this.IncomeAmount = incomeAmount;
            this.IncomeFrequency = incomeFrequency;
            this.AnnualIncome = annualIncome;
            this.IncomeSource = incomeSource;
            this.ExpensesAmount = expensesAmount;
            this.TotalAssets = totalAssets;
            this.TotalLiabilities = totalLiabilities;
            this.CreditScore = creditScore;
        }

        public Client(int id, string lastName, string firstName, string middleName, DateTime birthDate, string address, string phone, string email, int employmentId, string employerName, string jobTitle, DateTime employmentStartDate, string employmentStatus, double incomeAmount, string incomeFrequency, int financialId, double annualIncome, string incomeSource, double expensesAmount, double totalAssets, double totalLiabilities, int creditScore) : base(id, lastName, firstName, middleName, birthDate, address, phone, email)
        {
            this.EmploymentId = employmentId;
            this.EmployerName = employerName;
            this.JobTitle = jobTitle;
            this.EmploymentStartDate = employmentStartDate;
            this.EmploymentStatus = employmentStatus;
            this.IncomeAmount = incomeAmount;
            this.IncomeFrequency = incomeFrequency;
            this.FinancialID = financialId;
            this.AnnualIncome = annualIncome;
            this.IncomeSource = incomeSource;
            this.ExpensesAmount = expensesAmount;
            this.TotalAssets = totalAssets;
            this.TotalLiabilities = totalLiabilities;
            this.CreditScore = creditScore;
        }

        public Client(int id, string lastName, string firstName, string middleName, DateTime birthDate, string address, string phone, string email, int employmentId, string employerName, string jobTitle, DateTime employmentStartDate, string employmentStatus, double incomeAmount, string incomeFrequency, int financialId, double annualIncome, string incomeSource, double expensesAmount, double totalAssets, double totalLiabilities, int creditScore, string creditHistory) : base(id, lastName, firstName, middleName, birthDate, address, phone, email)
        {
            this.EmploymentId = employmentId;
            this.EmployerName = employerName;
            this.JobTitle = jobTitle;
            this.EmploymentStartDate = employmentStartDate;
            this.EmploymentStatus = employmentStatus;
            this.IncomeAmount = incomeAmount;
            this.IncomeFrequency = incomeFrequency;
            this.FinancialID = financialId;
            this.AnnualIncome = annualIncome;
            this.IncomeSource = incomeSource;
            this.ExpensesAmount = expensesAmount;
            this.TotalAssets = totalAssets;
            this.TotalLiabilities = totalLiabilities;
            this.CreditScore = creditScore;
            this.CreditHistory = creditHistory;
        }
    }
}
