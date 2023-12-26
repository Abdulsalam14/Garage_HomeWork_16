using Garage_HomeWork_16.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var connection = builder.Configuration.GetConnectionString("myconn");

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(connection);
});

var app = builder.Build();

app.UseStaticFiles();


app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
);

app.MapControllerRoute(
  name: "default",
  pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.MapDefaultControllerRoute();

app.Run();
