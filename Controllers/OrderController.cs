using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ecom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetOrderResponseDto>>>> Get()
        {
            return Ok(await _orderService.GetAllOrders());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetOrderResponseDto>>> GetSingle(int id)
        {
            var response = await _orderService.GetOrderById(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetOrderResponseDto>>>> AddOrder(AddOrderRequestDto newOrder)
        {
            var response = await _orderService.AddOrder(newOrder);
            return Ok(response);
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetOrderResponseDto>>>> UpdateOrder(UpdateOrderRequestDto updatedOrder){
            var response = await _orderService.UpdateOrder(updatedOrder);
            return Ok(response);
        
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetOrderResponseDto>>>> DeleteOrder(int id){
            var response = await _orderService.DeleteOrder(id);
            return response;
        }
    }
}