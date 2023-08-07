using Microsoft.EntityFrameworkCore;
using TaskBookWebApp.Data;
using Microsoft.AspNetCore.Identity;
using TaskBookWebApp.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("TaskBookDBContextConnection") ?? throw new InvalidOperationException("Connection string 'TaskBookDBContextConnection' not found.");


builder.Services.AddScoped(_ => new ConnectionHelper(connectionString));


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<TaskBookWebAppContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("TaskBookDBContextConnection")));

builder.Services.AddDefaultIdentity<TaskBookWebAppUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<TaskBookWebAppContext>();

builder.Services.AddScoped<UserManager<TaskBookWebAppUser>>();
builder.Services.AddAuthentication();


builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseAuthentication();
app.UseAuthorization();
app.Run();
