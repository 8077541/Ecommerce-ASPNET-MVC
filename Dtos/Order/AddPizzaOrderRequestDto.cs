using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecom.Dtos.Order
{
    public class AddPizzaOrderRequestDto
    {
        public int PizzaId { get; set; }
        public PizzaSize Size { get; set; }
    }
}