using IOT.Application.Contract.Persistence;
using IOT.Domain;
using IOT.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace IOT.Persistence.Repository
{
	public class DetailRepository : Repository<Detail, string>, IDetailRepository
	{
		private readonly IOTDbContext iOTDbContext;
		public DetailRepository(IOTDbContext context) : base(context)
		{
			iOTDbContext = context;
		}


	}

}
