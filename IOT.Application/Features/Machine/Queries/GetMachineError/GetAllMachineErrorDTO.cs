namespace IOT.Application.Features.Machine.Queries.GetMachineError;

public class GetAllMachineErrorDTO
{
	public string ErrorName { get; set; }
	public string? ErrorDescription { get; set; }
	public DateTime ErrorTime { get; set; }

	public string MachineId { get; set; }
}
