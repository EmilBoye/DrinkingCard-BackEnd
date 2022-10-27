namespace DrinkApi.Models.DTO
{
    public class AlcoholFreeRequest
    {
        public string? Author { get; set; }
        public string? Title { get; set; }
        public string? Ingredients { get; set; }
        public string? NonAlcoholType { get; set; }
        public bool Visible { get; set; }
        //public User? user { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
