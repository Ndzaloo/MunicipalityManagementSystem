using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;


namespace Municipulity_System.Models
{
    public class ServicesRequested
    {
        [Key]
        public int RequestID { get; set; }
        public int CitizenID { get; set; }
        public string?ServiceType { get; set; }
        public DateTime RequestedDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Pending...";
    }
}
