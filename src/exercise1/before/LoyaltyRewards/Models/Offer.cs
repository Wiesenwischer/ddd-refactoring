using System;

namespace LoyaltyRewards.Models
{
    public class Offer
    {
        public Guid OfferId { get; set; }
        public DateTime DateExpiring { get; set; }
        public decimal Value { get; set; }
        public Member MemberAssigned { get; set; }
        public OfferType Type { get; set; }
    }
}
