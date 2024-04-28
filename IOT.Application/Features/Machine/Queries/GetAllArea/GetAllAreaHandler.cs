using AutoMapper;
using IOT.Application.Contract.Persistence.Generic;
using MediatR;

namespace IOT.Application.Features.Machine.Queries.GetAllArea;

public class GetAllAreaHandler : IRequestHandler<GetAllArea, List<AreaDTO>>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;
	public GetAllAreaHandler(IMapper mapper, IUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
	}

	public async Task<List<AreaDTO>> Handle(GetAllArea request, CancellationToken cancellationToken)
	{
		var areas = await _unitOfWork.areaRepository.GetAllAsync();
		//await _unitOfWork.CompleteAsync();
		//logging
		//_logger.LogInformation("get location successfully");


		// convert
		var data = _mapper.Map<List<AreaDTO>>(areas);
		//return
		return data;
	}
}
