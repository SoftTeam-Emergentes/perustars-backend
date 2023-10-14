using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PERUSTARS.DataAnalytics.Application.Commands;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.DataAnalytics.Application.CommandServices
{
    public class CollectEventLogDataCommandHandler : IRequestHandler<CollectEventLogDataCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CollectEventLogDataCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CollectEventLogDataCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
