using IOT.Application.Contract.Persistence;
using IOT.Domain;
using IOT.Persistence.DatabaseContext;

namespace IOT.Persistence.Repository
{
	public class ProjectRepository : Repository<Project, string>, IProjectRepository
	{
		private readonly IOTDbContext iOTDbContext;
		public ProjectRepository(IOTDbContext context) : base(context)
		{
			iOTDbContext = context;
		}

	}

}
