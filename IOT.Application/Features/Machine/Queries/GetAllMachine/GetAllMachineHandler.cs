using AutoMapper;
using IOT.Application.Contract.Persistence.Generic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Application.Features.Machine.Queries.GetAllMachine
{
    public class GetAllMachineHandler : IRequestHandler<GetAllMachine, List<MachineDTO>>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;
		public GetAllMachineHandler(IMapper mapper, IUnitOfWork unitOfWork)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<List<MachineDTO>> Handle(GetAllMachine request, CancellationToken cancellationToken)
		{
			var machines =  _unitOfWork.machineRepository.FindAll(false,x=>x.Area,x=>x.MachinePictures).ToList();

			if(request.AreaId != null)
			{
				machines = machines.Where(x => x.Area.AreaId == request.AreaId).ToList();
			}
			// convert

			var data = new List<MachineDTO>();
			foreach (var machine in machines)
			{
				var machineDTO = new MachineDTO()
				{
					MachineId = machine.MachineId,
					MachineName = machine.MachineName,
					MotorMaintenanceTime = machine.MotorMaintenanceTime,
					MotorOperationTime = machine.MotorOperationTime,
					Description = machine.Description,
					MachinePicture = machine.MachinePictures.FirstOrDefault()?.FileData != null ? Convert.ToBase64String(machine.MachinePictures.FirstOrDefault()?.FileData) : "",

			};
				data.Add(machineDTO);
			}
			//var data = _mapper.Map<List<MachineDTO>>(machines);
			//return
			return data;
		}
	}
}
