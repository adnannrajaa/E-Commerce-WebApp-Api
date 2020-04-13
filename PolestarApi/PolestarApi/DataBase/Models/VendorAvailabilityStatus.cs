using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolestarApi.DataBase.Models
{
    public class VendorAvailabilityStatus
    {
        [Key]
        public int VendorAvailabilityStatusIdId { get; set; }
        public string Value { get; set; }
    }
}
