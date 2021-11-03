using System;
using System.Collections.Generic;
using SQLite;

namespace multyPage_XamarinAssign.Models
{
    public class Owner
    {
        [PrimaryKey]
        public int OwnerId { get; set; }
        public string OwnerLastName { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerPhoneNumber { get; set; }
        
        public int PetId1 { get; set; }
        public int PetId2 { get; set; }
    }
}