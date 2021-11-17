

namespace multyPage_XamarinAssign.Models
{
    public class Vet
    {
        public string VetId { get; set; }

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
                return true;

            message = "Please fill all fields";

            return false;
        }
    }
}