using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecom.Services.OrderService
{
    public interface IOrderService
    {
        Task<ServiceResponse<List<GetOrderResponseDto>>> GetAllOrders();
        Task<ServiceResponse<GetOrderResponseDto>> GetOrderById(int id);
    }
}