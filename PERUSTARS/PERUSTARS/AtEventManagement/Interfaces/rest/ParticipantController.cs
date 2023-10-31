using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.AtEventManagement.Domain.Services.Participant;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PERUSTARS.AtEventManagement.Interfaces.rest
{
    [Route("/api/v1/participants")]
    public class ParticipantController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IParticipantQueryService _participantQueryService;
        public ParticipantController(IMapper mapper, IParticipantQueryService participantQueryService)
        {
            _mapper = mapper;
            _participantQueryService = participantQueryService;
        }

        [HttpGet]
        public async Task<IActionResult> getParticipants() {
            IEnumerable<Participant> participants = _participantQueryService.GetParticipants();
            return Ok(participants);
        }

        [HttpGet("/hobbyist/{id}")]
        public async Task<IActionResult> getParticipantsByHobbyistId(int id)
        {
            IEnumerable<Participant> participants = _participantQueryService.getParticipantByHobbyistId(id);
            return Ok(participants);
        }
        [HttpGet("/artevent/{id}")]
        public async Task<IActionResult> getParticipantsByArtEventId(int id)
        {
            IEnumerable<Participant> participants = _participantQueryService.getParticipantByEventId(id);
            return Ok(participants);
        }
    }
