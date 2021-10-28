using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeApiMachine.Interfaces
{
    public interface IBadgeService
    {
        public string GetOwner(string badgeNumber);
    }
}
