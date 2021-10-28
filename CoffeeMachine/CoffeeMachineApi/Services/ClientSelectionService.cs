using CoffeeApiMachine.DTO;
using CoffeeApiMachine.Interfaces;
using Data;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace CoffeeApiMachine.Services
{
    public class ClientChoiceService : IClientChoiceService
    {
        private readonly CoffeeDBContext coffeeDBContext;

        public ClientChoiceService(CoffeeDBContext coffeeDBContext)
        {
            this.coffeeDBContext = coffeeDBContext;
        }

        public ClientChoiceDTO GetClientChoice(string badgeNumber)
        {
            var badge = coffeeDBContext.Badges
                        .Include(badge => badge.ClientChoice)
                        .ThenInclude(c => c.TypeDrink)
                        .FirstOrDefault(b => b.BadgeNumber == badgeNumber);

            if (badge?.ClientChoice == null)
            {
                return null;
            }

            ClientChoiceDTO clientSelectionDTO = new ClientChoiceDTO();
            clientSelectionDTO.BadgeNumber = badgeNumber;
            clientSelectionDTO.UsePersonalMug = badge.ClientChoice.UsePersonalMug;
            clientSelectionDTO.DrinkTypeId = badge.ClientChoice.TypeDrink.Id;
            clientSelectionDTO.SugarQty = badge.ClientChoice.SugarQty;
            return clientSelectionDTO;
        }

        public void AddClientChoice(ClientChoiceDTO clientSelectionDTO)
        {
            var badge = coffeeDBContext.Badges.FirstOrDefault(b => b.BadgeNumber == clientSelectionDTO.BadgeNumber);
            var drinkType = coffeeDBContext.DrinkTypes.FirstOrDefault(d => d.Id == clientSelectionDTO.DrinkTypeId);
            var clientSelection = new ClientChoice();
            clientSelection.Badge = badge;
            clientSelection.TypeDrink = drinkType;
            clientSelection.UsePersonalMug = clientSelectionDTO.UsePersonalMug;
            clientSelection.SugarQty = clientSelectionDTO.SugarQty;
            coffeeDBContext.ClientChoices.Add(clientSelection);
            coffeeDBContext.SaveChanges();
        }

        public void UpdateClientChoice(ClientChoiceDTO clientSelectionDTO)
        {
            var badge = coffeeDBContext.Badges.FirstOrDefault(b => b.BadgeNumber == clientSelectionDTO.BadgeNumber);
            var drinkType = coffeeDBContext.DrinkTypes.FirstOrDefault(d => d.Id == clientSelectionDTO.DrinkTypeId);

            var clientSelection = coffeeDBContext.ClientChoices.First(cs => cs.Badge.BadgeNumber == clientSelectionDTO.BadgeNumber);
            clientSelection.TypeDrink = drinkType;
            clientSelection.UsePersonalMug = clientSelectionDTO.UsePersonalMug;
            clientSelection.SugarQty = clientSelectionDTO.SugarQty;

            coffeeDBContext.Entry(clientSelection).State = EntityState.Modified;
            coffeeDBContext.SaveChanges();
        }

        
    }
}
