using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LoyaltyRewards.DataAccess
{
    public class LoyaltyRewardsDesignTimeDbContextFactory : IDesignTimeDbContextFactory<LoyaltyRewardsDbContext>
    {
        public LoyaltyRewardsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LoyaltyRewardsDbContext>();
            optionsBuilder.UseSqlServer(@"Server=.;Database=LoyalityRewards;Integrated Security=True");

            return new LoyaltyRewardsDbContext(optionsBuilder.Options);
        }
    }
}
