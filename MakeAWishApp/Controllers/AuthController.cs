using MakeAWishApp.Data;
using MakeAWishApp.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using MakeAWishApp.DTOs;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Options;

namespace MakeAWishApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly JwtSettings _jwtSettings;

        public AuthController(AppDbContext context, IOptions<JwtSettings> jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegisterDto registerDto)
        {
            if (_context.Users.Any(u => u.Username == registerDto.Username))
            {
                return BadRequest("Username already exists");
            }

            var user = new User
            {
                Name = registerDto.Name,
                Username = registerDto.Username,
                Email = registerDto.Email,
                Password = registerDto.Password,
            };

            user.Password = HashPassword(user.Password);

            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(new { message = "User has been registered" });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto loginRequest)
        {
            if (string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest(new { message = "Username and password are required" });
            }

            var user = _context.Users.FirstOrDefault(u => u.Username == loginRequest.Username);
            
            if (user == null || !VerifyPassword(loginRequest.Password, user.Password))
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            var token = GenerateJwtToken(user);

            return Ok(new {token});
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        private bool VerifyPassword(string inputPassword, string storedPassword)
        {
            var inputHash = HashPassword(inputPassword);
            return inputHash == storedPassword;
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim("userId", user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
