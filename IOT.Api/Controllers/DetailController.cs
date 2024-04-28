using IOT.Application.Features.Detail.Commands.CompleteDetail;
using IOT.Application.Features.Detail.Commands.DeleteDetail;
using IOT.Application.Features.Detail.Queries.GetAllDetail;
using IOT.Application.Features.Detail.Queries.GetDetailFull;
using IOT.Application.Features.Machine.Commands.UpdateMaintenance;
using IOT.Application.Features.Project.Queries.DetailByPrjId;
using IOT.Application.Features.Project.Queries.GetAllPrj;
using IOT.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IOT.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DetailController : Controller
	{
		private readonly IMediator _mediator;
		public DetailController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetDetails([FromQuery]  string projectId,  DetailStatus? status, int pageSize = 100, int pageNumber = 1)
		{
			var details = await _mediator.Send(new GetDetailByPrjId { ProjectId = projectId });
			if (status != null)
			{
				details = details.Where(x => x.DetailStatus == status).ToList();
			}
			details = details.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
			return Ok(details);
		}
		[HttpPut("Complete")]
		public async Task<IActionResult> PutMachine([FromBody] CompleteDetail detail)
		{
			var id = await _mediator.Send(detail);
			return Ok(id);

		}
		[HttpGet("full")]
		public async Task<IActionResult> GetDetailFull([FromQuery] string detailId)
		{
			var details = await _mediator.Send(new GetDetailFull { DetailId = detailId });
			return Ok(details);
		}



		[HttpDelete]
		public async Task<IActionResult> DeleteDetail([FromQuery] string detailId)
		{
			var command = new DeleteDetail { DetailId = detailId };

			var IdReturn = await _mediator.Send(command);
			return Ok(IdReturn);

		}

	}
}
