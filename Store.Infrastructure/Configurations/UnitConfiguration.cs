using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Configurations
{
	public class UnitConfiguration : IEntityTypeConfiguration<Unit>
	{
		public void Configure(EntityTypeBuilder<Unit> b)
		{
			b.ToTable("Units");

			b.HasKey(u => u.Id);
			b.HasMany(u => u.Products)
				.WithOne(u => u.Unit)
				.HasForeignKey(u => u.UnitId);
			b.Property(u => u.Name).IsRequired().HasMaxLength(100);
		}
	}
}
