using DrinkApi.Models.Entities;

namespace DrinkApi.Models.DTO
{
    public class AlcoholRequest
    {
        public string? Author { get; set; }
        public string? Title { get; set; }
        public string? Strength { get; set; }
        public string? Ingredients { get; set; }
        public AlcoholType alcoholType { get; set; }
        public bool Visible { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
