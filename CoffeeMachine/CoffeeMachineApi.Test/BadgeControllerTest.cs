using CoffeeApiMachine.Controllers;
using CoffeeApiMachine.Interfaces;
using CoffeeApiMachine.Services;
using Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CoffeeApiMachine.Test
{
    public class BadgeControllerTest
    {
        private readonly CoffeeDBContext context;

        public BadgeControllerTest()
        {
            var options = new DbContextOptionsBuilder<CoffeeDBContext>()
                .UseInMemoryDatabase(databaseName: "CoffeeBadgeTestDB")
                .Options;

            context = new CoffeeDBContext(options);
            DbInitializer.Initialize(context);
        }

        [Fact]
        public void TestBadgeService()
        {            
            IBadgeService badgeService = new BadgeService(context);

            string onwer = badgeService.GetOwner("M52874");

            Assert.Equal("Mahmoud", onwer);
        }

        [Fact]
        public void TestBadgeController()
        {
            IBadgeService badgeService = new BadgeService(context);
            var badgeController = new BadgeController(badgeService);
            
            string onwer = badgeController.GetOnwer("A82457");

            Assert.Equal("Ali", onwer);
        }
    }
}
