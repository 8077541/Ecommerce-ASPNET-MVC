using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ecom.Dtos.Order;


namespace ecom
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Pizza, GetPizzaResponseDto>();
            CreateMap<AddPizzaRequestDto, Pizza>();
            CreateMap<Order, GetOrderResponseDto>();
            CreateMap<AddOrderRequestDto, Order>();
            CreateMap<UpdatePizzaRequestDto, Order>();
            CreateMap<UpdateOrderRequestDto, Order>();
            CreateMap<Ingredient, GetIngredientResponseDto>();
            CreateMap<AddIngredientRequestDto, Ingredient>();
            CreateMap<AddPizzaOrderRequestDto, PizzaOrder>();
            CreateMap<PizzaOrder, AddPizzaOrderRequestDto>();

        }
    }
}