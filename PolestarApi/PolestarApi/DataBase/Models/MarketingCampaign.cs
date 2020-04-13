using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolestarApi.DataBase.Models
{
    public class MarketingCampaign
    {
        [Key]
        public int MarketingCampaignId { get; set; }
        public int UserVendorId { get; set; }
        public int CampaignTypeId { get; set; }
        public string Image { get; set; }
        public int ServiceId { get; set; }
        public bool Stauts { get; set; }

    }
}
