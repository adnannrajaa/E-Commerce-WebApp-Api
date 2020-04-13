using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PolestarApi.DataBase.Models;

namespace ApplicationApi.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BookingDetails> BookingDetail { get; set; }
        public DbSet<Bookings> Booking { get; set; }
        public DbSet<BookingStatus> BookingStatus { get; set; }
        public DbSet<CampaignType> CampaignTypes { get; set; }
        public DbSet<DiscountCode> DiscountCodes { get; set; }
        public DbSet<MarketingCampaign> MarketingCampaigns { get; set; }
        public DbSet<Policy> Polices { get; set; }
        public DbSet<PolicyType> PolicyTypes { get; set; }
        public DbSet<Reviews> Review { get; set; }
        public DbSet<Roles> Role { get; set; }
        public DbSet<Services> Service { get; set; }
        public DbSet<ServicesImage> ServiceImages { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionPackage> SubscriptionPackages { get; set; }
        public DbSet<UserAccounts> UserAccount { get; set; }
        public DbSet<VendorAvailabilityStatus> VendorAvailabilityStatus { get; set; }

    }
}
