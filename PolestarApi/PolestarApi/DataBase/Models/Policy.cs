using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolestarApi.DataBase.Models
{
    public class Policy
    {
        [Key]
        public int PolicyId { get; set; }
        public int PolicyTypeId { get; set; }
        public string Language { get; set; }
        public string Detail { get; set; }
    }
}
