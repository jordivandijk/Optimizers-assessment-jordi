using Microsoft.EntityFrameworkCore;
using OrderApi.Models.Orders;
using OrderApi.Models.Security;

namespace OrderApi.Data
{
    public class OptimizersDbContext : DbContext
    {
        public OptimizersDbContext(DbContextOptions<OptimizersDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderLine> OrderLines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Order>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<OrderLine>()
                .HasKey(ol => ol.Id);
        }
    }
}
