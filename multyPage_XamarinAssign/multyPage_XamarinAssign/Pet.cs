using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace multyPage_XamarinAssign
{
    public class Pet
    {
        [PrimaryKey, AutoIncrement]
        public int PetID { get; set; }
        public string PetName { get; set; }
        public string PetType { get; set; }

        public string IsValid()
        {
            if (PetName == null || PetName.Length <= 0) return "Pet Name must be inputed";

            if (PetType == null || PetType.Length <= 0) return "Pet type must be inputed";

            return null;
        }
    }

}