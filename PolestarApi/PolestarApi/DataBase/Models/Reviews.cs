using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolestarApi.DataBase.Models
{
    public class Reviews
    {
        [Key]
        public int ReviewId { get; set; }
        public int BookingId { get; set; }
        public int UsersVendorId { get; set; }
        public string Details { get; set; }
    }
}
