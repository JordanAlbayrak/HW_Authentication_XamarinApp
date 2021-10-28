using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace multyPage_XamarinAssign
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public bool IsValid(out string message)
        {
            message = default;
            if (!string.IsNullOrWhiteSpace(Username) &&
                !string.IsNullOrWhiteSpace(FirstName) &&
                !string.IsNullOrWhiteSpace(LastName) &&
                !string.IsNullOrWhiteSpace(Email) &&
                !string.IsNullOrWhiteSpace(Phone) &&
                !string.IsNullOrWhiteSpace(Password) &&
                Password.Length >= 10)
            { return true; }

            message = "Please fill all fields and the password must be atleast 10 characters.";

            return false;
        }
    }
}