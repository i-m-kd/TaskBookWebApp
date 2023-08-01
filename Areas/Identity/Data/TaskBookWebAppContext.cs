using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBookWebApp.Areas.Identity.Data;

namespace TaskBookWebApp.Data;

public class TaskBookWebAppContext : IdentityDbContext<TaskBookWebAppUser>
{
    public TaskBookWebAppContext(DbContextOptions<TaskBookWebAppContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        
        ModelBuilder modelBuilder = builder.ApplyConfiguration(new ApplicationUserConfiguration());
       
    }
}

public class ApplicationUserConfiguration : IEntityTypeConfiguration<TaskBookWebAppUser>
{
    public void Configure(EntityTypeBuilder<TaskBookWebAppUser> builder)
    {
        builder.ToTable("TaskBookWebAppUser", "dbo");
        builder.Property(u => u.FirstName).HasMaxLength(50);
        builder.Property(u => u.LastName).HasMaxLength(50);
        builder.Property(u => u.Age)
               .HasAnnotation("MaxLength", 3)
               .HasAnnotation("MaxValue", 150);
    }
}
