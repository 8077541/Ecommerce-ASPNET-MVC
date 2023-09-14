using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ecom.Services.PizzaService
{
    public interface IPizzaService
    {
        List<Pizza> GetAllPizzas();
        Pizza GetPizzaById(int id);
        List<Pizza> AddPizza(Pizza newPizza);
    }
}