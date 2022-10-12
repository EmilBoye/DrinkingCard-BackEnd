using DrinkApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrinkApi.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }


        public DbSet<Alcohol> Alcohols { get; set; }
        public DbSet<NonAlcohol> NonAlcohols { get; set; }
        public DbSet<User> Users { get; set; }
    }
}