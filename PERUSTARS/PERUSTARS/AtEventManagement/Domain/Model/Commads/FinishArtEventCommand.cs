using MediatR;
using PERUSTARS.AtEventManagement.Domain.Model.ValueObjects;

namespace PERUSTARS.AtEventManagement.Domain.Model.Commads
{
    public class FinishArtEventCommand:IRequest<string> { 
        public int artEventId { get; set; }
    }

}
