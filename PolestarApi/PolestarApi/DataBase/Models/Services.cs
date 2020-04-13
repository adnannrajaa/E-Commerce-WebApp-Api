﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolestarApi.DataBase.Models
{
    public class Services
    {
        [Key]
        public int ServiceId { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public double Price { get; set; }
    }
}
