using Microsoft.EntityFrameworkCore;
using SmartCourseSelectorWeb.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// MVC ve API deste�i i�in Controller servislerini ekleyin
builder.Services.AddControllersWithViews();
builder.Services.AddControllers(); // API i�in gerekli

// E�er bir veri taban� ba�lant�s� gerekiyorsa burada ekleyin
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// CORS ekleyin (Postman'den eri�im i�in gerekli)
app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

// MVC Route (�n y�zde �al��mak i�in gerekli)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=LoginUser}");

// API route (Postman �zerinden �al��mas� i�in gerekli)
app.MapControllers();

app.Run();
