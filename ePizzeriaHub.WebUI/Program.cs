using ePizzeriaHub.Services.Configuration;
using ePizzeriaHub.Services.Implementations;
using ePizzeriaHub.Services.Interfaces;
using ePizzeriaHub.WebUI.Configuration;
using Microsoft.EntityFrameworkCore.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
RepositoryDependencies.AddServices(builder.Services, builder.Configuration);
ServiceDependencies.AddServices(builder.Services);
var wbuilder = builder.Services.AddControllersWithViews();

#if DEBUG
if (builder.Environment.IsDevelopment())
{
    wbuilder.AddRazorRuntimeCompilation();
}
#endif
var app = builder.Build();


//builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication(); // For Authentication

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
