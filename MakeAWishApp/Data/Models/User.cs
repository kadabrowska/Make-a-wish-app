using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakeAWishApp.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public ICollection<UserGift> UserGifts { get; set; }
    }
}
