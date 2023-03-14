using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Original.Models;

public class Timesheet{
        /*public DateTime WeekStartDate { get; set; }
        public int TotalHours { get; set; }
        public int DevelopmentHours { get; set; }
        public int LearningHours { get; set; }
        public int MeetingHours { get; set; }
        public int MarketingHours { get; set; }
        public int DocumentationHours { get; set; }*/
    [Key]
    public int Id { get; set; }
    [Required]
    public string? EmployeeName { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public TimeSpan TimeIn { get; set; }
    [Required]
    public TimeSpan TimeOut { get; set; }
}


