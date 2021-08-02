using APIController.Models;
using Microsoft.EntityFrameworkCore;

namespace APIController.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<EmployeeModel> Employees { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
              : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeModel>().HasData(new EmployeeModel
            {
                Id = 1,
                FirstName = "Mohammed",
                LastName = "Alharbi",
                Email = "mohad@harbi.com"
            });
            modelBuilder.Entity<EmployeeModel>().HasData(new EmployeeModel { 
                Id = 3, FirstName = "Ghada", LastName = "Aldahalwi", Email = "smth@gmail.com" });
            modelBuilder.Entity<EmployeeModel>().HasData(new EmployeeModel {
                Id = 4, FirstName = "Sami", LastName = "Aldahalwi", Email = "Sami@gmail.com" });
        }
    }
}