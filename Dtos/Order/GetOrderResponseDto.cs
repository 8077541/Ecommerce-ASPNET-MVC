using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public List<Pizza> OrderedPizzas { get; set; } = new List<Pizza>();
        public bool Paid { get; set; } = false;

        public int Price { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}