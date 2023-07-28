using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBookWebApp.Areas.Identity.Data;

namespace TaskBookWebApp.Data;

public class TaskBookWebAppContextOne : IdentityDbContext<TaskBookWebAppUserOne>
{
    public TaskBookWebAppContextOne(DbContextOptions<TaskBookWebAppContextOne> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserConfiguation());
    }
}

internal class ApplicationUserConfiguation : IEntityTypeConfiguration<TaskBookWebAppUserOne>
{

    public void Configure(EntityTypeBuilder<TaskBookWebAppUserOne> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(50);
        builder.Property(u => u.LastName).HasMaxLength(50);
        builder.Property(u => u.Age)
                .HasAnnotation("MaxLength", 3)
                .HasAnnotation("MaxValue", 150);
    }
}