namespace MakeAWishApp.Data.Models
{
    public class Gift
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public required string PurchaseLink { get; set; }

        public ICollection<UserGift> UserGifts { get; set; }

    }
}
