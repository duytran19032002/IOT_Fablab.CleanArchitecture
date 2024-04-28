using IOT.Application.Contract.Persistence;
using IOT.Domain;
using IOT.Persistence.DatabaseContext;

namespace IOT.Persistence.Repository;

public class AreaRepository : Repository<Area, string>, IAreaRepository
{
	public AreaRepository(IOTDbContext context) : base(context)
	{

	}
}
