using Microsoft.EntityFrameworkCore;
using TaskBookWebApp.Models;

namespace TaskBookWebApp.Data
{
    public class TaskBookDbContext : DbContext
    {

        public TaskBookDbContext(DbContextOptions<TaskBookDbContext> options) : base(options) 
        { 
        }
        public DbSet<UserData> Users { get; set; }
        public DbSet<TaskData> Tasks { get; set; }
    }
}
