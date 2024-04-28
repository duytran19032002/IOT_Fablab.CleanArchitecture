using FluentValidation;

namespace IOT.Application.Features.Machine.Commands.UpdateMaintenance;

public class CreateMachineValidation : AbstractValidator<UpdateMaintenance>
{
	public CreateMachineValidation()
	{
		RuleFor(p => p.MachineId)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull()
			.MaximumLength(100);

		RuleFor(p => p.MotorMaintenanceTime)
		  .NotEmpty().WithMessage("{property} is required")
		  .NotNull();
		RuleFor(p => p.MotorOperationTime)
		.NotEmpty().WithMessage("{property} is required")
		.NotNull();
	}

}
