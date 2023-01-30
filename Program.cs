using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt_MVC.Context;
using Projekt_MVC.Models;
using Projekt_MVC.Services.Produkt;
using Projekt_MVC.Services.SklepList;
using Projekt_MVC.Services.Pracownicy;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MainContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ProduktContext")));


builder.Services.AddScoped<IProduktService, ProduktService>();
builder.Services.AddScoped<IPracownicyService, PracownicyService>();
builder.Services.AddScoped<ISklepListService, SklepListService>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{

    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
