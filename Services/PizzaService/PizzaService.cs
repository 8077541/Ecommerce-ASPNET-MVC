using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace ecom.Services.PizzaService
{
    public class PizzaService : IPizzaService
    {
        private static List<Pizza> pizzas = new List<Pizza>{
            new Pizza(),
            new Pizza{Id = 1 , Name = "Cappriciosa"}
        };
        public List<Pizza> GetAllPizzas()
        {
            return pizzas;
        }
        public Pizza GetPizzaById(int id)
        {
            return pizzas.FirstOrDefault(p => p.Id == id);
        }
        public List<Pizza> AddPizza(Pizza newPizza)
        {
            pizzas.Add(newPizza);
            return pizzas;

        }
    }
}