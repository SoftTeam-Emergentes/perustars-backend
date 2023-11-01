using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.AtEventManagement.Domain.Model.Repositories;
using System.Collections.Generic;

namespace PERUSTARS.AtEventManagement.Domain.Services.ArtEvent
{
    public interface IArtEventQueryService
    {
        public PERUSTARS.AtEventManagement.Domain.Model.Aggregates.ArtEvent getArtEventById(long id);
        public void deleteArtEvent(long id);
        public IEnumerable<PERUSTARS.AtEventManagement.Domain.Model.Aggregates.ArtEvent> getArtEvents();
        public IEnumerable<PERUSTARS.AtEventManagement.Domain.Model.Aggregates.ArtEvent> getArtEventsByHobbyistId(long id);
        public IEnumerable<PERUSTARS.AtEventManagement.Domain.Model.Aggregates.ArtEvent> getArtEventByArtistId(long id);


    }
}
