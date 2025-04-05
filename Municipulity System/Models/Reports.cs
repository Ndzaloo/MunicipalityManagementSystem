using System;
using System.ComponentModel.DataAnnotations;

namespace Municipulity_System.Models
{
    public class Reports
    {
        [Key]
        public int ReportID { get; set; }
        public int CitizenID { get; set; }
        public string?ReportType { get; set; }
        public string?Title { get; set; }  
        public string?Content { get; set; }
        public string?Details { get; set; }
        public DateTime SubmissionDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Still reviewing";
    }
}
