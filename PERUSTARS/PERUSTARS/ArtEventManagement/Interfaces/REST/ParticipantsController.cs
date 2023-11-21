using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PERUSTARS.ArtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.ArtEventManagement.Domain.Model.Commads;
using PERUSTARS.ArtEventManagement.Domain.Services.Participant;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Attributes;

namespace PERUSTARS.ArtEventManagement.Interfaces.REST
{
    [ApiController]
    [Route("/api/v1")]
    [Authorize]
    public class ParticipantsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IParticipantQueryService _participantQueryService;
        private readonly IParticipantCommandService _participantCommandService;
        public ParticipantsController(IMapper mapper, IParticipantQueryService participantQueryService, IParticipantCommandService participantCommandService)
        {
            _mapper = mapper;
            _participantQueryService = participantQueryService;
            _participantCommandService=participantCommandService;
        }

        [HttpGet("participants")]
        public async Task<IActionResult> getParticipants()
        {
            IEnumerable<Participant> participants = _participantQueryService.GetParticipants();
            return Ok(participants);
        }

        [HttpGet("participants/hobbyist/{id}")]
        public async Task<IActionResult> getParticipantsByHobbyistId(int id)
        {
            IEnumerable<Participant> participants = _participantQueryService.getParticipantByHobbyistId(id);
            return Ok(participants);
        }
        [HttpGet("participants/artevent/{id}")]
        public async Task<IActionResult> getParticipantsByArtEventId(int id)
        {
            IEnumerable<Participant> participants = _participantQueryService.getParticipantByEventId(id);
            return Ok(participants);
        }

        [HttpDelete("participants/{id}")]
        public async Task<IActionResult> deleteParticipant(int id) {
            DeleteParticipantCommand d = new DeleteParticipantCommand();
            d.id = id;
            string response = _participantCommandService.deleteParticipant(d).Result;
            return Ok(response);
        }
    }
}
