using AutoMapper;
using IOT.Application.Contract.Persistence.Generic;
using MediatR;

namespace IOT.Application.Features.Machine.Queries.GetAllMachineDetailLog;

public class GetAllMachineDetailLogHandler : IRequestHandler<GetAllMachineDatailLog, List<GetAllMachineDatailLogDTO>>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;
	public GetAllMachineDetailLogHandler(IMapper mapper, IUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
	}

	public async Task<List<GetAllMachineDatailLogDTO>> Handle(GetAllMachineDatailLog request, CancellationToken cancellationToken)
	{
		var machineDetailLog = _unitOfWork.detailLogRepository.Find(x => x.MachineId == request.MachineId).ToList();
		machineDetailLog= machineDetailLog.Where(x=>x.StartTagging <= request.End && x.StartTagging >=  request.Start).OrderByDescending(x => x.EndTagging).ToList();


				// convert
				var data = _mapper.Map<List<GetAllMachineDatailLogDTO>>(machineDetailLog);
		//return
		return data;
	}
}