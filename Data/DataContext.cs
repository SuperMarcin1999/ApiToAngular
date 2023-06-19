using ApiToAngular.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiToAngular.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<SuperHero> SuperHeroes => Set<SuperHero>();
    }
}
