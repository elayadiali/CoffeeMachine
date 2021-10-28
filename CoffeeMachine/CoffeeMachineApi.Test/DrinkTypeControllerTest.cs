using CoffeeApiMachine.Controllers;
using CoffeeApiMachine.Interfaces;
using CoffeeApiMachine.Services;
using Data;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CoffeeApiMachine.Test
{
    public class DrinkTypeControllerTest
    {
        private readonly CoffeeDBContext context;

        public DrinkTypeControllerTest()
        {
            var options = new DbContextOptionsBuilder<CoffeeDBContext>()
                .UseInMemoryDatabase(databaseName: "CoffeeDrinkTypeTestDB")
                .Options;

            context = new CoffeeDBContext(options);
            DbInitializer.Initialize(context);
        }

        [Fact]
        public async Task TestDrinkTypeService()
        {
            ITypeDrinkService drinkTypeService = new TypeDrinkService(context);

            IEnumerable<TypeDrink> typeDrinks = await drinkTypeService.GetAllDrinkTypes();
            
            Assert.Equal(3, typeDrinks.Count());
        }

        [Fact]
        public async Task TestDrinkTypeController()
        {
            ITypeDrinkService drinkTypeService = new TypeDrinkService(context);

            var drinkTypeController = new TypeDrinkController(drinkTypeService);

            IEnumerable<TypeDrink> typeDrinks = await drinkTypeController.Get();

            Assert.Equal(3, typeDrinks.Count());
        }
    }
}
