using AutoMapper;
using FluentValidation;
using IOT.Application.Contract.Logging;
using IOT.Application.Contract.Persistence;
using IOT.Application.Contract.Persistence.Generic;
using IOT.Application.Exceptions;
using IOT.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Application.Features.Project.Commands.CreatePrjDetail
{
    public class CreatePrjDetailHander : IRequestHandler<CreatePrjDetail, string>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IAppLogger<CreatePrjDetailHander> _logger;


		public CreatePrjDetailHander(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<CreatePrjDetailHander> logger)
		{ 
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_logger = logger;

		}



        public async Task<string> Handle(CreatePrjDetail request, CancellationToken cancellationToken)
		{
			var validator = new CreatePrjDetailValidation();
			var validatorResult = await validator.ValidateAsync(request);
			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Location", validatorResult);
			}

			var prjToCreate = new Domain.Project
			{
				ProjectId = request.ProjectId,
				ProjectName = request.ProjectName,
				

			};

			 _unitOfWork.projectRepository.Add(prjToCreate);
			// _unitOfWork.projectRepository.AddSyn(prjToCreate);


			foreach (var detail in request.Details)
			{
				var detailToCreate = new Domain.Detail
				{
					DetailId = detail.DetailId,
					DetailName = detail.DetailName,
					ProjectId = request.ProjectId,
					DetailStatus = 0,
					StartTimePre = detail.StartTimePre,
					EndTimePre = detail.EndTimePre,
					NoteLog = detail.NoteLog
					

					
				};


				  _unitOfWork.detailRepository.Add(detailToCreate);

				_logger.LogWarning("post Detail {0} - {1}", nameof(Detail), detail.DetailId);
				if(!string.IsNullOrEmpty(detail.FileData))
				{
					var pic = new DetailPicture
					{
						DetailPictureId = Guid.NewGuid(),
						DetailId = detail.DetailId,
						FileData = Convert.FromBase64String(detail.FileData)
					};
				 	 _unitOfWork.detailPictureRepository.Add(pic);
					_logger.LogWarning("post DetailPicture {0} - {1}", nameof(DetailPicture), detail.DetailId);

				}

			}
			await _unitOfWork.CompleteAsync();
			//return 
			return prjToCreate.ProjectId;
		}
	}
}
