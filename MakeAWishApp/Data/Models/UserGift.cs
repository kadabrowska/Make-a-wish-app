namespace MakeAWishApp.Data.Models
{
    public class UserGift
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GiftId   { get; set; }

        public User User { get; set; }
        public Gift Gift { get; set; }
    }
}
