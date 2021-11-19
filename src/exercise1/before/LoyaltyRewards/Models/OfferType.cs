using System;

namespace LoyaltyRewards.Models
{
    public class OfferType
    {
        public Guid OfferTypeId { get; set; }
        public DateTime? BeginDate { get; set; }
        public int DaysValid { get; set; }
        public ExpirationType ExpirationType { get; set; }
        public string Name { get; set; }
    }

    public enum ExpirationType
    {
        Rolling = 0,
        Fixed = 1
    }
}
