using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Model.Commands;
using PERUSTARS.Shared.Infrastructure.Configuration;

namespace PERUSTARS.ProfileManagement.Application.Commands.Handlers
{
    public class FollowArtistCommandHandler : IRequestHandler<FollowArtistCommand, Unit>
    {
        private readonly AppDbContext _context;

        public FollowArtistCommandHandler(AppDbContext context)
        {
            _context = context;
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
            var follower = new Follower { HobbyistId = hobbyist.HobbyistId, ArtistId = artist.ArtistId };
            _context.Followers.Add(follower);

           
            //artist.NumberOfFollowers++;

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }

}