using System.ComponentModel.DataAnnotations;

namespace MakeAWishApp.DTOs
{
    public class UserRegisterDto
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Username { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public required string Password { get; set; }
    }
}
