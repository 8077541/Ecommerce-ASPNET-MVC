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
        public async Task<ServiceResponse<List<Pizza>>> GetAllPizzas()
        {
            var serviceResponse = new ServiceResponse<List<Pizza>>();
            serviceResponse.Data = pizzas;
            return serviceResponse;
        }
        public async Task<ServiceResponse<Pizza>> GetPizzaById(int id)
        {
            var serviceResponse = new ServiceResponse<Pizza>();
            var pizza = pizzas.FirstOrDefault(p => p.Id == id) ?? throw new Exception("Pizza not found!");
            serviceResponse.Data = pizza;
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<Pizza>>> AddPizza(Pizza newPizza)
        {
            var serviceResponse = new ServiceResponse<List<Pizza>>();
            pizzas.Add(newPizza);
            serviceResponse.Data = pizzas;
            return serviceResponse;

        }
    }
}