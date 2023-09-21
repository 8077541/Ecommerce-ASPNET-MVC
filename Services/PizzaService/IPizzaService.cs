using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ecom.Services.PizzaService
{
    public interface IPizzaService
    {
        Task<ServiceResponse<List<Pizza>>> GetAllPizzas();
        Task<ServiceResponse<Pizza>> GetPizzaById(int id);
        Task<ServiceResponse<List<Pizza>>> AddPizza(Pizza newPizza);
    }
}