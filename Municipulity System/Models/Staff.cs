using System.ComponentModel.DataAnnotations;

namespace Municipulity_System.Models
{
    public class Staff
    {
        [Key]
        public int StaffID { get; set; }
        public string?StaffName { get; set; }
        public string?Occupation { get; set; }
        public string?Department { get; set; }
        public string?Email { get; set; }
        public string?PhoneNumber { get; set; }
        public DateTime DateOfHire { get; set; } = DateTime.Now.Date;
    }
}
