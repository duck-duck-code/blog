using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AuthController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpPost("users")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("users")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            var oldUser = await _context.Users
                .Where(u => u.Id == user.Id)
                .FirstOrDefaultAsync();
            
            _context.Update(oldUser).CurrentValues.SetValues(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("users")]
        public async Task<IActionResult> Get([FromQuery] int id, [FromQuery] string name, [FromQuery] string email)
        {
            var user = await _context.Users
                .Where(u => u.Id == id || 
                            u.Name == name || 
                            u.Email == email).FirstOrDefaultAsync();

            if (user is null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet("users/{provider:alpha}/{id:alpha}")]
        public async Task<IActionResult> GetByAccount(string provider, string id)
        {
            var account = await _context.Accounts
                .Include(acc => acc.User)
                .Where(acc => acc.Provider == provider && acc.ProviderAccountId == id)
                .FirstOrDefaultAsync();

            if (account is null)
                return NotFound();

            return Ok(account.User);
        }

        [HttpPost("accounts")]
        public async Task<IActionResult> LinkAccount([FromBody] Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("accounts/{provider:alpha}/{id:alpha}")]
        public async Task<IActionResult> UnlinkAccount(string provider, string id)
        {
            var account = await _context.Accounts
                .Where(acc => acc.Provider == provider && acc.ProviderAccountId == id)
                .FirstOrDefaultAsync();
            
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /*public class UserRequest
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Image { get; set; }
            public DateTime EmailVerified { get; set; }
        }*/

        public class UserFilter
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
        }
    }
}