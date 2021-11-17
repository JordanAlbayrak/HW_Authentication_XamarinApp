

namespace multyPage_XamarinAssign.Models
{
    public class Owner
    {
        public string OwnerId { get; set; }

        public string OwnerLastName { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerPhoneNumber { get; set; }

        public int PetId1 { get; set; }
        public int PetId2 { get; set; }

        public bool IsValid(out string message)
        {
            message = default;
            if (!string.IsNullOrWhiteSpace(OwnerLastName) &&
                !string.IsNullOrWhiteSpace(OwnerFirstName) &&
                !string.IsNullOrWhiteSpace(OwnerLastName))
                return true;

            message = "Please fill all fields";

            return false;
        }
    }
}