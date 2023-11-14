using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PERUSTARS.ArtworkManagement.Domain.Services;
using PERUSTARS.Shared.Infrastructure.Configuration;
using PERUSTARS.ArtworkManagement.Domain.Model.Commands;
using PERUSTARS.ArtworkManagement.Interfaces.REST.Resources;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Attributes;

namespace PERUSTARS.ArtworkManagement.Interfaces.REST
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ArtworkRecommendationsController : ControllerBase
    {
        private readonly IArtworkRecommendationCommandService _artworkRecommendationCommandService;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public ArtworkRecommendationsController(IArtworkRecommendationCommandService artworkRecommendationCommandService, IMapper mapper, AppDbContext context)
        {
            _artworkRecommendationCommandService = artworkRecommendationCommandService;
            _mapper = mapper;
            _context = context;
        }

        [HttpPost("hobbyists/{hobbyistId}/artists/{artistId}/artworks/{artworkId}")]
        public async Task<IActionResult> CreateArtworkRecommendation(long hobbyistId, long artistId, long artworkId)
        {
            RecommendArtworkCommand recommendArtworkCommand = new RecommendArtworkCommand()
            {
                HobbyistId = hobbyistId,
                ArtistId = artistId,
                ArtworkId = artworkId
            };

            ArtworkRecommendationResource artworkRecommendationResource = await _artworkRecommendationCommandService.ExecuteRecommendArtworkCommand(recommendArtworkCommand);
            return Ok(artworkRecommendationResource);
        }

        [HttpGet]
        public async Task<IActionResult> GetArtworkRecommendations()
        {
            var artworkRecommendations = await _context.ArtworkRecommendations.ToListAsync();
            
            var artworkRecommendationResources = _mapper.Map<IEnumerable<ArtworkRecommendationResource>>(artworkRecommendations);
            return Ok(artworkRecommendationResources);
        }
    }
}