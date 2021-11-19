using LoyaltyRewards.DataAccess;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace LoyaltyRewards
{
    internal class MigrationHandler
    {
        private readonly ILogger<MigrationHandler> _logger;

        public MigrationHandler(ILogger<MigrationHandler> logger)
        {
            _logger = logger;
        }

        public async Task MigrateDatabaseAsync(LoyaltyRewardsDbContext dbContext)
        {
            var dbContextName = dbContext.GetType().Name;
           
            _logger.LogDebug("Migrating database for context {DbContext}", dbContextName);
            await dbContext.Database.EnsureCreatedAsync();
            _logger.LogDebug("Migration for context {DbContext} completed", dbContextName);
        }
    }
}