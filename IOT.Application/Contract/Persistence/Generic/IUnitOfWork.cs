using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Application.Contract.Persistence.Generic
{
    public interface IUnitOfWork
    {
        IDetailPictureRepository detailPictureRepository { get; }
        IDetailRepository detailRepository { get; }
        IMachineRepository machineRepository { get; }
        IDetailLogRepository detailLogRepository { get; }
        IOEERepository oeeRepository { get; }
        IProjectRepository projectRepository { get; }
        IWorkerPictureRepository workerPictureRepository { get; }
        IWorkerRepository workerRepository { get; }
        IMachinePictureRepository machinePictureRepository { get; }
        IMachineErrorRepository machineErrorRepository { get; }
        IAreaRepository areaRepository { get; }
        IElectronicLogRepository electronicLogRepository { get; }

        Task<int> CompleteAsync();
        void Complete();

    }
}
