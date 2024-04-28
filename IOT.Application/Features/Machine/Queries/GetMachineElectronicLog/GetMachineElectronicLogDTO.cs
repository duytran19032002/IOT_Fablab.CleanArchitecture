namespace IOT.Application.Features.Machine.Queries.GetMachineElectronicLog;

public class GetMachineElectronicLogDTO
{
	public DateTime StartTagging { get; set; }
	public DateTime? EndTagging { get; set; }
	//
	public string MachineId { get; set; }
}
