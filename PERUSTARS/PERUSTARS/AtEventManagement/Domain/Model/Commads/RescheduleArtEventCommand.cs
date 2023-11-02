using MediatR;
using System;

namespace PERUSTARS.AtEventManagement.Domain.Model.Commads
{
    public record RescheduleArtEventCommand :IRequest<string>
    {
        public int id { get; set; }
        public DateTime? newDate { get; set; }
    }

}
