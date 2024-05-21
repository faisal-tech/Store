 using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System;

namespace Store.Infrastructure
{
	public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		public ApplicationDbContext CreateDbContext(string[] args)
		{
			

			var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
			var connectionString = "Server=.;Database=StoreMOJ;Trusted_Connection=true;encrypt=false;MultipleActiveResultSets=true;TrustServerCertificate=True";
			builder.UseSqlServer(connectionString);

			return new ApplicationDbContext(builder.Options);
		}
	}
}
