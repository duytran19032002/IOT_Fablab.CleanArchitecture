
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Application.Features.Machine.Queries.GetAllMachine
{
	public class GetAllMachine : IRequest<List<MachineDTO>>
	{
		public string? AreaId { get; set; } = string.Empty;
	}
}
