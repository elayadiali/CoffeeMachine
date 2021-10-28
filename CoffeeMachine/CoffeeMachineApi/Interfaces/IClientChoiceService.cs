using CoffeeApiMachine.DTO;

namespace CoffeeApiMachine.Interfaces
{
    public interface IClientChoiceService
    {
        void AddClientChoice(ClientChoiceDTO clientSelectionDTO);
        
        void UpdateClientChoice(ClientChoiceDTO clientSelectionDTO);

        ClientChoiceDTO GetClientChoice(string badgeNumber);
    }
}