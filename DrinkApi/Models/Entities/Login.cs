namespace DrinkApi.Models.Entities
{
    public class Login
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
