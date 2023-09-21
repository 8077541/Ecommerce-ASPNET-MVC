
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
        public async Task<ActionResult<ServiceResponse<List<Pizza>>>> Get()
        {
            return Ok(await _pizzaService.GetAllPizzas());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Pizza>>> GetSingle(int id)
        {
            return Ok(await _pizzaService.GetPizzaById(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Pizza>>>> AddPizza(Pizza newPizza)
        {
            return Ok(await _pizzaService.AddPizza(newPizza));

        }
    }
}