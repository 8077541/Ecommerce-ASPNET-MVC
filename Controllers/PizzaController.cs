
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace ecom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        private static List<Pizza> pizzas = new List<Pizza>{
            new Pizza(),
            new Pizza{Id = 1 , Name = "Cappriciosa"}
        };
        [HttpGet("GetAll")]
        public ActionResult<List<Pizza>> Get()
        {
            return Ok(pizzas);
        }

        [HttpGet("{id}")]
        public ActionResult<List<Pizza>> GetSingle(int id)
        {
            return Ok(pizzas.FirstOrDefault(p => p.Id == id));
        }
        [HttpPost]
        public ActionResult<List<Pizza>> AddPizza(Pizza newPizza)
        {
            pizzas.Add(newPizza);
            return Ok(pizzas);

        }
    }
}