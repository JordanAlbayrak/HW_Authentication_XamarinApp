using SQLite;

namespace multyPage_XamarinAssign.Models
{
    public class Pet
    {
        [PrimaryKey] [AutoIncrement] public int PetId { get; set; }

        public string PetName { get; set; }
        public string PetType { get; set; }

        public bool IsValid(out string message)
        {
            message = default;
            if (!string.IsNullOrWhiteSpace(PetName) &&
                !string.IsNullOrWhiteSpace(PetType))
                return true;

            message = "Please fill all fields";

            return false;
        }
    }
}