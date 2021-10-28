using Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeApiMachine.Interfaces
{
    public interface ITypeDrinkService
    {
        Task<IEnumerable<TypeDrink>> GetAllDrinkTypes();
    }
}