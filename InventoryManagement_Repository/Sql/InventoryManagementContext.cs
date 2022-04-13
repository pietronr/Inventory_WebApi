using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Repository.Sql
{
    public class InventoryManagementContext : DbContext
    {
        public InventoryManagementContext() { }


        /// <summary>
        /// Creates a new <see cref="DbContext"/> of <see cref="DomProjectContext"/> with custom settings.
        /// </summary>
        /// <param name="options"><see cref="DbContext"/> options.</param>
        public InventoryManagementContext(DbContextOptions<InventoryManagementContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
        }

    }
}