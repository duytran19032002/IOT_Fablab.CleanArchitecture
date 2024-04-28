using AutoMapper;
using IOT.Application.Contract.Persistence.Generic;
using IOT.Application.Exceptions;
using IOT.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Application.Features.Machine.Commands.UpdateMaintenance;
public class UpdateMaintenanceHandler : IRequestHandler<UpdateMaintenance, string>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;
	public UpdateMaintenanceHandler(IMapper mapper, IUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
	}
	public async Task<string> Handle(UpdateMaintenance request, CancellationToken cancellationToken)
	{
		//validate
		var validator = new CreateMachineValidation();
		var validatorResult = await validator.ValidateAsync(request);
		if (validatorResult.Errors.Any())
		{
			throw new BadRequestException("Invalid Location", validatorResult);
		}

		var machineToUpdate=await _unitOfWork.machineRepository.GetByIdAsync(request.MachineId);
		machineToUpdate.MotorOperationTime = request.MotorOperationTime;
		machineToUpdate.MotorMaintenanceTime = request.MotorMaintenanceTime;
		_unitOfWork.machineRepository.Update(machineToUpdate);

		await _unitOfWork.CompleteAsync();
		//return 
		return machineToUpdate.MachineId;

	}
}
