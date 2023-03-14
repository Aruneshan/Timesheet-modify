#nullable disable
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Original.Models;
using Microsoft.EntityFrameworkCore;

namespace Original.Models
{
    public class ApplicationUser 
    {
        [Key]
        public string ProjectManagerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}