using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Users.Api.Data.Entities;
using Users.Api.Models;

namespace Users.Api.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;

        public UserController(
            UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        [Route("User/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }

        [HttpGet]
        [Authorize]
        [Route("User")]
        public async Task<IActionResult> Get()
        {
            var user = await _userManager.Users.ToListAsync();

            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }

        
        
    }
}