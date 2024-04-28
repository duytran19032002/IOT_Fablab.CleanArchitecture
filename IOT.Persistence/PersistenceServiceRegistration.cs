using IOT.Application.Contract.Persistence;
using IOT.Application.Contract.Persistence.Generic;
using IOT.Persistence.DatabaseContext;
using IOT.Persistence.Repository;
using IOT.Persistence.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IOT.Persistence
{
    public static class PersistenceServiceRegistration
	{
		public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddDbContext<IOTDbContext>(options => {
				options.UseSqlServer(configuration.GetConnectionString("IOT"));
			});

			//services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			services.AddScoped<IDetailRepository, DetailRepository>();
			services.AddScoped<IDetailPictureRepository, DetailPictureRepository>();
			services.AddScoped<IMachineRepository, MachineRepository>();
			services.AddScoped<IOEERepository, OEERepository>();
			services.AddScoped<IProjectRepository, ProjectRepository>();
			services.AddScoped<IWorkerRepository, WorkerRepository>();
			services.AddScoped<IWorkerPictureRepository, WorkerPictureRepository>();
			services.AddScoped<IDetailLogRepository, DetailLogRepository>();
			services.AddScoped<IMachineErrorRepository, MachineErrorRepository>();
			services.AddScoped<IMachinePictureRepository, MachinePictureRepository>();
			services.AddScoped<IAreaRepository, AreaRepository>();

			return services;
		}
	}
}
