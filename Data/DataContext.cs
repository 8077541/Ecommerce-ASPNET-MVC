using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ecom.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Pizzeria;Trusted_Connection=true;TrustServerCertificate=true;");
        }
        public DbSet<Pizza> Pizzas => Set<Pizza>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Ingredient> Ingredients => Set<Ingredient>();
        public DbSet<PizzaOrder> PizzaOrders => Set<PizzaOrder>();

    }
}