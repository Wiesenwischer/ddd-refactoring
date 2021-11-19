using LoyaltyRewards.DataAccess;
using LoyaltyRewards.Messages;
using LoyaltyRewards.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace LoyaltyRewards.Handlers
{
    public class AssignOfferHandler
        : IHandleMessages<AssignOfferRequest>
    {
        private readonly LoyaltyRewardsDbContext _dbContext;
        private readonly HttpClient _httpClient;

        public AssignOfferHandler(LoyaltyRewardsDbContext dbContext, HttpClient httpClient)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task Handle(AssignOfferRequest message, CancellationToken cancellationToken)
        {
            var member = await _dbContext.Members
                .FindAsync(new object[] { message.MemberId }, cancellationToken);
            var offerType = await _dbContext.OfferTypes
                .FindAsync(new object[] { message.OfferTypeId }, cancellationToken);

            // Calculate offer value
            //var response = await _httpClient.GetAsync(
            //    $"/calculate-offer-value?email={member.Email}&offerType={offerType.Name}",
            //    cancellationToken);
            
            //response.EnsureSuccessStatusCode();

            //var responseString = await response.Content.ReadAsStringAsync(cancellationToken);
            //var value = JsonConvert.DeserializeObject<decimal>(responseString);
            decimal value = 100.50m;

            // Calculate expiration date
            DateTime dateExpiring;
            switch (offerType.ExpirationType)
            {
                case ExpirationType.Rolling:
                    dateExpiring = DateTime.Today.AddDays(offerType.DaysValid);
                    break;
                case ExpirationType.Fixed:
                    dateExpiring = offerType.BeginDate?.AddDays(offerType.DaysValid)
                        ?? throw new InvalidOperationException();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            // Assign offer
            var offer = new Offer
            {
                MemberAssigned = member,
                Type = offerType,
                Value = value,
                DateExpiring = dateExpiring
            };
            member.AssignedOffers.Add(offer);
            member.NumberOfActiveOffers++;

            await _dbContext.Offers.AddAsync(offer, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
