using IOT.Application.Features.Worker.Commands.CreateWorker;
using IOT.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Application.Features.Worker.Commands.UpdateWorker;

public class UpdateWorker : IRequest<string>
{
	public string WorkerId { get; set; } = string.Empty;
	public string WorkerName { get; set; } = string.Empty;
	public string NoteArea { get; set; } = string.Empty;
	public string RFID { get; set; } = string.Empty;
}
