using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Model.Commands;
using PERUSTARS.ProfileManagement.Domain.Repositories;
using PERUSTARS.ProfileManagement.Domain.Model.Events;
using PERUSTARS.Shared.Infrastructure.Configuration;
using PERUSTARS.Shared.Domain.Repositories;
namespace PERUSTARS.ProfileManagement.Application.Commands.Handlers
{
    public class FollowArtistCommandHandler : IRequestHandler<FollowArtistCommand, Unit>
    {
        private readonly AppDbContext _context;
        private readonly IArtistRepository _artistRepository;
        private readonly IHobbyistRepository _hobbyistRepository;
        private readonly IFollowerRepository _followerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPublisher _publisher;

        public FollowArtistCommandHandler(AppDbContext context, IArtistRepository artistRepository, IPublisher publisher, IHobbyistRepository hobbyistRepository,IFollowerRepository followerRepository, IUnitOfWork unitOfWork)
        {
            _context = context;
            _artistRepository = artistRepository;
            _publisher = publisher;
            _hobbyistRepository = hobbyistRepository;
            _followerRepository = followerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(FollowArtistCommand request, CancellationToken cancellationToken)
        {
            var hobbyist = await _hobbyistRepository.FindByIdAsync(request.HobbyistId);
            var artist = await _artistRepository.FindByIdAsync(request.ArtistId);
            
            if (hobbyist == null || artist == null)
            {
                throw new ApplicationException("El aficionado o el artista no existen en la base de datos.");
            }

            // Verificar si el seguidor ya sigue al artista
            var existingFollow = await _context.Followers
                .FirstOrDefaultAsync(f => f.HobbyistId == hobbyist.HobbyistId && f.ArtistId == artist.ArtistId);

            if (existingFollow != null)
            {
                return Unit.Value;
            }

            // Agregar la relación de seguimiento
            var follower = new Follower {  Collected=false,Hobbyist=hobbyist,Artist=artist,Id=0,HobbyistId = hobbyist.HobbyistId, ArtistId = artist.ArtistId, RegistrationDate = DateTime.Now };

            await _followerRepository.AddAsync(follower);
            await _unitOfWork.CompleteAsync();
            

            await _publisher.Publish(new ArtistFollowedEvent()
            {
                ArtistId = artist.ArtistId,
                HobbyistId = hobbyist.HobbyistId
            });

            return Unit.Value;
        }
    }

}