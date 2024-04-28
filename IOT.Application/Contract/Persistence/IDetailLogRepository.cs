using IOT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Application.Contract.Persistence
{
	public interface IDetailLogRepository : IRepository<DetailLog , int>
	{
	}
}
