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
    public class PoliciesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public PoliciesController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: api/Policies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Policy>>> GetPolices()
        {
            JsonResult result = new JsonResult(new { });
            var policy = await _db.Polices.Join(_db.PolicyTypes, p => p.PolicyTypeId, pt => pt.PolicyTypeId, (p, pt) =>

                 new { p, pt }).Select(policy => new { policy.p.PolicyId
                 ,policy.pt.Name,policy.p.Detail}).ToListAsync();
            result.Value = new { Data = policy };
            return result;
          
        }

        // GET: api/Policies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Policy>> GetPolicy(int id)
        {
            JsonResult result = new JsonResult(new { });
            var policy = await _db.Polices.Join(_db.PolicyTypes, p => p.PolicyTypeId, pt => pt.PolicyTypeId, (p, pt) =>

                 new { p, pt }).Select(policy => new {
                     policy.p.PolicyId
                 ,
                     policy.pt.Name,
                     policy.p.Detail
                 }).FirstAsync(policy => policy.PolicyId == id);
           
            if (policy == null)
            {
                return NotFound();
            }
            result.Value = new { Data = policy };
            return result;
        }

        // PUT: api/Policies/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolicy(int id, Policy policy)
        {
            if (id != policy.PolicyId)
            {
                return BadRequest();
            }

            _db.Entry(policy).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolicyExists(id))
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

        // POST: api/Policies
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Policy>> PostPolicy(Policy policy)
        {
            _db.Polices.Add(policy);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetPolicy", new { id = policy.PolicyId }, policy);
        }

        // DELETE: api/Policies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Policy>> DeletePolicy(int id)
        {
            var policy = await _db.Polices.FindAsync(id);
            if (policy == null)
            {
                return NotFound();
            }

            _db.Polices.Remove(policy);
            await _db.SaveChangesAsync();

            return policy;
        }

        private bool PolicyExists(int id)
        {
            return _db.Polices.Any(e => e.PolicyId == id);
        }
    }
}
