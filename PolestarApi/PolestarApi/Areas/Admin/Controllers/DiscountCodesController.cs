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
    public class DiscountCodesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public DiscountCodesController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: api/DiscountCodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiscountCode>>> GetDiscountCodes()
        {
            return await _db.DiscountCodes.ToListAsync();
        }

        // GET: api/DiscountCodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiscountCode>> GetDiscountCode(int id)
        {
            var discountCode = await _db.DiscountCodes.FindAsync(id);

            if (discountCode == null)
            {
                return NotFound();
            }

            return discountCode;
        }

        // PUT: api/DiscountCodes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiscountCode(int id, DiscountCode discountCode)
        {
            if (id != discountCode.DiscountCodeId)
            {
                return BadRequest();
            }

            _db.Entry(discountCode).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiscountCodeExists(id))
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

        // POST: api/DiscountCodes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DiscountCode>> PostDiscountCode(DiscountCode discountCode)
        {
            _db.DiscountCodes.Add(discountCode);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetDiscountCode", new { id = discountCode.DiscountCodeId }, discountCode);
        }

        // DELETE: api/DiscountCodes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DiscountCode>> DeleteDiscountCode(int id)
        {
            var discountCode = await _db.DiscountCodes.FindAsync(id);
            if (discountCode == null)
            {
                return NotFound();
            }

            _db.DiscountCodes.Remove(discountCode);
            await _db.SaveChangesAsync();

            return discountCode;
        }

        private bool DiscountCodeExists(int id)
        {
            return _db.DiscountCodes.Any(e => e.DiscountCodeId == id);
        }
    }
}
