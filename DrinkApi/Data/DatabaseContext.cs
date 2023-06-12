using DrinkApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrinkApi.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }

        #region Database
        public DbSet<Alcohol> Alcohols { get; set; }
        public DbSet<NonAlcohol> NonAlcohols { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Login> Logins { get; set; }
        #endregion
    }
}