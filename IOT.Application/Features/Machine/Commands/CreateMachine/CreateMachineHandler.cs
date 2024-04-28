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

namespace IOT.Application.Features.Machine.Commands.CreateMachine
{
    public class CreateMachineHandler : IRequestHandler<CreateMachine, string>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;
		public CreateMachineHandler(IMapper mapper, IUnitOfWork unitOfWork)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}
		public async Task<string> Handle(CreateMachine request, CancellationToken cancellationToken)
		{
			//validate
			var validator = new CreateMachineValidation();
			var validatorResult = await validator.ValidateAsync(request);
			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Location", validatorResult);
			}

			var machineToCreate = new Domain.Machine
			{
				MachineId = request.MachineId,
				MachineName = request.MachineName,
				Area = await _unitOfWork.areaRepository.GetByIdAsync(request.AreaId),
				MotorMaintenanceTime = request.MotorMaintenanceTime,
				MotorOperationTime = request.MotorOperationTime,
				Description = request.Description,
			};
			_unitOfWork.machineRepository.Add(machineToCreate);
			if (!string.IsNullOrEmpty(request.FileData))
			{
				var pic = new MachinePicture
				{
					MachinePictureId = Guid.NewGuid(),
					MachineName = request.MachineName,
					FileData = Convert.FromBase64String(request.FileData)
				};
				_unitOfWork.machinePictureRepository.Add(pic);
			}
			//add to db


			await _unitOfWork.CompleteAsync();
			//return 
			return machineToCreate.MachineId;

		}
	}
}
