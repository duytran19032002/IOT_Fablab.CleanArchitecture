using IOT.Application.Contract.Persistence;
using IOT.Domain;
using IOT.Persistence.DatabaseContext;

namespace IOT.Persistence.Repository
{
	public class DetailLogRepository : Repository<DetailLog, int>, IDetailLogRepository
	{
		public DetailLogRepository(IOTDbContext context) : base(context)
		{

		}
	}

}
