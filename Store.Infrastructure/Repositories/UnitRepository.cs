using Microsoft.EntityFrameworkCore;
using Store.Domain.Lookups;
using Store.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Repositories
{
	public class UnitRepository : IUnitRepository
	{
		private readonly ApplicationDbContext _context;

		public UnitRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		
		public async Task<IEnumerable<Unit>> GetAllUnitsAsync()
		{
			return await _context.Units.ToListAsync();
		}


	}
}
