using CoffeeApiMachine.Interfaces;
using Data.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeApiMachine.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeDrinkController : ControllerBase
    {
        private readonly ITypeDrinkService drinkTypeService;

        public TypeDrinkController(ITypeDrinkService drinkTypeService)
        {
            this.drinkTypeService = drinkTypeService;
        }

        [HttpGet]
        public async Task<IEnumerable<TypeDrink>> Get()
        {           
            return await drinkTypeService.GetAllDrinkTypes();
        }
    }
}
