using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecom.Dtos.IngredientDto
{
    public class GetIngredientResponseDto
    {
        public int IngredientId { get; set; }
        public string Name { get; set; } = null!;

        public int PizzaId { get; set; }
    }
}