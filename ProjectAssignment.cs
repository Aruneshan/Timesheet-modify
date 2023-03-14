#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Original.Models
{
    public partial class ProjectAssignment
    {
        [Key]
        public int ProjectAssignmentId { get; set; }
        public string Status { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        [ForeignKey("ApplicationUser")]
        public string EmployeeId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
