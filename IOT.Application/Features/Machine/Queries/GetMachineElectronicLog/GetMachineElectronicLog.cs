using MediatR;

namespace IOT.Application.Features.Machine.Queries.GetMachineElectronicLog;

public class GetMachineElectronicLog : IRequest<List<GetMachineElectronicLogDTO>>
{
	public string MachineId { get; set; }

	public DateTime Start { get; set; }
	public DateTime End { get; set; }
}
