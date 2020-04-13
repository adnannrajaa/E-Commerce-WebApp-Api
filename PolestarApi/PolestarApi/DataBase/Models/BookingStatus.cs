using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolestarApi.DataBase.Models
{
    public class BookingStatus
    {
        [Key]
        public int BookingStatusId { get; set; }
        public string Name { get; set; }
    }
}
