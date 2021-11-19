using System;
using System.Collections.Generic;

namespace LoyaltyRewards.Models
{
    public class Member
    {
        public Member()
        {
            AssignedOffers = new List<Offer>();
        }

        public Guid MemberId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NumberOfActiveOffers { get; set; }
        public List<Offer> AssignedOffers { get; set; }
    }
}
