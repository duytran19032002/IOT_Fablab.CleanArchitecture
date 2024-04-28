using AutoMapper;
using IOT.Application.Contract.Persistence.Generic;
using IOT.Application.Exceptions;
using MediatR;

namespace IOT.Application.Features.Worker.Commands.UpdateWorker;

public class UpdateWorkerHandler : IRequestHandler<UpdateWorker, string>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;
	public UpdateWorkerHandler(IMapper mapper, IUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
	}
	public async Task<string> Handle(UpdateWorker request, CancellationToken cancellationToken)
	{
		//validate
		var validator = new UpdateWorkerValidation();
		var validatorResult = await validator.ValidateAsync(request);
		if (validatorResult.Errors.Any())
		{
			throw new BadRequestException("Invalid Worker", validatorResult);
		}

		var workerToUpdate = await _unitOfWork.workerRepository.GetByIdAsync(request.WorkerId);
		workerToUpdate.WorkerName = request.WorkerName;
		workerToUpdate.NoteArea = request.NoteArea;
		workerToUpdate.RFID = request.RFID;
		_unitOfWork.workerRepository.Update(workerToUpdate);
		await _unitOfWork.CompleteAsync();
		//return 
		return request.WorkerId;

	}
}