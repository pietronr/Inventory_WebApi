using Microsoft.EntityFrameworkCore;

namespace InventoryManagement_Repository.Sql
{
    public class DomProjectContext : DbContext
    {
        public DomProjectContext() { }


        /// <summary>
        /// Creates a new <see cref="DbContext"/> of <see cref="DomProjectContext"/> with custom settings.
        /// </summary>
        /// <param name="options"><see cref="DbContext"/> options.</param>
        public DomProjectContext(DbContextOptions<DomProjectContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
        }

    }
}