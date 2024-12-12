using MakeAWishApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MakeAWishApp.Data;

namespace MakeAWishApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly AppDbContext _context;

        public UserController(AppDbContext context, UserService userService)
        {
            _userService = userService;
            _context = context;
        }

        [HttpGet("allUsers")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _context.Users
                    .Select(u => new
                {
                    u.Id,
                    u.Username,
                    GiverId = _context.Assignments
                .Where(a => a.ReceiverId == u.Id)
                .Select(a => a.GiverId)
                .FirstOrDefault()
                })
                    .ToList(); 
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
