using Microsoft.EntityFrameworkCore;
using SmartCourseSelectorWeb.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// MVC ve API desteði için Controller servislerini ekleyin
builder.Services.AddControllersWithViews();
builder.Services.AddControllers(); // API için gerekli

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Eðer bir veri tabaný baðlantýsý gerekiyorsa burada ekleyin
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

// CORS ekleyin (Postman'den eriþim için gerekli)
app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

// MVC Route (Ön yüzde çalýþmak için gerekli)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=LoginUser}");

// API route (Postman üzerinden çalýþmasý için gerekli)
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
