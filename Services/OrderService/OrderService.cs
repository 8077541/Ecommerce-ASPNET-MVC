using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ecom.Data;

namespace ecom.Services.OrderService
{
    public class OrderService : IOrderService
    {


        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public OrderService(IMapper mapper, DataContext context)

        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetOrderResponseDto>>> GetAllOrders()
        {
            var serviceResponse = new ServiceResponse<List<GetOrderResponseDto>>();
            var dbOrders = await _context.Orders.ToListAsync();
            serviceResponse.Data = dbOrders.Select(p => _mapper.Map<GetOrderResponseDto>(p)).ToList();
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetOrderResponseDto>> GetOrderById(int id)
        {
            var serviceResponse = new ServiceResponse<GetOrderResponseDto>();
            var dbOrder = await _context.Orders.FirstOrDefaultAsync(p => p.Id == id);
            serviceResponse.Data = _mapper.Map<GetOrderResponseDto>(dbOrder);
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetOrderResponseDto>>> AddOrder(AddOrderRequestDto newOrder)
        {
            var serviceResponse = new ServiceResponse<List<GetOrderResponseDto>>();

            var order = _mapper.Map<Order>(newOrder);

            var pizzas = newOrder.OrderedPizzas.Select(p => _mapper.Map<Pizza>(p)).ToList();

            order.OrderedPizzas = pizzas;

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            serviceResponse.Data = GetAllOrders().Result.Data;

            return serviceResponse;

        }
    }
}