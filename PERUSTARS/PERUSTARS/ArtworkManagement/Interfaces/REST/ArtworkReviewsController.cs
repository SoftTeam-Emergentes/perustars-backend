using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PERUSTARS.ArtworkManagement.Domain.Model.Commands;
using PERUSTARS.ArtworkManagement.Domain.Services;
using PERUSTARS.ArtworkManagement.Interfaces.REST.Resources;
using PERUSTARS.Shared.Infrastructure.Configuration;

namespace PERUSTARS.ArtworkManagement.Interfaces.REST
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtworkReviewsController : ControllerBase
    {
        private readonly IArtworkReviewCommandService _artworkReviewCommandService;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public ArtworkReviewsController(IArtworkReviewCommandService artworkReviewCommandService, IMapper mapper, AppDbContext context)
        {
            _artworkReviewCommandService = artworkReviewCommandService;
            _mapper = mapper;
            _context = context;
        }

        [HttpPost("hobbyists/{hobbyistId}/artworks/{artworkId}")]
        public async Task<IActionResult> CreateArtworkReview([FromBody] RegisterArtworkReviewResource registerArtworkReviewResource, long hobbyistId, long artworkId)
        {
            ReviewArtworkCommand reviewArtworkCommand = _mapper.Map<ReviewArtworkCommand>(registerArtworkReviewResource);
            reviewArtworkCommand.HobbyistId = hobbyistId;
            reviewArtworkCommand.ArtworkId = artworkId;

            ArtworkReviewResource artworkReviewResource = await _artworkReviewCommandService.ExecuteReviewArtworkCommand(reviewArtworkCommand);
            return Ok(artworkReviewResource);
        }

        [HttpGet("artworks/{artworkId}")]
        public async Task<IActionResult> GetArtworkReviewsByArtworkId(long artworkId)
        {
            var existingArtwork = await _context.Artworks.FirstOrDefaultAsync(x => x.Id == artworkId);
            if (existingArtwork == null)
            {
                return NotFound();
            }

            var artworkReviews = await _context.ArtworkReviews.Where(x => x.ArtworkId == artworkId).ToListAsync();
            
            var artworkReviewResources = _mapper.Map<IEnumerable<ArtworkReviewResource>>(artworkReviews);
            return Ok(artworkReviewResources);
        }
    }
}