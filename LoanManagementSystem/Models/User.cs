using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem
{
    /// <summary>
    /// User class will inherit all of the public attributes and methods of the abstract Person class
    /// </summary>
    public class User : Person
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User() { }

        public User(string lastName, string firstName, string middleName, DateTime birthDate, string address, string phone, string email, string username, string password) : base(lastName, firstName, middleName, birthDate, address, phone, email) 
        {
            Username = username;
            Password = password;
        }
    }
}