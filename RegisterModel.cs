using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Original.Models
{
    public class RegisterModel
    {
        [ForeignKey("Login")]
        public string EmailId { get; set; } = null!;
        [Key]
        public string EmployeeId { get; set; } = null!;
        [Required]
        public string? FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public DateTime Dob { get; set; }
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string ConfirmPassword { get; set; } = null!;

    }
}
