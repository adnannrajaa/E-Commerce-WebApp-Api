using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolestarApi.DataBase.Models
{
    public class DiscountCode
    {
        [Key]
        public int DiscountCodeId { get; set; }
        public int UsersCustomerId { get; set; }
        public int UsersVendorId { get; set; }
        public int ServiceId { get; set; }
        public bool IsActive { get; set; }
        public string CodeName { get; set; }
    }
}
