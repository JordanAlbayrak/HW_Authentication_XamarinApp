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

        public string IsValid()
        {
            if (Username == null || Username.Length <= 0) return "Username must be inputed";

            if (FirstName == null || FirstName.Length <= 0) return "First Name must be inputed";

            if (LastName == null || LastName.Length <= 0) return "Last Name must be inputed";

            if (Email == null || Email.Length <= 0) return "Email must be inputed";

            if (Phone == null || Phone.Length <= 0) return "Phone number must be inputed";

            if (Password == null || Password.Length < 10) return "Password must be inputed";

            return null;
        }
    }
}