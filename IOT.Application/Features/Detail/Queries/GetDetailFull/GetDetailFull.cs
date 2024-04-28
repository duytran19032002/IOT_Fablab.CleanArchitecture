using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Application.Features.Detail.Queries.GetDetailFull;

public class GetDetailFull : IRequest<GetDetailFullDTO>
{
	public string DetailId { get; set; } = string.Empty;
}
