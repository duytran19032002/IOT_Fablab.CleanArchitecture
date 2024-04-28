using AutoMapper;
using IOT.Application.Contract.Persistence.Generic;
using IOT.Application.Features.Machine.Queries.GetAllMachineDetailLog;
using IOT.Application.Features.Machine.Queries.GetMachineOEE;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Application.Features.Machine.Queries.GetMachineError;
public class GetMachineOeeHandler : IRequestHandler<GetAllMachineError, List<GetAllMachineErrorDTO>>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;
	public GetMachineOeeHandler(IMapper mapper, IUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
	}

	public async Task<List<GetAllMachineErrorDTO>> Handle(GetAllMachineError request, CancellationToken cancellationToken)
	{
		var machineOee = _unitOfWork.machineErrorRepository.Find(x => x.MachineId == request.MachineId && x.ErrorTime >= request.Start && x.ErrorTime <= request.End).ToList();



		// convert
		var data = _mapper.Map<List<GetAllMachineErrorDTO>>(machineOee);
		//return
		return data;
	}
}
