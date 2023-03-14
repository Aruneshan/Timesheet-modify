#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Original.Models;
namespace Original.Data;

public partial class OriginalContext : DbContext
{
    public OriginalContext()
    {
    }

    public OriginalContext(DbContextOptions<OriginalContext> options)
        : base(options)
    {

    }
    public DbSet<Login> Login { get; set; }
    public DbSet<RegisterModel> RegisterModel { get; set; }
    public DbSet<EmployeeModel> EmployeeModel { get; set; }
    public DbSet<Original.Models.Managers> Managers { get; set; }
    public DbSet<Original.Models.Project> Project { get; set; }
    public DbSet<Original.Models.TaskModel> TaskModel { get; set; }
    public DbSet<Original.Models.ApplicationUser> ApplicationUser { get; set; }
    public DbSet<Original.Models.Timesheet> Timesheet { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=ASPIRE1172; Database=Original; Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
