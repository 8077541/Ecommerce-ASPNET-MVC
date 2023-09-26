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

        public DbSet<Pizza> Pizzas => Set<Pizza>();
    }
}