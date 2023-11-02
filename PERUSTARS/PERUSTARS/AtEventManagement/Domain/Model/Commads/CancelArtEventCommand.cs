using MediatR;
using PERUSTARS.AtEventManagement.Domain.Model.ValueObjects;

namespace PERUSTARS.AtEventManagement.Domain.Model.Commads
{
    public class CancelArtEventCommand:IRequest<string>{
        public int id { get; set; }
    }
}
