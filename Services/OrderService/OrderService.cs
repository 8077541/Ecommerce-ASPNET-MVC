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
            return serviceResponse;
        }
    }
}