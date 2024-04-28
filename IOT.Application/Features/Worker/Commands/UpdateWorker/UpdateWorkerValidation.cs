using FluentValidation;

namespace IOT.Application.Features.Worker.Commands.UpdateWorker;

public class UpdateWorkerValidation : AbstractValidator<UpdateWorker>
{
	public UpdateWorkerValidation()
	{
		RuleFor(p => p.WorkerId)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull()
			.MaximumLength(100);

		RuleFor(p => p.WorkerName)
		  .NotEmpty().WithMessage("{property} is required")
		  .NotNull()
		  .MaximumLength(100);

		RuleFor(p => p.RFID)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull()
			.MaximumLength(500).WithMessage("max length = 200");
	}

}
