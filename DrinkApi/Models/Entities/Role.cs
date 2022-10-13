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
        public int roleId { get; set; }
        public RoleType roleType { get; set; }
        public int level { get; set; }
    }
}
