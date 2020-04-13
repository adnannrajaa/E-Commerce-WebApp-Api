using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationApi.DataAccess.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PolestarApi.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public FinanceController(ApplicationDbContext db)
        {
            _db = db;
        }

       [HttpGet]
       public ActionResult FinanceReport()
        {
            JsonResult result = new JsonResult(new { });

            var marketing = _db.MarketingCampaigns.Join(_db.UserAccount, m => m.UserVendorId, u => u.UserId, (m, u) => new { m, u }).
                Join(_db.CampaignTypes, c => c.m.CampaignTypeId, ct => ct.CampaignTypeId, (c, ct) => new { c, ct }).
                Join(_db.Service, mc => mc.c.m.ServiceId, s => s.ServiceId, (mc, s) => new { mc, s }).
                Select(marketingRequests => new
                {
                    marketingRequests.mc.c.m.MarketingCampaignId,
                    marketingRequests.mc.c.u.UserName,
                    marketingRequests.mc.c.u.Email,
                    marketingRequests.mc.ct.Name,
                    marketingRequests.mc.c.m.Image

                }).ToList();

            if (marketing == null)
            {
                return NotFound();
            }
            result.Value = new { Data = marketing };
            return result;
        }

    }
}