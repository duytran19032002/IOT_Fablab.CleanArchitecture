using AutoMapper;
using IOT.Application.Contract.Persistence.Generic;
using IOT.Application.Features.Project.Queries.DetailByPrjId;
using IOT.Domain;
using MediatR;

namespace IOT.Application.Features.Detail.Queries.GetDetailFull;

public class GetDetailFullHandler : IRequestHandler<GetDetailFull, GetDetailFullDTO>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;
	public GetDetailFullHandler(IMapper mapper, IUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
	}

	public async Task<GetDetailFullDTO> Handle(GetDetailFull request, CancellationToken cancellationToken)
	{
		//query
		var detail = _unitOfWork.detailRepository.FindByCondition(x => x.DetailId == request.DetailId, false, x => x.DetailPictures, x=>x.Project).First();
		var logs= _unitOfWork.detailLogRepository.FindByCondition(x => x.DetailId == request.DetailId, false).ToList();
		var logsDTO= _mapper.Map<List<LogForDetailFull>>(logs);
		//logging
		//_logger.LogInformation("get location successfully");
		var detailDTO = new GetDetailFullDTO
		{
			DetailId= detail.DetailId,
			DetailName= detail.DetailName,
			StartTimePre = detail.StartTimePre,
			EndTimePre= detail.EndTimePre,
			NoteLog = detail.NoteLog,
			ProjectId = detail.ProjectId,
			ProjectName = detail.Project.ProjectName,
			DetailStatus = detail.DetailStatus,
			DetailPicture= detail.DetailPictures.FirstOrDefault()?.FileData != null ? Convert.ToBase64String(detail.DetailPictures.FirstOrDefault()?.FileData) : "",
			LogForDetailFull= logsDTO
		};
		//machine.MachinePictures.FirstOrDefault()?.FileData != null ? Convert.ToBase64String(machine.MachinePictures.FirstOrDefault()?.FileData) : "";
		//return
		return detailDTO;
	}
}