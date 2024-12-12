using MakeAWishApp.Data;
using MakeAWishApp.Data.Models;

namespace MakeAWishApp.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

    }
}
