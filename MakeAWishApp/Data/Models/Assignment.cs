namespace MakeAWishApp.Data.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public int GiverId { get; set; }
        public int? ReceiverId { get; set; }
    }
}
