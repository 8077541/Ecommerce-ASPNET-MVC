using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace ecom
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Pizza, GetPizzaResponseDto>();
            CreateMap<AddPizzaRequestDto, Pizza>();
            CreateMap<Order, GetOrderResponseDto>();
        }
    }
}