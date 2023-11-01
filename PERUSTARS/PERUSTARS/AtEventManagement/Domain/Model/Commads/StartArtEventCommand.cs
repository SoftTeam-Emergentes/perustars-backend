using MediatR;
using PERUSTARS.AtEventManagement.Domain.Model.ValueObjects;

namespace PERUSTARS.AtEventManagement.Domain.Model.Commads
{
    public class StartArtEventCommand:IRequest<string> { 
        public int id { get; set; }
    };

}
