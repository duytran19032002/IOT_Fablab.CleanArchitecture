using MediatR;

namespace IOT.Application.Features.Detail.Commands.CompleteDetail;

public class CompleteDetail : IRequest<string>
{
	public string DetailId { get; set; } = string.Empty;
}
