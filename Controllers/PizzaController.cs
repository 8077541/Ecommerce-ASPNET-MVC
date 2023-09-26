
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
        public async Task<ActionResult<ServiceResponse<List<GetPizzaResponseDto>>>> Get()
        {
            return Ok(await _pizzaService.GetAllPizzas());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetPizzaResponseDto>>> GetSingle(int id)
        {
            return Ok(await _pizzaService.GetPizzaById(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetPizzaResponseDto>>>> AddPizza(AddPizzaRequestDto newPizza)
        {
            return Ok(await _pizzaService.AddPizza(newPizza));

        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetPizzaResponseDto>>>> UpdatePizza(UpdatePizzaRequestDto updatedPizza)
        {
            var response = await _pizzaService.UpdatePizza(updatedPizza);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetPizzaResponseDto>>> DeletePizza(int id)
        {
            var response = await _pizzaService.DeletePizza(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}