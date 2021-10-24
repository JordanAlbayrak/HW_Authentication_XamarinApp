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
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public string IsValid()
        {
            if (username == null || username.Length <= 0) return "Username must be inputed";

            if (email == null || email.Length <= 0) return "Email must be inputed";

            if (password == null || password.Length <= 0) return "Password must be inputed";

            return null;
        }
    }
}
