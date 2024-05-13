﻿using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.IRepositories
{
	public interface IProductRepository
	{
		Task<Product> GetProductByIdAsync(int id);
		Task<IEnumerable<Product>> GetAllProductsAsync();
		Task AddProductAsync(Product product);
		Task UpdateProductAsync(Product product);
		Task DeleteProductAsync(int id);
	}
}
