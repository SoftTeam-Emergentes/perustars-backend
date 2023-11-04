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

namespace PERUSTARS.ProfileManagement.Application.Commands.Handlers
{
    public class FollowArtistCommandHandler : IRequestHandler<FollowArtistCommand, Unit>
    {
        private readonly AppDbContext _context;
        private readonly IArtistRepository _artistRepository;
        private readonly IPublisher _publisher;

        public FollowArtistCommandHandler(AppDbContext context, IArtistRepository artistRepository, IPublisher publisher)
        {
            _context = context;
            _artistRepository = artistRepository;
            _publisher = publisher;
        }

        public async Task<Unit> Handle(FollowArtistCommand request, CancellationToken cancellationToken)
        {
            var hobbyist = await _context.Hobbyists.FindAsync(request.HobbyistId);
            var artist = await _context.Artists.FindAsync(request.ArtistId);

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
            var follower = new Follower { HobbyistId = hobbyist.HobbyistId, ArtistId = artist.ArtistId, RegistrationDate = DateTime.Now };
            _context.Followers.Add(follower);
            
            artist.FollowersArtist.Add(follower);

           
            //artist.NumberOfFollowers++;

            await _context.SaveChangesAsync(cancellationToken);

            await _publisher.Publish(new ArtistFollowedEvent()
            {
                ArtistId = artist.ArtistId,
                HobbyistId = hobbyist.HobbyistId
            });

            return Unit.Value;
        }
    }

}