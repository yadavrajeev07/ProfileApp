using UserProfileApp.Models;
using UserProfileApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("MongoDBSettings"));
builder.Services.AddSingleton<UserProfileService>();

builder.Services.AddControllersWithViews();
var app = builder.Build();

// Routing
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");
app.Run();
