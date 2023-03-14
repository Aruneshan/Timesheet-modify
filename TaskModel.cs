#nullable disable
using Original.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;

namespace Original.Models
{
    public class TaskModel
    {
        [Key]
        public int TaskId { get; set; }
        public string TaskName { get; set; }

        [ForeignKey("Workspace")]
        public int WorkspaceId { get; set; }
        public WorkSpace Workspace { get; set; }
    }
}
