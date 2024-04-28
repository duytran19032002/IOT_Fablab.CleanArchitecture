using MediatR;

namespace IOT.Application.Features.Machine.Queries.GetMachineError;

public class GetAllMachineError : IRequest<List<GetAllMachineErrorDTO>>
{
	public string MachineId { get; set; }

	public DateTime Start { get; set; }
	public DateTime End { get; set; }
}
