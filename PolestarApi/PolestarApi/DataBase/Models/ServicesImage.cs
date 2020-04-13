using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolestarApi.DataBase.Models
{
    public class ServicesImage
    {
        [Key]
        public int ServiceImageId { get; set; }
        public int ServiceId { get; set; }
        public string Url { get; set; }
    }
}
