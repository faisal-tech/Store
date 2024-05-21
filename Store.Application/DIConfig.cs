using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Application.Contract.Product;
using Store.Application.Contract.Product.Dtos;
using Store.Application.Contracts.Unit;
using Store.Application.Product;
using Store.Application.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application
{
	public static class DIConfig
	{

		public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped<IUnitAppService, UnitAppService>();
			services.AddScoped<IProductAppService, ProductAppService>();


			services.AddControllers()
	.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>());


services.AddControllers()
	.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UpdateProductValidator>());
			
			services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();
			services.AddValidatorsFromAssemblyContaining<UpdateProductValidator>();


			services.AddScoped<IValidator<CreateProductDto>, CreateProductValidator>();
			services.AddScoped<IValidator<UpdateProductDto>, UpdateProductValidator>();
			return services;
		}
	}
}
