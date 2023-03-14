#nullable disable
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Original.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string Project { get; set; }
        [ForeignKey("Login")]
        public string EmailId { get; set; }
        [Required]
        public string ProjectAssigned { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public DateTime CreatedDateTime { get; set; }
    }
}
