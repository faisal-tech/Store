using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Lookups;
using Store.Infrastructure.Configurations;
using System.Reflection;

namespace Store.Infrastructure
{
    public class ApplicationDbContext: DbContext
    {
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Supplier> Suppliers{ get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Unit> Units { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration(new ProductConfiguration());
			modelBuilder.ApplyConfiguration(new SupplierConfiguration());
			modelBuilder.ApplyConfiguration(new UnitConfiguration());
		}
	}
}
