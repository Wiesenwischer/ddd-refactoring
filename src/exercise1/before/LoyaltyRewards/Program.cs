using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LoyaltyRewards.DataAccess;
using LoyaltyRewards.Handlers;
using LoyaltyRewards.Messages;
using LoyaltyRewards.Seeding;
using Microsoft.EntityFrameworkCore;
using Serilog.Events;

namespace LoyaltyRewards
{
    class Program
    {
        private static readonly string AppName = typeof(Program).Namespace;

        static async Task Main(string[] args)
        {
            Log.Logger = CreateSerilogLogger();

            IServiceCollection services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            Log.Debug("Starting {ApplicationContext}");

            await MigrateDatabaseAsync(serviceProvider);

            var handler = serviceProvider.GetRequiredService<AssignOfferHandler>();
            try
            {
                var cancellationToken = new CancellationTokenSource().Token;
                await handler.Handle(new AssignOfferRequest
                {
                    MemberId = KnownMemberIds.MaxMustermann,
                    OfferTypeId = KnownOfferTypeIds.SampleFixed
                }, cancellationToken);
                await handler.Handle(new AssignOfferRequest
                {
                    MemberId = KnownMemberIds.MaxMustermann,
                    OfferTypeId = KnownOfferTypeIds.SampleAssignment
                }, cancellationToken);
            }
            catch (Exception e)
            {
                Log.Error(e, "Error handling request");
            }

            Log.Debug("Exiting {ApplicationContext}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static async Task MigrateDatabaseAsync(ServiceProvider serviceProvider)
        {
            Log.Debug("Migrating database");
            await serviceProvider.GetRequiredService<LoyaltyRewardsDbContext>().Database.EnsureCreatedAsync();
            Log.Debug("Migration completed");
        }

        private static IServiceCollection ConfigureServices()
        {
            return new ServiceCollection()
                .AddLogging(loggingBuilder =>
                {
                    loggingBuilder.AddSerilog(dispose: true);
                })
                .AddDbContext<LoyaltyRewardsDbContext>(options =>
                    options.UseSqlServer(@"Server=.;Database=LoyalityRewards;Integrated Security=True"))
                .AddTransient<AssignOfferHandler>()
                .AddSingleton(new HttpClient
                {
                    BaseAddress = new Uri("http://localhost")
                });
        }

        private static ILogger CreateSerilogLogger()
        {
            return new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .WriteTo.Console()
                .Enrich.FromLogContext()
                .Enrich.WithProperty("ApplicationContext", AppName)
                .CreateLogger();
        }
    }
}
