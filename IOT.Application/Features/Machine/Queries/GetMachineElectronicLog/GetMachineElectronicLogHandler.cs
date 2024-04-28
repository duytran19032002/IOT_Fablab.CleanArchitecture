using AutoMapper;
using IOT.Application.Contract.Persistence.Generic;
using IOT.Application.Features.Machine.Queries.GetAllMachineDetailLog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Application.Features.Machine.Queries.GetMachineElectronicLog;
public class GetMachineElectronicLogHandler : IRequestHandler<GetMachineElectronicLog, List<GetMachineElectronicLogDTO>>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;
	public GetMachineElectronicLogHandler(IMapper mapper, IUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
	}

	public async Task<List<GetMachineElectronicLogDTO>> Handle(GetMachineElectronicLog request, CancellationToken cancellationToken)
	{
		var machineDetailLog = _unitOfWork.electronicLogRepository.Find(x => x.MachineId == request.MachineId).ToList();
		machineDetailLog = machineDetailLog.Where(x => x.EndTagging <= request.End && x.EndTagging >= request.Start).OrderByDescending(x => x.EndTagging).ToList();


		// convert
		var data = _mapper.Map<List<GetMachineElectronicLogDTO>>(machineDetailLog);
		//return
		return data;
	}
}
