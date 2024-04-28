using AutoMapper;
using IOT.Application.Contract.Persistence.Generic;
using IOT.Application.Exceptions;
using MediatR;

namespace IOT.Application.Features.Machine.Commands.CreateMachineError;

public class CreateMachineErrorHandler : IRequestHandler<CreateMachineError, string>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;
	public CreateMachineErrorHandler(IMapper mapper, IUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
	}
	public async Task<string> Handle(CreateMachineError request, CancellationToken cancellationToken)
	{
		//validate
		var validator = new CreateMachineErrorValidation();
		var validatorResult = await validator.ValidateAsync(request);
		if (validatorResult.Errors.Any())
		{
			throw new BadRequestException("Invalid Location", validatorResult);
		}

		var errorToCreate = _mapper.Map<Domain.MachineError>(request);

		_unitOfWork.machineErrorRepository.Add(errorToCreate);


		await _unitOfWork.CompleteAsync();
		//return 
		return errorToCreate.MachineId;

	}
}