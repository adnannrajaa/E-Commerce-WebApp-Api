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
    public class PolicyTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public PolicyTypesController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: api/PolicyTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PolicyType>>> GetPolicyTypes()
        {
            return await _db.PolicyTypes.ToListAsync();
        }

        // GET: api/PolicyTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PolicyType>> GetPolicyType(int id)
        {
            var policyType = await _db.PolicyTypes.FindAsync(id);

            if (policyType == null)
            {
                return NotFound();
            }

            return policyType;
        }

        // PUT: api/PolicyTypes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolicyType(int id, PolicyType policyType)
        {
            if (id != policyType.PolicyTypeId)
            {
                return BadRequest();
            }

            _db.Entry(policyType).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolicyTypeExists(id))
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

        // POST: api/PolicyTypes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PolicyType>> PostPolicyType(PolicyType policyType)
        {
            _db.PolicyTypes.Add(policyType);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetPolicyType", new { id = policyType.PolicyTypeId }, policyType);
        }

        // DELETE: api/PolicyTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PolicyType>> DeletePolicyType(int id)
        {
            var policyType = await _db.PolicyTypes.FindAsync(id);
            if (policyType == null)
            {
                return NotFound();
            }

            _db.PolicyTypes.Remove(policyType);
            await _db.SaveChangesAsync();

            return policyType;
        }

        private bool PolicyTypeExists(int id)
        {
            return _db.PolicyTypes.Any(e => e.PolicyTypeId == id);
        }
    }
}
