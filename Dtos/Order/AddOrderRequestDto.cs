using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecom.Dtos.Order;

namespace ecom.Dtos.OrderDto
{
    public class AddOrderRequestDto
    {

        public string City { get; set; }
        public string Province { get; set; }
        public string Street { get; set; }
        public string Apartament { get; set; }
        public int? Floor { get; set; }
        public List<AddPizzaOrderRequestDto> OrderedPizzas { get; set; } = new List<AddPizzaOrderRequestDto>();
        public bool Paid { get; set; } = false;
        public int Price { get; set; }
    }
}