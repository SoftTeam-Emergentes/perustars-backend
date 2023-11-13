using System.Collections.Generic;
using PERUSTARS.ArtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.ArtEventManagement.Domain.Model.Repositories;
using PERUSTARS.ArtEventManagement.Domain.Services.ArtEvent;

namespace PERUSTARS.ArtEventManagement.Application.artevents.service
{
    public class ArtEventQueryService: IArtEventQueryService
    {
        private readonly IArtEventRepository _artEventRepository;
        public ArtEventQueryService(IArtEventRepository artEventRepository)
        {
            _artEventRepository = artEventRepository;
        }

        public void deleteArtEvent(long id)
        {
            ArtEvent artEvent = _artEventRepository.FindByIdAsync(id).Result;
            _artEventRepository.Remove(artEvent);
        }

        public IEnumerable<ArtEvent> getArtEventByArtistId(long id)
        {
            return _artEventRepository.findByArtistIdAsync(id).Result;
        }

        public ArtEvent getArtEventById(long id)
        {
            return _artEventRepository.FindByIdAsync(id).Result;
        }

        public IEnumerable<ArtEvent> getArtEvents()
        {
            return _artEventRepository.ListAsync().Result;
        }

        public IEnumerable<ArtEvent> getArtEventsByHobbyistId(long id)
        {
            return _artEventRepository.findByHobbyistIdAsync(id).Result;
        }
    }
}
