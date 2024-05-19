using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Configurations
{
	public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
	{
		public void Configure(EntityTypeBuilder<Supplier> builder)
		{

			builder.HasKey(s => s.Id);

			builder.Property(s => s.Name).IsRequired().HasMaxLength(200);
            builder.HasMany(s=> s.Products)
               .WithOne(p => p.Supplier)
               .HasForeignKey(p=>p.SupplierId);

            builder.HasIndex(p => p.Name)
                 .HasName("Index_Name");
        }
    }
}
