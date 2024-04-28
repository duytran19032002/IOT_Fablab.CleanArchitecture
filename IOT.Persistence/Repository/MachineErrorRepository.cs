using IOT.Application.Contract.Persistence;
using IOT.Domain;
using IOT.Persistence.DatabaseContext;

namespace IOT.Persistence.Repository;

public class  MachineErrorRepository: Repository<MachineError,string>,IMachineErrorRepository
{
    public MachineErrorRepository (IOTDbContext context):base (context)
	{

	}
}
