using IOT.Application.Features.Worker.Commands.CreateWorker;
using IOT.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Application.Features.Machine.Commands.CreateMachineError;

public class CreateMachineError : IRequest<string>
{
	public string ErrorName { get; set; }
	public string? ErrorDescription { get; set; }
	public DateTime ErrorTime { get; set; }
	public string MachineId { get; set; }

}
