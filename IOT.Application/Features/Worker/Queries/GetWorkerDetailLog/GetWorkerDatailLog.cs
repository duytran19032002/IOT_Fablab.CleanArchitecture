using IOT.Application.Features.Machine.Queries.GetAllMachineDetailLog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Application.Features.Worker.Queries.GetWorkerDetailLog;

public class GetWorkerDatailLog : IRequest<List<GetWorkerDatailLogDTO>>
{
	public string WorkerId { get; set; }

	public DateTime Start { get; set; }
	public DateTime End { get; set; }
}
