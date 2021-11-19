using LoyaltyRewards.Models;
using LoyaltyRewards.Seeding;
using Microsoft.EntityFrameworkCore;

namespace LoyaltyRewards.DataAccess
{
    public class LoyaltyRewardsDbContext : DbContext
    {
        public LoyaltyRewardsDbContext(DbContextOptions<LoyaltyRewardsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Offer>().Property("Value").HasPrecision(12, 3);

            modelBuilder.Seed();
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<OfferType> OfferTypes { get; set; }
    }
}
