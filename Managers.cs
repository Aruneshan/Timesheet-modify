#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Original.Models
{
    public partial class Managers
    {
        public Managers()
        {
            InverseManager = new HashSet<Managers>();
        }
        [ForeignKey("RegisterModel")]
        public string EmployeeId { get; set; }
        [Key]
        public string ManagerId { get; set; }

        public virtual ApplicationUser Employee { get; set; }
        public virtual Managers Manager { get; set; }
        public virtual ICollection<Managers> InverseManager { get; set; }
    }

}
