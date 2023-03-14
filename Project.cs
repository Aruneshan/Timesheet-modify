#nullable disable
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Original.Models
{
    public partial class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Date Created")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DateCreated { get; set; }

        [ForeignKey("WorkSpace")]
        public int WorkspaceId { get; set; }
        public WorkSpace WorkSpace { get; set; }
    }
}
