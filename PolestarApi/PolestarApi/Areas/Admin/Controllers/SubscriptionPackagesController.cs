using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApplicationApi.DataAccess.Data;
using PolestarApi.DataBase.Models;

namespace PolestarApi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionPackagesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public SubscriptionPackagesController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: api/SubscriptionPackages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubscriptionPackage>>> GetSubscriptionPackages()
        {
            JsonResult result = new JsonResult(new { });
            var package = await _db.Subscriptions.Join(_db.SubscriptionPackages, s => s.SubscriptionPackageId, sp => sp.SubscriptionPackageId, (s, sp) => new { s, sp }).Join
                (_db.UserAccount,s=>s.s.UserVendorId,u=>u.UserId,(s,u)=>new { s,u}).
                Select(package => new
                {
                    package.u.UserName,
                    package.s.s.PaymentStatus,
                    package.s.s.SubscriptionId,
                    package.s.s.SubscriptionStatus,
                    package.s.s.ExpirationDate,
                    package.s.s.RegisterDate

                }).ToListAsync();

            result.Value = new { Data = package };
            return result;
        }

        // GET: api/SubscriptionPackages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubscriptionPackage>> GetSubscriptionPackage(int id)
        {
            JsonResult result = new JsonResult(new { });

            var subscriptionPackage = await _db.Subscriptions.Join(_db.SubscriptionPackages, s => s.SubscriptionPackageId, sp => sp.SubscriptionPackageId, (s, sp) => new { s, sp }).Join
                (_db.UserAccount, s => s.s.UserVendorId, u => u.UserId, (s, u) => new { s, u }).
                Select(package => new
                {
                    package.u.UserName,
                    package.s.s.PaymentStatus,
                    package.s.s.SubscriptionId,
                    package.s.s.SubscriptionStatus,
                    package.s.s.ExpirationDate,
                    package.s.s.RegisterDate

                }).FirstAsync(s=>s.SubscriptionId==id);
            if (subscriptionPackage == null)
            {
                return NotFound();
            }
            result.Value = new { Data = subscriptionPackage };
            return result;
          
        }

        // PUT: api/SubscriptionPackages/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscriptionPackage(int id, SubscriptionPackage subscriptionPackage)
        {
            if (id != subscriptionPackage.SubscriptionPackageId)
            {
                return BadRequest();
            }

            _db.Entry(subscriptionPackage).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriptionPackageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SubscriptionPackages
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<SubscriptionPackage>> PostSubscriptionPackage(SubscriptionPackage subscriptionPackage)
        {
            _db.SubscriptionPackages.Add(subscriptionPackage);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetSubscriptionPackage", new { id = subscriptionPackage.SubscriptionPackageId }, subscriptionPackage);
        }

        // DELETE: api/SubscriptionPackages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SubscriptionPackage>> DeleteSubscriptionPackage(int id)
        {
            var subscriptionPackage = await _db.SubscriptionPackages.FindAsync(id);
            if (subscriptionPackage == null)
            {
                return NotFound();
            }

            _db.SubscriptionPackages.Remove(subscriptionPackage);
            await _db.SaveChangesAsync();

            return subscriptionPackage;
        }

        private bool SubscriptionPackageExists(int id)
        {
            return _db.SubscriptionPackages.Any(e => e.SubscriptionPackageId == id);
        }
    }
}
