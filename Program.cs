using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TaskBookWebApp.Areas.Identity.Data;
using TaskBookWebApp.Data;
using TaskBookWebApp.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("TaskBookDBContextConnection") ?? throw new InvalidOperationException("Connection string 'TaskBookDBContextConnection' not found.");




// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<TaskBookDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("TaskBookDBContextConnection")));

builder.Services.AddDbContext<TaskBookWebAppContextOne>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("TaskBookDBContextConnection")));

builder.Services.AddDefaultIdentity<TaskBookWebAppUserOne>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<TaskBookWebAppContextOne>();


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
