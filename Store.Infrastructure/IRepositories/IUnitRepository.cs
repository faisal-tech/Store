using Store.Domain.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.IRepositories
{
	public interface IUnitRepository
	{
		Task<Unit> GetUnitByIdAsync(int id);
		Task<IEnumerable<Unit>> GetAllUnitsAsync();
		Task AddUnitAsync(Unit unit);
		Task UpdateUnitAsync(Unit unit);
		Task DeleteUnitAsync(int id);
	}
}
