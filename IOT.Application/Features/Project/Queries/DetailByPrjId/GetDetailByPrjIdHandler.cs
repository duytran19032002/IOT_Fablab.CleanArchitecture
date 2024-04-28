using AutoMapper;
using IOT.Application.Contract.Persistence.Generic;
using MediatR;

namespace IOT.Application.Features.Project.Queries.DetailByPrjId;

public class GetDetailByPrjIdHandler : IRequestHandler<GetDetailByPrjId, List<GetDetailByPrjIdDTO>>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;
	public GetDetailByPrjIdHandler(IMapper mapper, IUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
	}

	public async Task<List<GetDetailByPrjIdDTO>> Handle(GetDetailByPrjId request, CancellationToken cancellationToken)
	{
		//query
		var details =  _unitOfWork.detailRepository.FindByCondition(x=>x.ProjectId==request.ProjectId,false,x=>x.DetailPictures).ToList();
		//await _unitOfWork.CompleteAsync();
		//logging
		//_logger.LogInformation("get location successfully");
		var detail = new List<GetDetailByPrjIdDTO>();
		foreach (var item in details)
		{
			var detailDTO = new GetDetailByPrjIdDTO();
			detailDTO.DetailId = item.DetailId;
			detailDTO.DetailName = item.DetailName;
			detailDTO.StartTimePre = item.StartTimePre;
			detailDTO.EndTimePre = item.EndTimePre;
			detailDTO.NoteLog = item.NoteLog;
			detailDTO.DetailStatus = item.DetailStatus;
			detailDTO.DetailPicture = item.DetailPictures.FirstOrDefault()?.FileData != null ? Convert.ToBase64String(item.DetailPictures.FirstOrDefault()?.FileData) : "";
			detail.Add(detailDTO);
		}
		//machine.MachinePictures.FirstOrDefault()?.FileData != null ? Convert.ToBase64String(machine.MachinePictures.FirstOrDefault()?.FileData) : "";
		//return
		return detail;
	}
}