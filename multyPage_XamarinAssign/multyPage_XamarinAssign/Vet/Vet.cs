using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace multyPage_XamarinAssign.Vet
{
    public class Vet
    {
        [PrimaryKey, AutoIncrement]
        public int VetID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Special { get; set; }
    }
}
