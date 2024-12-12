using MakeAWishApp.Data;
using MakeAWishApp.Data.Models;
using MakeAWishApp.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MakeAWishApp.Services
{
    public class AssignmentService
    {
        private readonly AppDbContext _context;

        public AssignmentService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAssignmentForGiver(int giverId, int receiverId)
        {
            Console.WriteLine($"received giverId {giverId}, receiverId {receiverId}");
            if (giverId == receiverId)
            {
                throw new InvalidOperationException("You cannot assign yourself, please select another user" );
            }

            if (_context.Assignments.Any(a => a.GiverId == giverId))
            {
                throw new InvalidOperationException("Assignment already exists for you");
            }

            var receiver = _context.Users.FirstOrDefault(u => u.Id == receiverId);
              if (receiver == null) 
                {
                throw new InvalidOperationException("Receiver not found");
                }


            var assignment = new Assignment
            {
                GiverId = giverId,
                ReceiverId = receiverId
            };

            _context.Assignments.Add(assignment);
            _context.SaveChanges();

        }

        public Assignment GetAssignmentForGiver(int giverId)
        {
            var assignment = _context.Assignments.FirstOrDefault(a => a.GiverId == giverId);
            if (assignment == null)
            {
                throw new InvalidOperationException("You don't have any assignments");
            }
            return assignment;
        }

        public void DeleteAssignmentForGiver(int giverId)
        {
            var assignment = _context.Assignments.FirstOrDefault(a => a.GiverId == giverId);

            if (assignment == null)
            {
                throw new InvalidOperationException("No assignment found for the given user");
            }

            _context.Assignments.Remove(assignment);
            _context.SaveChanges();
        }

    }
}
