using AutoMapper;
using IOT.Application.Contract.Persistence.Generic;
using IOT.Application.Features.Project.Queries.GetAllPrj;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Application.Features.Worker.Queries.GetAllWorker
{
    public class GetAllWorkerHandler : IRequestHandler<GetAllWorker, List<GetAllWorkerDTO>>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;
		public GetAllWorkerHandler(IMapper mapper, IUnitOfWork unitOfWork)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<List<GetAllWorkerDTO>> Handle(GetAllWorker request, CancellationToken cancellationToken)
		{
			//query
			var workers =  _unitOfWork.workerRepository.FindByCondition(x=>x.IsWorking==true,false,x=>x.WorkerPictures).ToList();
			var workerDTOs = new List<GetAllWorkerDTO>();
			foreach (var item in workers)
			{
				var workerDTO = new GetAllWorkerDTO();
				workerDTO.NoteArea = item.NoteArea;
				workerDTO.FileData = Convert.ToBase64String(item.WorkerPictures.FirstOrDefault().FileData);
				workerDTO.WorkerId = item.WorkerId;
				workerDTO.WorkerName = item.WorkerName;
				workerDTO.RFID = item.RFID;

				workerDTOs.Add(workerDTO);
			}

			//return
			return workerDTOs;
		}
	}
}
