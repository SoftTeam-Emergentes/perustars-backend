using System.Collections.Generic;

namespace PERUSTARS.ArtEventManagement.Domain.Services.ArtEvent
{
    public interface IArtEventQueryService
    {
        public Model.Aggregates.ArtEvent getArtEventById(long id);
        public void deleteArtEvent(long id);
        public IEnumerable<Model.Aggregates.ArtEvent> getArtEvents();
        public IEnumerable<Model.Aggregates.ArtEvent> getArtEventsByHobbyistId(long id);
        public IEnumerable<Model.Aggregates.ArtEvent> getArtEventByArtistId(long id);


    }
}
