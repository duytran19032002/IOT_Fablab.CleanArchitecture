using FluentValidation;

namespace IOT.Application.Features.Detail.Commands.CompleteDetail;

public class CompleteDetailValidation : AbstractValidator<CompleteDetail>
{
	public CompleteDetailValidation()
	{
		RuleFor(p => p.DetailId)
			.NotEmpty().WithMessage("{property} is required")
			.NotNull()
			.MaximumLength(100);

	}

}
