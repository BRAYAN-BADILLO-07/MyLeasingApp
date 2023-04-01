using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MyLeasingApp.Web.Data;


var builder = WebApplication.CreateBuilder(args);


// Inyectamos las dependencias
builder.Services.AddDbContext<DataContext>(
    db => db.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

builder.Services.AddTransient<SeedDb>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Ejecutar las tareas de inicialización de la base de datos
using ( var scope = app.Services.CreateScope() )
{
    var seedDb = scope.ServiceProvider.GetRequiredService<SeedDb>();
    await seedDb.SeedAsync();
}

// Configure the HTTP request pipeline.
if ( !app.Environment.IsDevelopment() )
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


