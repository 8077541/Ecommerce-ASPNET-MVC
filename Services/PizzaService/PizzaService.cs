using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ecom.Data;
namespace ecom.Services.PizzaService
{
    public class PizzaService : IPizzaService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public PizzaService(IMapper mapper, DataContext context)

        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetPizzaResponseDto>>> GetAllPizzas()
        {
            var serviceResponse = new ServiceResponse<List<GetPizzaResponseDto>>();
            var dbPizzas = await _context.Pizzas.Include(p => p.Ingredients).ToListAsync();
            serviceResponse.Data = dbPizzas.Select(p => _mapper.Map<GetPizzaResponseDto>(p)).ToList();
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetPizzaResponseDto>> GetPizzaById(int id)
        {
            var serviceResponse = new ServiceResponse<GetPizzaResponseDto>();
            var dbPizza = await _context.Pizzas.Include(p => p.Ingredients).FirstOrDefaultAsync(p => p.Id == id);
            serviceResponse.Data = _mapper.Map<GetPizzaResponseDto>(dbPizza);

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetPizzaResponseDto>>> AddPizza(AddPizzaRequestDto newPizza)
        {
            var serviceResponse = new ServiceResponse<List<GetPizzaResponseDto>>();
            var pizza = _mapper.Map<Pizza>(newPizza);

            var ingredients = newPizza.Ingredients.Select(i => _mapper.Map<Ingredient>(i)).ToList();
            pizza.Ingredients = ingredients;
            _context.Pizzas.Add(pizza);
            await _context.SaveChangesAsync();
            serviceResponse.Data = GetAllPizzas().Result.Data;
            return serviceResponse;

        }

        public async Task<ServiceResponse<GetPizzaResponseDto>> UpdatePizza(UpdatePizzaRequestDto updatedPizza)
        {
            var serviceResponse = new ServiceResponse<GetPizzaResponseDto>();
            try
            {

                var pizza = await _context.Pizzas.FirstOrDefaultAsync(p => p.Id == updatedPizza.Id);

                pizza.Name = updatedPizza.Name;
                pizza.BasePrice = updatedPizza.BasePrice;
                pizza.Descirption = updatedPizza.Descirption;
                pizza.Ingredients = updatedPizza.Ingredients;
                pizza.Size = updatedPizza.Size;

                serviceResponse.Data = _mapper.Map<GetPizzaResponseDto>(pizza);
                _context.SaveChanges();
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

            var pizza = await _context.Pizzas.FirstOrDefaultAsync(p => p.Id == id);

            if (pizza != null)
            {
                _context.Pizzas.Remove(pizza);
                _context.SaveChanges();
            }
            serviceResponse.Data = GetAllPizzas().Result.Data;
            return serviceResponse;
        }
    }
}