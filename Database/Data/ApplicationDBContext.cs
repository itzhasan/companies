using Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions)
       : base(dbContextOptions)
    {
    }

    public DbSet<Company.Models.Company> Companies { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Company.Models.Company>()
            .HasMany(s => s.Departments)
            .WithOne(c => c.Company)
            .HasForeignKey(c => c.CompanyId);

        modelBuilder.Entity<Department>()
            .HasMany(s => s.Employees)
            .WithOne(c => c.Department)
            .HasForeignKey(c => c.DepartmentId);

        modelBuilder.Entity<Department>().HasIndex(u => u.Name).IsUnique();

    }
}
