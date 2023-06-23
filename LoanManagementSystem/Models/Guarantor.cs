using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem
{
    // Lender class will inherit all the public attributes and methods of Person class
    internal class Guarantor : Person
    {
        public string GuarantorType { get; set; }

        public Guarantor() { }

        public Guarantor(string guarantorType, string lastName, string firstName, string middleName, DateTime birthDate, string address, string phone, string email) : base(lastName, firstName, middleName, birthDate, address, phone, email) 
        {
            GuarantorType = guarantorType;
        }

        public Guarantor(int id, string guarantorType, string lastName, string firstName, string middleName, DateTime birthDate, string address, string phone, string email) : base(id, lastName, firstName, middleName, birthDate, address, phone, email)
        {
            GuarantorType = guarantorType;
        }

        public Guarantor(int id, string guarantorType, string fullName, DateTime birthDate, string address, string phone, string email) : base(id, fullName, birthDate, address, phone, email)
        {
            GuarantorType = guarantorType;
        }

        public Guarantor(string guarantorType, string fullName, DateTime birthDate, string address, string phone, string email) : base(fullName, birthDate, address, phone, email)
        {
            GuarantorType = guarantorType;
        }
    }
}
