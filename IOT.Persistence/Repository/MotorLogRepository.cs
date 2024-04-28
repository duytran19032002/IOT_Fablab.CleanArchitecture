using IOT.Application.Contract.Persistence;
using IOT.Domain;
using IOT.Persistence.DatabaseContext;

namespace IOT.Persistence.Repository
{
	public class MotorLogRepository : Repository<ElectronicLog, int>, IElectronicLogRepository
	{
		public MotorLogRepository(IOTDbContext context) : base(context)
		{

		}
	}

}
