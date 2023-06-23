    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem
{
    // Abstract base class
    public abstract class Person
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Person() { }

        public Person(string lastName, string firstName, string middleName, DateTime birthDate, string address, string phone, string email)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            BirthDate = birthDate;
            Address = address;
            Phone = phone;
            Email = email;
        }

        public Person(int id, string lastName, string firstName, string middleName, DateTime birthDate, string address, string phone, string email)
        {
            ID = id;
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            BirthDate = birthDate;
            Address = address;
            Phone = phone;
            Email = email;
        }

        public Person(int id, string fullName, DateTime birthDate, string address, string phone, string email)
        {
            ID = id;
            FullName = fullName;
            BirthDate = birthDate;
            Address = address;
            Phone = phone;
            Email = email;
        }

        public Person(string fullName, DateTime birthDate, string address, string phone, string email)
        {
            FullName = fullName;
            BirthDate = birthDate;
            Address = address;
            Phone = phone;
            Email = email;
        }
    }
}