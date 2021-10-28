using CoffeeApiMachine.Controllers;
using CoffeeApiMachine.DTO;
using CoffeeApiMachine.Interfaces;
using CoffeeApiMachine.Services;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CoffeeApiMachine.Test
{
    public class ClientChoiceControllerTest
    {
        private readonly CoffeeDBContext context;

        public ClientChoiceControllerTest()
        {
            var options = new DbContextOptionsBuilder<CoffeeDBContext>()
                .UseInMemoryDatabase(databaseName: "CoffeeClientChoiceTestDB")
                .Options;

            context = new CoffeeDBContext(options);
            DbInitializer.Initialize(context);
        }

        [Fact]
        public void TestClientChoiceService()
        {
            IClientChoiceService clientSelectionService = new ClientChoiceService(context);

            var clientSelectionToAdd = new ClientChoiceDTO()
            {
                BadgeNumber = "M52874",
                DrinkTypeId = 1,
                SugarQty = 17,
                UsePersonalMug = true
            };

            clientSelectionService.AddClientChoice(clientSelectionToAdd);

            var respond1 = clientSelectionService.GetClientChoice("M52874");

            Assert.Equal(clientSelectionToAdd, respond1);

            var updatedClientChoice = new ClientChoiceDTO()
            {
                BadgeNumber = "M52874",
                DrinkTypeId = 2,
                SugarQty = 80,
                UsePersonalMug = false
            };

            clientSelectionService.UpdateClientChoice(updatedClientChoice);
            var respond2 = clientSelectionService.GetClientChoice("M52874");

            Assert.Equal(updatedClientChoice, respond2);
        }

        [Fact]
        public void TestClientChoiceController()
        {
            IClientChoiceService clientSelectionService = new ClientChoiceService(context);
            var clientSelectionController = new ClientChoiceController(clientSelectionService);


            var notFound = clientSelectionController.GetClientChoice("???????");

            Assert.IsType<NotFoundResult>(notFound);
        }
    }
}
