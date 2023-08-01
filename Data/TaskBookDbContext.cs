using Microsoft.EntityFrameworkCore;
using TaskBookWebApp.Areas.Identity.Data;
using TaskBookWebApp.Models;

namespace TaskBookWebApp.Data
{
    public class TaskBookDbContext : DbContext
    {

        public TaskBookDbContext(DbContextOptions<TaskBookDbContext> options) : base(options) 
        { 
        }
        public DbSet<TaskData> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskData>()
                .HasOne<TaskBookWebAppUser>()
                .WithMany()
                .HasForeignKey(t => t.CreatorId)
                .IsRequired();
            modelBuilder.Entity<TaskBookWebAppUser>().ToTable("TaskBookWebAppUser"); // Specify the custom user table name here

        }
    }
}
