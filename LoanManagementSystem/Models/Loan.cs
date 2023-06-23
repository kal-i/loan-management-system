using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace LoanManagementSystem.Model
{
    internal class Loan
    {
        public int LoanId { get; set; }
        public Client Borrower { get; set; }
        public LoanType LoanType { get; set; }
        public double LoanAmount { get; set; }
        public double InterestRate { get; set; }
        public int LoanTerm { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string PaymentFrequency { get; set; }
        public Collateral Collateral { get; set; }
        public Guarantor Guarantor { get; set; }
        public LoanOfficer AssignedOfficer { get; set; }
        public Payment Payment { get; set; }

        // Computed properties
        public int ClientId => (int) Borrower?.ID;
        public string ClientFullName => Borrower?.FullName;
        public DateTime BirthDate => (DateTime)Borrower?.BirthDate;
        public string Address => Borrower?.Address;
        public string Phone => Borrower?.Phone;
        public string Email => Borrower?.Email;
        public string EmployerName => Borrower?.EmployerName;
        public string JobTitle => Borrower?.JobTitle;
        public DateTime EmploymentStartDate => (DateTime)Borrower?.EmploymentStartDate;
        public string EmploymentStatus => Borrower?.EmploymentStatus;
        public double IncomeAmount => (double)Borrower?.IncomeAmount;
        public string IncomeFrequency => Borrower?.IncomeFrequency;
        public double AnnualIncome => (double)Borrower?.AnnualIncome;
        public string IncomeSource => Borrower?.IncomeSource;
        public double ExpensesAmount => (double)Borrower?.ExpensesAmount;
        public double AssetValue => (double)Borrower?.TotalAssets;
        public double LiabilitiesAmount => (double)Borrower?.TotalLiabilities;
        public int CreditScore => (int)Borrower?.CreditScore;

        public int LoanTypeId => (int) LoanType?.LoanTypeId;
        public string LoanTypeName => LoanType?.LoanName;

        public int CollateralId => (int) Collateral?.Id;
        public string CollateralName => Collateral?.CollateralType;
        public double CollateralValue => (double)Collateral?.CollateralValue;
        public string CollateralLocation => Collateral?.CollateralLocation;

        public int GuarantorId => (int) Guarantor?.ID;
        public string GuarantorFullName => Guarantor?.FullName;
        public DateTime GuarantorBirthDate => (DateTime)Guarantor?.BirthDate;
        public string GuarantorAddress => Guarantor?.Address;
        public string GuarantorPhone => Guarantor?.Phone;
        public string GuarantorEmail => Guarantor?.Email;

        public int OfficerId => (int) AssignedOfficer?.ID;
        public string OfficerFullName => AssignedOfficer?.FullName;

        public int PaymentId => (int)Payment?.Id;
        public int PaymentNumber => (int)Payment?.PaymentNumber;
        public DateTime PaymentDate => (DateTime)Payment?.PaymentDate;
        public double PaymentPrincipal => (double)Payment?.PrincipalAmount;
        public double PaymentInterest => (double)Payment?.InterestAmount;
        public double PaymentRemaningBalance => (double)Payment?.RemainingBalance;
        public int PaymentIsPaid => (int)Payment?.Is_Paid;

        public Loan() { }

        public Loan(int loanId, Client borrower, LoanType loanType, double loanAmount, double interestRate, int loanTerm, DateTime startDate, DateTime endDate, string status, string paymentFrequency, LoanOfficer assignedOfficer)
        {
            LoanId = loanId;
            Borrower = borrower;
            LoanType = loanType;
            LoanAmount = loanAmount;
            InterestRate = interestRate;
            LoanTerm = loanTerm;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
            PaymentFrequency = paymentFrequency;
            AssignedOfficer = assignedOfficer;
        }

        public Loan(Client borrower, LoanType loanType, double loanAmount, double interestRate, int loanTerm, DateTime startDate, DateTime endDate, string status, string paymentFrequency, Guarantor guarantor, LoanOfficer assignedOfficer)
        {
            Borrower = borrower;
            LoanType = loanType;
            LoanAmount = loanAmount;
            InterestRate = interestRate * 0.01;
            LoanTerm = loanTerm;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
            PaymentFrequency = paymentFrequency;
            Guarantor = guarantor;
            AssignedOfficer = assignedOfficer;
        }
    }
}

// We used the following concepts of OOP to enhance the design and implementation of classes.
// Association - represents a relationship between two or more classes, where obj of a class are connected to obj of another class
// Composition - a form of association where one class contains an instance of another class as a member to represent relationship (indicating that specific customer is associated with a loan)
// Polymorphism - for abstract method such as CalculateInterest(), it will be defined by the subclass
// virtual modifier implies that a method can be modified in a derived class