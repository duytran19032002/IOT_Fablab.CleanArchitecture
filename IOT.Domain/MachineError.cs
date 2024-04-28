namespace IOT.Domain;

public class MachineError
{
	public int MachineErrorId { get; set; }
	public string ErrorName { get; set; }
	public string? ErrorDescription { get; set; }
	public DateTime ErrorTime { get; set; }

	public string MachineId { get; set; }
	public Machine? Machine { get; set; }
}