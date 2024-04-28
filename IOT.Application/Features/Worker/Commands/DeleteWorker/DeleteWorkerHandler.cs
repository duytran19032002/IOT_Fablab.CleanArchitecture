using IOT.Application.Contract.Persistence.Generic;
using IOT.Application.Exceptions;
using IOT.Application.Features.Detail.Commands.DeleteDetail;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Application.Features.Worker.Commands.DeleteWorker
{
    public class DeleteWorkerHandler : IRequestHandler<DeleteWorker, string>
	{
		private readonly IUnitOfWork _unitOfWork;

		public DeleteWorkerHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<string> Handle(DeleteWorker request, CancellationToken cancellationToken)
		{

			var workerToDelete = await _unitOfWork.workerRepository.GetByIdAsync( request.WorkerId);
			if (workerToDelete == null)
			{
				throw new NotFoundException(nameof(Worker), request.WorkerId);
			}
			workerToDelete.IsWorking = false;

			_unitOfWork.workerRepository.Update(workerToDelete);
			await _unitOfWork.CompleteAsync();
			return workerToDelete.WorkerId;
		}
	}
}
