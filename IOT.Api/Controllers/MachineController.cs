using IOT.Application.Features.Machine.Commands.CreateMachine;
using IOT.Application.Features.Machine.Commands.CreateMachineError;
using IOT.Application.Features.Machine.Commands.DeleteMachine;
using IOT.Application.Features.Machine.Commands.UpdateMaintenance;
using IOT.Application.Features.Machine.Queries.GetAllArea;
using IOT.Application.Features.Machine.Queries.GetAllMachine;
using IOT.Application.Features.Machine.Queries.GetAllMachineDetailLog;
using IOT.Application.Features.Machine.Queries.GetMachineElectronicLog;
using IOT.Application.Features.Machine.Queries.GetMachineError;
using IOT.Application.Features.Machine.Queries.GetMachineOEE;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IOT.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MachineController : Controller
	{
		private readonly IMediator _mediator;

		public MachineController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllMachines([FromQuery] string? areaId)
		{
			var machines = await _mediator.Send(new GetAllMachine { AreaId = areaId });
			return Ok(machines);
		}

		[HttpGet("Error")]
		public async Task<IActionResult> GetAllMachinesError([FromQuery] string machineId, DateTime start, DateTime end)
		{
			var machines = await _mediator.Send(new GetAllMachineError { MachineId = machineId,Start=start,End=end });
			return Ok(machines);
		}
		[HttpGet("DetailLog")]
		public async Task<IActionResult> GetAllMachinesLog([FromQuery] string machineId, DateTime start, DateTime end)
		{
			var machines = await _mediator.Send(new GetAllMachineDatailLog { MachineId = machineId, Start = start, End = end });
			return Ok(machines);
		}
		[HttpGet("ELog")]
		public async Task<IActionResult> GetMachineELog([FromQuery] string machineId, DateTime start, DateTime end)
		{
			var machines = await _mediator.Send(new GetMachineElectronicLog { MachineId = machineId, Start = start, End = end });
			return Ok(machines);
		}
		[HttpPost("Error")]
		public async Task<IActionResult> PostMachine([FromBody] CreateMachineError machine)
		{
			var id = await _mediator.Send(machine);
			return Ok(id);

		}
		[HttpPut("Maintenance")]
		public async Task<IActionResult> PutMachine([FromBody] UpdateMaintenance machine)
		{
			var id = await _mediator.Send(machine);
			return Ok(id);

		}
		[HttpGet("Area")]
		public async Task<IActionResult> GetArea()
		{
			var areas = await _mediator.Send(new GetAllArea());
			return Ok(areas);
		}

		[HttpGet("OEE")]
		public async Task<IActionResult> GetMachineOEEs([FromQuery] string machineId, DateTime startDate, DateTime endDate)
		{
			var machines = await _mediator.Send(new GetMachineOee { MachineId = machineId, Start = startDate, End = endDate });

			return Ok(machines);
		}

		[HttpPost]
		public async Task<IActionResult> PostMachine([FromBody] CreateMachine machine)
		{
			var id = await _mediator.Send(machine);
			return Ok(id);

		}
		[HttpDelete]
		public async Task<IActionResult> DeleteOder([FromQuery] string machineId)
		{
			var command = new DeleteMachine { MachineId = machineId };

			var IdReturn = await _mediator.Send(command);
			return Ok(IdReturn);

		}
	}
}
