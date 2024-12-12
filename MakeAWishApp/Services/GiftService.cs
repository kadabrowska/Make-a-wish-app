using MakeAWishApp.Data;
using MakeAWishApp.Data.Models;

namespace MakeAWishApp.Services
{
    public class GiftService
    {
        private readonly AppDbContext _context;

        public GiftService(AppDbContext context)
        {
            _context = context;
        }

        public void AddGift(string name, decimal price, string purchaseLink)
        {
            var gift = new Gift
            {
                Name = name,
                Price = price,
                PurchaseLink = purchaseLink
            };

            _context.Gifts.Add(gift);
            _context.SaveChanges();
        }

        public void UpdateGift(int giftId, string name, decimal price, string purchaseLink)
        {
            var gift = _context.Gifts.FirstOrDefault(g => g.Id == giftId);
            if (gift == null)
            {
                throw new InvalidOperationException("Gift not found or does not belong to you");
            }

            gift.Name = name;
            gift.Price = price;
            gift.PurchaseLink = purchaseLink;

            _context.Gifts.Update(gift);
            _context.SaveChanges();
        }

        public void DeleteGift(int giftId)
        {
            var gift = _context.Gifts.FirstOrDefault(g => g.Id == giftId);
            if(gift == null)
            {
                throw new InvalidOperationException("Gift not found or does not belong to you");
            }

            _context.Gifts.Remove(gift);
            _context.SaveChanges();
        }

        public List<Gift> GetGiftsForLoggedUser(int userId)
        {
            var userGifts = _context.UserGifts
                .Where(ug => ug.UserId == userId)
                .Select(ug => ug.GiftId)
                .ToList();

            if (!userGifts.Any())
            {
                throw new InvalidOperationException("There are no gifts on the list");
            }
            var gifts = _context.Gifts.Where(g => userGifts.Contains(g.Id)).ToList();
            return gifts;
        }
    }
}
