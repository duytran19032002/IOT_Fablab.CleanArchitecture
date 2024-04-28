using AutoMapper;
using IOT.Application.Contract.Persistence.Generic;
using IOT.Application.Exceptions;
using IOT.Application.Features.Worker.Commands.UpdateWorker;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Application.Features.Detail.Commands.CompleteDetail;
public class CompleteDetailHandler : IRequestHandler<CompleteDetail, string>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;
	public CompleteDetailHandler(IMapper mapper, IUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
	}
	public async Task<string> Handle(CompleteDetail request, CancellationToken cancellationToken)
	{
		//validate
		var validator = new CompleteDetailValidation();
		var validatorResult = await validator.ValidateAsync(request);
		if (validatorResult.Errors.Any())
		{
			throw new BadRequestException("Invalid Worker", validatorResult);
		}

		var detailToUpdate = await _unitOfWork.detailRepository.GetByIdAsync(request.DetailId);
		detailToUpdate.DetailStatus = Domain.DetailStatus.completed;
		_unitOfWork.detailRepository.Update(detailToUpdate);
		await _unitOfWork.CompleteAsync();
		//return 
		return request.DetailId;

	}
}