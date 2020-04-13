using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApplicationApi.DataAccess.Data;
using PolestarApi.DataBase.Models;
using PolestarApi.Utility;
using Microsoft.AspNetCore.Authorization;

namespace PolestarApi.Areas.Account.Controllers
{
    [Area("Account")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IUserService _userService;
        public UserAccountsController(ApplicationDbContext db, IUserService userService)
        {
            _db = db;
            _userService = userService;
        }

        // GET: api/UserAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAccounts>>> GetUserAccount()
        {
            var Users = await _db.UserAccount.Join(_db.Role,u=>u.RoleId,r=>r.RoleId,(u,r)=>
            new {
                u,
                r
            }).Select(User => new {User.u.UserName,
            User.u.Email,
            User.r.Name,
            User.u.UserId,
            User.u.IsActive,
            User.u.IsDeleted
            }).ToListAsync();
            JsonResult result = new JsonResult(new { });
            result.Value = new { Data = Users };
            return result;
        }

        // GET: api/UserAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAccounts>> GetUserAccounts(int id)
        {
            var userAccounts = await _db.UserAccount.FindAsync(id);

            if (userAccounts == null)
            {
                return NotFound();
            }

            return userAccounts;
        }

        // PUT: api/UserAccounts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAccounts(int id, UserAccounts userAccounts)
        {
            if (id != userAccounts.UserId)
            {
                return BadRequest();
            }

            _db.Entry(userAccounts).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAccountsExists(id))
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

        // POST: api/UserAccounts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UserAccounts>> PostUserAccounts(UserAccounts userAccounts)
        {
            _db.UserAccount.Add(userAccounts);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetUserAccounts", new { id = userAccounts.UserId }, userAccounts);
        }

        // DELETE: api/UserAccounts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserAccounts>> DeleteUserAccounts(int id)
        {
            var userAccounts = await _db.UserAccount.FindAsync(id);
            if (userAccounts == null)
            {
                return NotFound();
            }
            userAccounts.IsDeleted = true;
            await _db.SaveChangesAsync();

            return userAccounts;
        }

        private bool UserAccountsExists(int id)
        {
            return _db.UserAccount.Any(e => e.UserId == id);
        }
        [AllowAnonymous]
        [HttpGet("Authenticate")]
        public IActionResult AuthenticateUser(string UserName , string Password)
        {
            var userToken =_userService.Authenticate(UserName, Password);
            JsonResult result = new JsonResult(new { });
          
            if (userToken != null)
            {
                var token = userToken.Token;
                result.Value = new { Data = true, myToken = token };
                return result;
            }
            result.Value = new { Data = false };
            return result;
        }
    }
}
