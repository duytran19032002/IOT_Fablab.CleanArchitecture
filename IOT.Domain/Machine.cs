namespace IOT.Domain;

public class Machine
{
	public string MachineId { get; set; }
	public string MachineName { get; set; }
	public string Description { get; set; }
	public double MotorOperationTime { get; set; }
	public double MotorMaintenanceTime { get; set; }

	public Area Area { get; set; }
	public List<MachinePicture>? MachinePictures { get; set; }
	public List<DetailLog>? Logs { get; set; }
	public List <OEE>? OEEs { get; set; }
	public List<MachineError>? MachineErrors { get; set; }

}
