namespace DrinkApi.Models.Entities
{
    public enum RoleType
    {
        Guest = 10,
        User = 20,
        Admin = 30
    }
    public class Role
    {
        public int RoleId { get; set; }
        public RoleType? RoleType { get; set; }
        public int Level { get; set; }
    }
}
