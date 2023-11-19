using MediatR;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Model.Commands;
using PERUSTARS.ProfileManagement.Domain.Repositories;
using PERUSTARS.Shared.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PERUSTARS.ProfileManagement.Application.Commands.Handlers
{
    public class DeleteFollowerCommandHandler:IRequestHandler<DeleteFollowerCommand,string>
    {
        private readonly IFollowerRepository _followerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteFollowerCommandHandler(IFollowerRepository followerRepository, IUnitOfWork unitOfWork)
        {
            _followerRepository = followerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(DeleteFollowerCommand request, CancellationToken cancellationToken)
        {
            Follower follower = await _followerRepository.findFollowerByHobbyistId(request.HobbyistId);
            if (follower == null)
            {
                return "Something went wrogn GAAAAAAAAA";
            }
            _followerRepository.Remove(follower);
            await _unitOfWork.CompleteAsync();
            return "Follower deleted";
        }
    }
}
