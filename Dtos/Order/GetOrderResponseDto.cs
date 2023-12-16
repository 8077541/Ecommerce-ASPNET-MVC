using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecom.Dtos.Order;

namespace ecom.Dtos.OrderDto
{
    public class GetOrderResponseDto
    {
        public int Id { get; set; }
        public string City { get; set; } = "City";
        public string Province { get; set; } = "Province";
        public string Street { get; set; } = "Street";
        public string Apartament { get; set; } = "Apartament";
        public int? Floor { get; set; }
        public List<AddPizzaOrderRequestDto> OrderedPizzas { get; set; } = new List<AddPizzaOrderRequestDto>();
        public bool Paid { get; set; } = false;

        public int Price { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}