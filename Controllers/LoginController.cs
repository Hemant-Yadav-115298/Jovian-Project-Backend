using Microsoft.AspNetCore.Mvc;
using Jovian_Project_Backend.Models;
using Jovian_Project_Backend.Data;

namespace Jovian_Project_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/Login
        [HttpPost]
        public IActionResult Login([FromBody] Login model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // TODO: Replace with real authentication logic
            var user = _context.Login.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
            if (user != null)
            {
                // Return ActorID along with the success message
                return Ok(new { message = "Login successful", actorId = user.ActorID });
            }

            return Unauthorized(new { message = "Invalid email or password" });
        }
    }
}