using System.ComponentModel.DataAnnotations;

namespace Municipulity_System.Models
{
    public class Citizen
    {
        [Key]
        public int CitizenID { get; set; }
        public string?FullName { get; set; }
        public string?Address { get; set; }
        public string?Email { get; set; }
        public string?PhoneNUmber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime RegisteredDate { get; set; } 
    }
}
