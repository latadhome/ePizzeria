using ePizzeriaHub.Services.Implementations;
using ePizzeriaHub.Services.Interfaces;
using ePizzeriaHub.WebUI.Helpers;
using ePizzeriaHub.WebUI.Interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace ePizzeriaHub.WebUI.Configuration
{
    public class ServiceDependencies
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IPizzeriaService, PizzeriaService>();
            services.AddTransient<IUserAccessor, UserAccessor>();
            services.AddTransient<ICatalogService, CatalogService>();
            services.AddTransient<IFileHelper, FileHelper>();
            services.AddTransient<ICartService, CartService>();

        }
    }
}
