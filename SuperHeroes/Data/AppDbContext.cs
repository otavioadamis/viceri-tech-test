using Microsoft.EntityFrameworkCore;

namespace SuperHeroes.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Heroi> Herois { get; set; }
        public DbSet<SuperPoder> Superpoderes { get; set; }
        public DbSet<HeroiSuperpoder> HeroiSuperpoderes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Heroi>()
                .HasMany(h => h.Superpoderes)
                .WithMany()
                .UsingEntity<HeroiSuperpoder>();
        }
    }
}
