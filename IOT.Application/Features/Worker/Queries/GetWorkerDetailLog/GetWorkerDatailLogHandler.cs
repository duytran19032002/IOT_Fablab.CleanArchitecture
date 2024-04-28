using AutoMapper;
using IOT.Application.Contract.Persistence.Generic;
using MediatR;

namespace IOT.Application.Features.Worker.Queries.GetWorkerDetailLog;

public class GetWorkerDatailLogHandler : IRequestHandler<GetWorkerDatailLog, List<GetWorkerDatailLogDTO>>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;
	public GetWorkerDatailLogHandler(IMapper mapper, IUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
	}

	public async Task<List<GetWorkerDatailLogDTO>> Handle(GetWorkerDatailLog request, CancellationToken cancellationToken)
	{
		var machineDetailLog = _unitOfWork.detailLogRepository.Find(x => x.WorkerId == request.WorkerId).ToList();
		machineDetailLog = machineDetailLog.Where(x => x.StartTagging <= request.End && x.StartTagging >= request.Start).OrderByDescending(x => x.EndTagging).ToList();


		// convert
		var data = _mapper.Map<List<GetWorkerDatailLogDTO>>(machineDetailLog);
		//return
		return data;
	}
}
