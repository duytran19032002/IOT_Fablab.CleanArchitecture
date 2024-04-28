using AutoMapper;
using IOT.Application.Features.Machine.Commands.CreateMachine;
using IOT.Application.Features.Machine.Commands.CreateMachineError;
using IOT.Application.Features.Machine.Queries.GetAllArea;
using IOT.Application.Features.Machine.Queries.GetAllMachine;
using IOT.Application.Features.Machine.Queries.GetAllMachineDetailLog;
using IOT.Application.Features.Machine.Queries.GetMachineElectronicLog;
using IOT.Application.Features.Machine.Queries.GetMachineError;
using IOT.Application.Features.Machine.Queries.GetMachineOEE;
using IOT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Application.MappingProfile
{
	public class MachineProfile : Profile
	{
		public MachineProfile()
		{
			CreateMap<Machine, MachineDTO>().ReverseMap();
			CreateMap<Area, AreaDTO>().ReverseMap();
			CreateMap<OEE, GetMachineOeeDTO>().ReverseMap();
			CreateMap<CreateMachine, Machine>();
			CreateMap<MachineError, GetAllMachineErrorDTO>().ReverseMap();
			CreateMap<CreateMachineError, MachineError>();
			CreateMap<GetAllMachineDatailLogDTO, DetailLog>().ReverseMap();
			CreateMap<GetMachineElectronicLogDTO, ElectronicLog>().ReverseMap();
		}

	}
}
