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

		public async Task<Unit> GetUnitByIdAsync(int id)
		{
			return await _context.Units.FindAsync(id);
		}

		public async Task<IEnumerable<Unit>> GetAllUnitsAsync()
		{
			return await _context.Units.ToListAsync();
		}

		public async Task AddUnitAsync(Unit unit)
		{
			_context.Units.Add(unit);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateUnitAsync(Unit unit)
		{
			_context.Units.Update(unit);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteUnitAsync(int id)
		{
			var unit = await _context.Units.FindAsync(id);
			if (unit != null)
			{
				_context.Units.Remove(unit);
				await _context.SaveChangesAsync();
			}
		}
	}
}
