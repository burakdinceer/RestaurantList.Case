using Microsoft.EntityFrameworkCore;

namespace RestaurantList.Case.Entities.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<Cafe>().Property(x => x.Rating).HasColumnType("decimal(3,2)");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }


        public DbSet<Category> categories { get; set; }
        public DbSet<Cafe> restaurants { get; set; }
    }
}
