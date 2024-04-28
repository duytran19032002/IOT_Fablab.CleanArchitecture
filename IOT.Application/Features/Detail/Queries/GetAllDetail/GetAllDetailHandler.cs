using AutoMapper;
using IOT.Application.Contract.Persistence.Generic;
using IOT.Application.Features.Project.Queries.GetAllPrj;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Application.Features.Detail.Queries.GetAllDetail
{
    public class GetAllDetailHandler : IRequestHandler<GetAllDetails, List<GetAllDetailsDTO>>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;
		public GetAllDetailHandler(IMapper mapper, IUnitOfWork unitOfWork)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<List<GetAllDetailsDTO>> Handle(GetAllDetails request, CancellationToken cancellationToken)
		{
			//query
			var details =  _unitOfWork.detailRepository.FindAll().ToList();

			if (request.DetailStatusFromSearch != null)
			{
				details= details.Where(x=>x.DetailStatus == request.DetailStatusFromSearch).ToList();
		
			}

			// convert
			var data = _mapper.Map<List<GetAllDetailsDTO>>(details);
			foreach (var item in data)
			{


			var dataPicture = _unitOfWork.detailPictureRepository.Find(x => x.DetailId == item.DetailId).FirstOrDefault();
				if(dataPicture != null)
				{
					item.FileData = dataPicture.FileData;
				}

			//	item.WorkerId = workerForDetail.WorkerId;
			}
			

			//return
			return data;
		}
	}
}
