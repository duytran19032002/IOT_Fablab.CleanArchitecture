using IOT.Application.Features.Machine.Queries.GetAllMachine;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Application.Features.Machine.Queries.GetAllArea;

public record GetAllArea : IRequest<List<AreaDTO>>;
