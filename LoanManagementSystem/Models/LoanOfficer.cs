using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem
{
    // Lender class will inherit all the public attributes and methods of Person class
    internal class LoanOfficer : Person
    {
        public LoanOfficer() { }
        public LoanOfficer(string lastName, string firstName, string middleName, DateTime birthDate, string address, string phone, string email) : base (lastName, firstName, middleName, birthDate, address, phone, email) { }

        public LoanOfficer(int id, string fullName, DateTime birthDate, string address, string phone, string email) : base(id, fullName, birthDate, address, phone, email) { }

        public LoanOfficer(int id, string lastName, string firstName, string middleName, DateTime birthDate, string address, string phone, string email) : base(id, lastName, firstName, middleName, birthDate, address, phone, email) { }
    }
}
