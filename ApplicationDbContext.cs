using Exercise_1_BackgroundJobApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercise_1_BackgroundJobApp
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;user=thaivu;password=password123;database=VNGTestDB;trusted_connection=true;");
        }
    }
}
