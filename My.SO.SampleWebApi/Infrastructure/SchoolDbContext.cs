using Microsoft.EntityFrameworkCore;
using My.SO.SampleWebApi.Models;

namespace My.SO.SampleWebApi.Infrastructure
{
 
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}
