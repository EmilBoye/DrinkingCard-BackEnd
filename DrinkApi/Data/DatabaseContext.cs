using DrinkApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrinkApi.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }


        DbSet<Alcohol> Alcohols { get; set; }
        DbSet<NonAlcohol> NonAlcohols { get; set; }
        DbSet<User> Users { get; set; }
    }
}