using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Configurations
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> b)
		{
			b.ToTable("Products");

			b.HasKey(p => p.Id);

			b.Property(p => p.Name).IsRequired().HasMaxLength(200);

			b.Property(p => p.UnitPrice).IsRequired(); 

			b.Property(p => p.ReorderLimit).IsRequired();

			// Relations
			b.HasOne(p => p.Unit)
				.WithMany()
				.HasForeignKey(p => p.UnitId);

			b.HasOne(p => p.Supplier)
				.WithMany()  // If Supplier has a collection of Products, replace with appropriate navigation property
				.HasForeignKey(p => p.SupplierId);
		}
	}
}
