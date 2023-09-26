using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecom.Dtos.Pizza;
using Microsoft.AspNetCore.Mvc;

namespace ecom.Services.PizzaService
{
    public interface IPizzaService
    {
        Task<ServiceResponse<List<GetPizzaResponseDto>>> GetAllPizzas();
        Task<ServiceResponse<GetPizzaResponseDto>> GetPizzaById(int id);
        Task<ServiceResponse<List<GetPizzaResponseDto>>> AddPizza(AddPizzaRequestDto newPizza);
        Task<ServiceResponse<GetPizzaResponseDto>> UpdatePizza(UpdatePizzaRequestDto updatedPizza);
        Task<ServiceResponse<List<GetPizzaResponseDto>>> DeletePizza(int id);

    }
}