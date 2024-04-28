using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Application.Features.Machine.Queries.GetAllMachine
{
	public class MachineDTO
	{
		public string MachineId { get; set; }
		public string MachineName { get; set; }
		public string Description { get; set; }
		public double MotorOperationTime { get; set; }
		public double MotorMaintenanceTime { get; set; }
		public string? MachinePicture { get; set; }
	}
}
