using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using ecom.Data;


namespace ecom.Services.OrderService
{
    [Authorize]
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
            var dbOrders = await _context.Orders.Include(o => o.OrderedPizzas).ToListAsync();
            serviceResponse.Data = dbOrders.Select(p => _mapper.Map<GetOrderResponseDto>(p)).ToList();
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetOrderResponseDto>> GetOrderById(int id)
        {
            var serviceResponse = new ServiceResponse<GetOrderResponseDto>();
            var dbOrder = await _context.Orders.Include(o => o.OrderedPizzas).FirstOrDefaultAsync(p => p.Id == id);
            serviceResponse.Data = _mapper.Map<GetOrderResponseDto>(dbOrder);
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetOrderResponseDto>>> AddOrder(AddOrderRequestDto newOrder)
        {
            var serviceResponse = new ServiceResponse<List<GetOrderResponseDto>>();

            var order = _mapper.Map<Order>(newOrder);

            var pizzas = newOrder.OrderedPizzas.Select(p => _mapper.Map<PizzaOrder>(p)).ToList();

            order.OrderedPizzas = pizzas;


            foreach (PizzaOrder pizza in pizzas)
            {
                _context.PizzaOrders.Add(pizza);
            }

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            serviceResponse.Data = GetAllOrders().Result.Data;

            return serviceResponse;

        }
        public async Task<ServiceResponse<List<GetOrderResponseDto>>> UpdateOrder(UpdateOrderRequestDto updatedOrder)
        {
            var serviceResponse = new ServiceResponse<List<GetOrderResponseDto>>();

            var order = _mapper.Map<Order>(updatedOrder);

            var pizzas = updatedOrder.OrderedPizzas.Select(p => _mapper.Map<Pizza>(p)).ToList();

            // order.OrderedPizzas = pizzas;

            _context.Orders.Update(order);

            await _context.SaveChangesAsync();

            serviceResponse.Data = GetAllOrders().Result.Data;

            return serviceResponse;


        }

        public async Task<ServiceResponse<List<GetOrderResponseDto>>> DeleteOrder(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetOrderResponseDto>>();
            var dbOrder = await _context.Orders.FirstOrDefaultAsync(p => p.Id == id);
            if (dbOrder != null)
            {
                _context.Orders.Remove(dbOrder);
                _context.SaveChanges();
            }
            serviceResponse.Data = GetAllOrders().Result.Data;
            return serviceResponse;
        }
    }
}