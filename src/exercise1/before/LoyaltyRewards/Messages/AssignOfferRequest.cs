using System;

namespace LoyaltyRewards.Messages
{
    public class AssignOfferRequest
    {
        public Guid MemberId { get; set; }
        public Guid OfferTypeId { get; set; }
    }
}