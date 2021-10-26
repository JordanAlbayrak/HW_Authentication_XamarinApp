using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace multyPage_XamarinAssign.Pet
{
    class Pet
    {
        [PrimaryKey, AutoIncrement]
        public int PetID { get; set; }
        public string PetName { get; set; }
        public string PetType { get; set; }
    }
}
