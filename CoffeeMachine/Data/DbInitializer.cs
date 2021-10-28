using Data.Model;
using System.Linq;

namespace Data
{
    public static class DbInitializer
    {
        public static void Initialize(CoffeeDBContext context)
        {
            context.Database.EnsureCreated();

            if (context.Badges.Any())
            {
                return; 
            }

            var badges = new Badge[]
            {
                new Badge{Owner="Mahmoud", BadgeNumber="M52874"},
                new Badge{Owner="Ali", BadgeNumber="A82457"},
                new Badge{Owner="Munir", BadgeNumber="S05128"},
            };

            context.Badges.AddRange(badges);
            
            context.SaveChanges();

            var typeDrinks = new TypeDrink[]
            {
                new TypeDrink{Name="Cafe", Price = 5},
                new TypeDrink{Name="Thé", Price = 4 },
                new TypeDrink{Name="Chocolat", Price = 2}
            };

            context.DrinkTypes.AddRange(typeDrinks);

            context.SaveChanges();
        }
    }
}
