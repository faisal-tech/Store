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
		Task<IEnumerable<Unit>> GetAllUnitsAsync();	
	}
}
