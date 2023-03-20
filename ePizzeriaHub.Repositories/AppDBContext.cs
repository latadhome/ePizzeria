using ePizzeriaHub.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ePizzeriaHub.Repositories
{
    public class AppDBContext: IdentityDbContext<User, Role, int>
    {
        //For migration purpose only
        public AppDBContext() { }
        

        // Read Configuration from settings
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Pizzeria> Pizzerias { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<Toppings> Toppings { get; set; }

       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Required For Migration Purpose, Only if not defined in the settings
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=tcp:pk07sqlserver.database.windows.net,1433;Initial Catalog=epizzeriahub;Persist Security Info=False;User ID=sysadmin;Password=Ojas0106;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}