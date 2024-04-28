using IOT.Application.Contract.Persistence;
using IOT.Application.Contract.Persistence.Generic;
using IOT.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Persistence.Repository.Generic
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IOTDbContext _db;
        public UnitOfWork(IOTDbContext db)
        {
            _db = db;
            areaRepository = new AreaRepository(db);
            machineErrorRepository = new MachineErrorRepository(db);
            machinePictureRepository = new MachinePictureRepository(db);
            detailPictureRepository = new DetailPictureRepository(db);
            detailRepository = new DetailRepository(db);
            machineRepository = new MachineRepository(db);
			detailLogRepository = new DetailLogRepository(db);
            oeeRepository = new OEERepository(db);
            projectRepository = new ProjectRepository(db);
            workerPictureRepository = new WorkerPictureRepository(db);
            workerRepository = new WorkerRepository(db);
			electronicLogRepository = new MotorLogRepository(db);
        }
        public IDetailPictureRepository detailPictureRepository { get; private set; }

        public IMachineErrorRepository machineErrorRepository { get; private set; }
        public IMachinePictureRepository machinePictureRepository { get; private set; }
        public IAreaRepository areaRepository { get; private set; }
        public IDetailRepository detailRepository { get; private set; }

        public IMachineRepository machineRepository { get; private set; }

        public IDetailLogRepository detailLogRepository { get; private set; }

        public IOEERepository oeeRepository { get; private set; }

        public IProjectRepository projectRepository { get; private set; }

        public IWorkerPictureRepository workerPictureRepository { get; private set; }

        public IWorkerRepository workerRepository { get; private set; }
        public IElectronicLogRepository electronicLogRepository { get; private set; }

        public void Complete()
        {
            _db.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
