using Microsoft.EntityFrameworkCore;
using WasteFood.Data;

var builder = WebApplication.CreateBuilder(args);

// Use connection string named "DefaultConnection" from appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();
builder.Services.AddSession(); // Moved this line up to avoid duplicate `app` variable issue

builder.Services.AddSession();
var app = builder.Build();

app.UseSession();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession(); // Ensure this is placed after UseRouting()

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=CDashboard}/{id?}");

app.Run();
