using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolestarApi.DataBase.Models
{
    public class Bookings
    {
        [Key]
        public int BookingId { get; set; }
        public int UsersVendorId { get; set; }
        public int UsersCustomerId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double TotalAmount { get; set; }
        public int BookingStatusId { get; set; }
    }
}
