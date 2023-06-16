namespace DrinkApi.Models.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public int? DrinkId { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public string? Comment { get; set; }
        public DateTime? PublishedComment { get; set; }
    }
}


