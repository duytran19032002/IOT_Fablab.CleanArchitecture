using FluentValidation;

namespace IOT.Application.Features.Machine.Commands.CreateMachineError;

public class CreateMachineErrorValidation : AbstractValidator<CreateMachineError>
{
	public CreateMachineErrorValidation()
	{
		RuleFor(p => p.MachineId)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull()
			.MaximumLength(100);

		RuleFor(p => p.ErrorName)
		  .NotEmpty().WithMessage("{property} is required")
		  .NotNull()
		  .MaximumLength(100);
	}

}
