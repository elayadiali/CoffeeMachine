using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeApiMachine.Interfaces;
using Data;
using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace CoffeeApiMachine.Services
{
    public class TypeDrinkService : ITypeDrinkService
    {
        private readonly CoffeeDBContext coffeeDBContext;

        public TypeDrinkService(CoffeeDBContext coffeeDBContext)
        {
            this.coffeeDBContext = coffeeDBContext;
        }

        public async Task<IEnumerable<TypeDrink>> GetAllDrinkTypes()
        {
            return await coffeeDBContext.DrinkTypes.ToListAsync();
        }
    }
}
