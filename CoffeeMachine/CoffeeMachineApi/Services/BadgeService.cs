using CoffeeApiMachine.Interfaces;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeApiMachine.Services
{
    public class BadgeService : IBadgeService
    {
        private readonly CoffeeDBContext coffeeDBContext;

        public BadgeService(CoffeeDBContext coffeeDBContext)
        {
            this.coffeeDBContext = coffeeDBContext;
        }

        public string GetOwner(string badgeNumber)
        {
            var badge = coffeeDBContext.Badges.FirstOrDefault(b => b.BadgeNumber == badgeNumber);

            if (badge == null)
            {
                return string.Empty;
            }

            return badge.Owner;
        }
    }
}
