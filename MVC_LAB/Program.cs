using MVC_PROJEKT.Context;
using MVC_PROJEKT.Models;
using Microsoft.EntityFrameworkCore;
using MVC_PROJEKT.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PracownicyContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("PracownicyContext")));
builder.Services.AddDbContext<ProduktyContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ProduktyContext")));
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPersonservice, Personservice>();
builder.Services.AddScoped<IProduktservice, Produktservice>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    //SeedData.Initialize(services);
}


// Configure the HTTP request pipeline.
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
