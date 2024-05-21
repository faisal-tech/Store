using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Infrastructure.IRepositories;
using Store.Infrastructure.Repositories;

namespace Store.Infrastructure
{
	public static class DIConfig
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection");

			services.AddDbContext<ApplicationDbContext>
				((serviceProvider, options) =>
			{
	
				options.UseSqlServer(connectionString);
			});

			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<ISupplierRepository, SupplierRepository>();
			services.AddScoped<IUnitRepository, UnitRepository>();

			return services;
		}
	}
}
