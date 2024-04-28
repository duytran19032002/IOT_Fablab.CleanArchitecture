namespace IOT.Application.Features.Machine.Queries.GetAllMachineDetailLog;

public class GetAllMachineDatailLogDTO
{
	public DateTime StartTagging { get; set; }
	public DateTime? EndTagging { get; set; }

	//
	public string DetailId { get; set; } = string.Empty;
	public string MachineId { get; set; } = string.Empty;
	public string WorkerId { get; set; } = string.Empty;

}
