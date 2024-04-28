using IOT.Application.Features.Machine.Queries.GetAllMachine;
using IOT.Application.Features.Machine.Queries.GetMachineOEE;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Application.Features.Machine.Queries.GetAllMachineDetailLog;

public class GetAllMachineDatailLog : IRequest<List<GetAllMachineDatailLogDTO>>
{
	public string MachineId { get; set; }

	public DateTime Start { get; set; }
	public DateTime End { get; set; }
}

