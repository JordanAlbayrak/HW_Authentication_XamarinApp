
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace multyPage_XamarinAssign
{
    public class Vet
    {
        [PrimaryKey, AutoIncrement]
        public int VetID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Special { get; set; }

        public bool IsValid(out string message)
        {
            message = default;
            if (!string.IsNullOrWhiteSpace(FirstName) &&
                !string.IsNullOrWhiteSpace(LastName) &&
                !string.IsNullOrWhiteSpace(Email) &&
                !string.IsNullOrWhiteSpace(Phone) &&
                !string.IsNullOrWhiteSpace(Special))
                { return true; }

            message = "Please fill all fields";

            return false;
        }
    }
}