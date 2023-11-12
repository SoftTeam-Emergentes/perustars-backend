using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PERUSTARS.ArtworkManagement.Domain.Services;
using PERUSTARS.Shared.Infrastructure.Configuration;
using PERUSTARS.ArtworkManagement.Domain.Model.Commands;
using PERUSTARS.ArtworkManagement.Interfaces.REST.Resources;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace PERUSTARS.ArtworkManagement.Interfaces.REST
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ArtworksController : ControllerBase
    {
        private readonly IArtworkCommandService _artworkCommandService;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public ArtworksController(IArtworkCommandService artworkCommandService, IMapper mapper, AppDbContext context)
        {
            _artworkCommandService = artworkCommandService;
            _mapper = mapper;
            _context = context;
        }

        [HttpPost("artists/{artistId}")]
        public async Task<IActionResult> CreateArtwork([FromBody] RegisterArtworkResource registerArtworkResource, long artistId)
        {
            UploadArtworkCommand uploadArtworkCommand = _mapper.Map<UploadArtworkCommand>(registerArtworkResource);
            uploadArtworkCommand.ArtistId = artistId;

            ArtworkResource artworkResource = await _artworkCommandService.ExecuteUploadArtworkCommand(uploadArtworkCommand);
            return Ok(artworkResource);
        }

        [HttpPut("artists/{artistId}/{artworkId}")]
        public async Task<IActionResult> UpdateArtwork([FromBody] EditArtworkResource editArtworkResource, long artworkId, long artistId)
        {
            EditArtworkCommand editArtworkCommand = _mapper.Map<EditArtworkCommand>(editArtworkResource);
            editArtworkCommand.Id = artworkId;
            editArtworkCommand.ArtistId = artistId;

            ArtworkResource artworkResource = await _artworkCommandService.ExecuteEditArtworkCommand(editArtworkCommand);
            return Ok(artworkResource);
        }
        
        [HttpDelete("artists/{artistId}/{artworkId}")]
        public async Task<IActionResult> DeleteArtwork(long artworkId, long artistId)
        {
            DeleteArtworkCommand deleteArtworkCommand = new DeleteArtworkCommand()
            {
                Id = artworkId,
                ArtistId = artistId
            };

            await _artworkCommandService.ExecuteDeleteArtwork(deleteArtworkCommand);
            
            var successMessage = "Artwork was removed";
            return Ok(successMessage);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllArtworks()
        {
            var artworks = await _context.Artworks.ToListAsync();

            var artworkResources = _mapper.Map<IEnumerable<ArtworkResource>>(artworks);
            return Ok(artworkResources);
        }

        [HttpGet("artists/{artistId}")]
        public async Task<IActionResult> GetArtworksByArtistId(long artistId)
        {
            var existingArtist = await _context.Artists.FirstOrDefaultAsync(a => a.ArtistId == artistId);
            if (existingArtist == null)
            {
                return NotFound();
            }

            var artworks = await _context.Artworks.Where(a => a.ArtistId == artistId).ToListAsync();

            var artworkResources = _mapper.Map<IEnumerable<ArtworkResource>>(artworks);
            return Ok(artworkResources);
        }
    }
}
