using MediatR;

namespace IOT.Application.Features.Machine.Commands.UpdateMaintenance;

public class UpdateMaintenance : IRequest<string>
{
	public string MachineId { get; set; }
	public double MotorOperationTime { get; set; } 
	public double MotorMaintenanceTime { get; set; } 

}
