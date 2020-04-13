using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolestarApi.DataBase.Models
{
    public class Subscription
    {
        [Key]
        public int SubscriptionId { get; set; }
        public int UserVendorId { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool SubscriptionStatus { get; set; }
        public bool PaymentStatus { get; set; }
        public int SubscriptionPackageId { get; set; }
    }
}
