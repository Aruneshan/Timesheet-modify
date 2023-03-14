using System.ComponentModel.DataAnnotations;

namespace Original.Models
{
        public partial class Login
        {
            [Key]
            public string EmailId { get; set; } = null!;
            [Required]
            public string Password { get; set; } = null!;
            [Required]
            public string Usermode { get; set; } = null!;
        }
}
