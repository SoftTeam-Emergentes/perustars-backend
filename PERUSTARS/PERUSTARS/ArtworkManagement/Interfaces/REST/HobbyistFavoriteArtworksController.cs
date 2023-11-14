using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PERUSTARS.ArtworkManagement.Domain.Model.Commands;
using PERUSTARS.ArtworkManagement.Domain.Services;
using PERUSTARS.ArtworkManagement.Interfaces.REST.Resources;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Attributes;
using PERUSTARS.Shared.Infrastructure.Configuration;

namespace PERUSTARS.ArtworkManagement.Interfaces.REST
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HobbyistFavoriteArtworksController : ControllerBase
    {
        private readonly IHobbyistFavoriteArtworkCommandService _hobbyistFavoriteArtworkCommandService;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public HobbyistFavoriteArtworksController(IHobbyistFavoriteArtworkCommandService hobbyistFavoriteArtworkCommandService, IMapper mapper, AppDbContext context)
        {
            _hobbyistFavoriteArtworkCommandService = hobbyistFavoriteArtworkCommandService;
            _mapper = mapper;
            _context = context;
        }

        [HttpPost("artworks/{artworkId}/hobbyists/{hobbyistId}")]
        public async Task<IActionResult> AssignFavoriteArtwork(long artworkId, long hobbyistId)
        {
            AssignFavoriteArtworkCommand assignFavoriteArtworkCommand = new AssignFavoriteArtworkCommand()
            {
                ArtworkId = artworkId,
                HobbyistId = hobbyistId
            };

            await _hobbyistFavoriteArtworkCommandService.ExecuteAssignFavoriteArtworkCommand(assignFavoriteArtworkCommand);
            
            var successMessage = "Favorite artwork was assigned";
            return Ok(successMessage);
        }

        [HttpGet("hobbyists/{hobbyistId}/artworks")]
        public async Task<IActionResult> GetFavoriteArtworksByHobbyistId(long hobbyistId)
        {
            var favoriteArtworks = await _context.HobbyistFavoriteArtworks
                .Include(hobbyistFavoriteArtwork => hobbyistFavoriteArtwork.Artwork)
                .Where(hobbyistFavoriteArtwork => hobbyistFavoriteArtwork.HobbyistId == hobbyistId).ToListAsync();

            var artworkResources = _mapper.Map<IEnumerable<ArtworkResource>>(favoriteArtworks.Select(hobbyistFavoriteArtwork => hobbyistFavoriteArtwork.Artwork));
            return Ok(artworkResources);
        }
    }
}