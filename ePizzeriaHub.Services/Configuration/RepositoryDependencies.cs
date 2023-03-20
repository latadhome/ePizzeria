using ePizzeriaHub.Entities;
using ePizzeriaHub.Repositories.Implementations;
using ePizzeriaHub.Repositories.Interfaces;
using ePizzeriaHub.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ePizzeriaHub.Services.Configuration
{
    public class RepositoryDependencies
    {
        public static void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDBContext>((options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });

            services.AddIdentity<User, Role>().
                AddEntityFrameworkStores<AppDBContext>().AddDefaultTokenProviders();

            services.AddScoped<DbContext, AppDBContext>();

            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IRepository<Pizzeria>, Repository<Pizzeria>>();
            services.AddTransient<IRepository<CartItem>, Repository<CartItem>>();
            services.AddTransient<IRepository<Item>, Repository<Item>>();
            services.AddTransient<IRepository<Category>, Repository<Category>>();
            services.AddTransient<IRepository<ItemType>, Repository<ItemType>>();
            services.AddTransient<IRepository<Toppings>, Repository<Toppings>>();
        }
    }
}
