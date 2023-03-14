#nullable disable
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Original.Models;
namespace Original.Models
{
    public class WorkSpace
    {
        [Key]
        public int WorkspaceId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ProjectManagerId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}