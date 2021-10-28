namespace Data
{
    using Data.Model;
    using Microsoft.EntityFrameworkCore;

    public class CoffeeDBContext : DbContext
    {
        public CoffeeDBContext(DbContextOptions<CoffeeDBContext> options)
            : base(options)
        {
        }

        public DbSet<Badge> Badges { get; set; }

        public DbSet<ClientChoice> ClientChoices { get; set; }

        public DbSet<TypeDrink> DrinkTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Badge>()
                .HasOne(b => b.ClientChoice)
                .WithOne(b => b.Badge)
                .HasForeignKey<ClientChoice>(e => e.BadgeId);
        }

    }
}
