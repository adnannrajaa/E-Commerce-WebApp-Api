using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolestarApi.DataBase.Models
{
    public class BookingDetails
    {
        [Key]
        public int BookingDetailId { get; set; }
        public int BookingId { get; set; }
        public int ServiceId { get; set; }
        public double Quantity { get; set; }
        public double TotalAmount { get; set; }

    }
}
