using InventoryManagement.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Repository.Sql
{
    public class InventoryManagementContext : DbContext
    {
        public InventoryManagementContext() { }


        /// <summary>
        /// Creates a new <see cref="DbContext"/> of <see cref="InventoryManagementContext"/> with custom settings.
        /// </summary>
        /// <param name="options"><see cref="DbContext"/> options.</param>
        public InventoryManagementContext(DbContextOptions<InventoryManagementContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .HasMany(x => x.SellingOrders)
                .WithMany(x => x.SoldProducts)
                .UsingEntity<ProductSellingOrder>(
                g => g
                .HasOne(s => s.SellingOrder)
                .WithMany(g => g.ProductSellingOrders)
                .HasForeignKey(s => s.SellingOrderId)
                .OnDelete(DeleteBehavior.Cascade),
                g => g
                .HasOne(s => s.Product)
                .WithMany(p => p.ProductSellingOrders)
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.Cascade),
                g =>
                {
                    g.HasKey(s => new { s.SellingOrderId, s.ProductId });
                });
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<SellingOrder> SellingOrders { get; set; }
    }
}