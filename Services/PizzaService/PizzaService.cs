using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
namespace ecom.Services.PizzaService
{
    public class PizzaService : IPizzaService
    {
        private static List<Pizza> pizzas = new List<Pizza>{
            new Pizza(),
            new Pizza{Id = 1 , Name = "Cappriciosa"}
        };


        private readonly IMapper _mapper;
        public PizzaService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetPizzaResponseDto>>> GetAllPizzas()
        {
            var serviceResponse = new ServiceResponse<List<GetPizzaResponseDto>>();
            serviceResponse.Data = pizzas.Select(p => _mapper.Map<GetPizzaResponseDto>(p)).ToList();
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetPizzaResponseDto>> GetPizzaById(int id)
        {
            var serviceResponse = new ServiceResponse<GetPizzaResponseDto>();
            var pizza = pizzas.FirstOrDefault(p => p.Id == id) ?? throw new Exception("Pizza not found!");
            serviceResponse.Data = _mapper.Map<GetPizzaResponseDto>(pizza);
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetPizzaResponseDto>>> AddPizza(AddPizzaRequestDto newPizza)
        {
            var serviceResponse = new ServiceResponse<List<GetPizzaResponseDto>>();
            var pizza = _mapper.Map<Pizza>(newPizza);
            pizza.Id = pizzas.Max(p => p.Id) + 1;
            pizzas.Add(pizza);
            serviceResponse.Data = pizzas.Select(p => _mapper.Map<GetPizzaResponseDto>(p)).ToList();
            return serviceResponse;

        }

        public async Task<ServiceResponse<GetPizzaResponseDto>> UpdatePizza(UpdatePizzaRequestDto updatedPizza)
        {
            var serviceResponse = new ServiceResponse<GetPizzaResponseDto>();
            try
            {

                var pizza = pizzas.FirstOrDefault(p => p.Id == updatedPizza.Id) ?? throw new Exception("Pizza not found!");

                pizza.Name = updatedPizza.Name;
                pizza.BasePrice = updatedPizza.BasePrice;
                pizza.Descirption = updatedPizza.Descirption;
                pizza.Ingredients = updatedPizza.Ingredients;
                pizza.Size = updatedPizza.Size;

                serviceResponse.Data = _mapper.Map<GetPizzaResponseDto>(pizza);
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;

            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPizzaResponseDto>>> DeletePizza(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetPizzaResponseDto>>();
            try
            {

                var pizza = pizzas.FirstOrDefault(p => p.Id == id) ?? throw new Exception("Pizza not found!");

                pizzas.Remove(pizza);

                serviceResponse.Data = pizzas.Select(c => _mapper.Map<GetPizzaResponseDto>(c)).ToList();
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;

            }
            return serviceResponse;
        }
    }
}