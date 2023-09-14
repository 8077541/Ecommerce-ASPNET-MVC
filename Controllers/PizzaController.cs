
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
        private readonly IPizzaService _pizzaService;
        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<Pizza>> Get()
        {
            return Ok(_pizzaService.GetAllPizzas());
        }

        [HttpGet("{id}")]
        public ActionResult<List<Pizza>> GetSingle(int id)
        {
            return Ok(_pizzaService.GetPizzaById(id));
        }
        [HttpPost]
        public ActionResult<List<Pizza>> AddPizza(Pizza newPizza)
        {
            return Ok(_pizzaService.AddPizza(newPizza));

        }
    }
}