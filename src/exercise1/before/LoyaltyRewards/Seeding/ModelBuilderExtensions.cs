using LoyaltyRewards.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace LoyaltyRewards.Seeding
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().HasData(
                new Member
                {
                    MemberId = KnownMemberIds.MaxMustermann,
                    Email = "max.mustermann@dammann-web.eu",
                    FirstName = "Max",
                    LastName = "Mustermann"
                }
            );

            modelBuilder.Entity<OfferType>().HasData(
                new OfferType
                {
                    OfferTypeId = KnownOfferTypeIds.SampleFixed,
                    Name = "Sample with fixed expiration date",
                    BeginDate = DateTime.Today.AddDays(-5),
                    DaysValid = 30,
                    ExpirationType = ExpirationType.Fixed
                });
            modelBuilder.Entity<OfferType>().HasData(
                new OfferType
                {
                    OfferTypeId = KnownOfferTypeIds.SampleAssignment,
                    Name = "Sample with expiration date based on assignment date",
                    DaysValid = 14,
                    ExpirationType = ExpirationType.Rolling
                });
        }
    }

    public static class KnownMemberIds
    {
        public static readonly Guid MaxMustermann = Guid.Parse("{A82D4ED6-4A59-44F0-980D-4D55DDF6889C}");
    }

    public static class KnownOfferTypeIds
    {
        public static readonly Guid SampleFixed = Guid.Parse("{B3316139-B476-49BE-9A44-FFCB5AD8E288}");
        public static readonly Guid SampleAssignment = Guid.Parse("{937CA779-B4A3-4BDB-9BF7-35558A3EE544}");
    }
}
