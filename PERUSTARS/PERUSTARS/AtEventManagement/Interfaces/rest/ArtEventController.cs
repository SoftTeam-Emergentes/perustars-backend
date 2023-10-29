using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PERUSTARS.AtEventManagement.Domain.Model.Commads;
using PERUSTARS.AtEventManagement.Domain.Services.ArtEvent;
using System.Threading.Tasks;

namespace PERUSTARS.AtEventManagement.Interfaces.rest
{
    [Route("/api/v1/artevents")]
    public class ArtEventController :ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IArtEventCommandService _artEventCommandService;
        private readonly IArtEventQueryService _artEventQueryService;
        public ArtEventController(IMapper mapper, IArtEventCommandService artEventCommandService, IArtEventQueryService artEventQueryService)
        {
            _mapper = mapper;
            _artEventCommandService = artEventCommandService;
            _artEventQueryService = artEventQueryService;
        }

    }
}
