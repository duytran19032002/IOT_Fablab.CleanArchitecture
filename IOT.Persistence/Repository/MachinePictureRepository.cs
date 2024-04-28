using IOT.Application.Contract.Persistence;
using IOT.Domain;
using IOT.Persistence.DatabaseContext;

namespace IOT.Persistence.Repository;

public class MachinePictureRepository : Repository<MachinePicture, Guid>, IMachinePictureRepository
{
	public MachinePictureRepository(IOTDbContext context) : base(context)
	{

	}
}
