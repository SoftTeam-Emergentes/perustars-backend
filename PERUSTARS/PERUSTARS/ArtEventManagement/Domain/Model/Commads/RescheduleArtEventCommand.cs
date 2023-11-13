using System;
using MediatR;

namespace PERUSTARS.ArtEventManagement.Domain.Model.Commads
{
    public record RescheduleArtEventCommand :IRequest<string>
    {
        public int id { get; set; }
        public DateTime? newDate { get; set; }
    }

}
