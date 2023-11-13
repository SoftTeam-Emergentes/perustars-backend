using MediatR;

namespace PERUSTARS.AtEventManagement.Domain.Model.Commads
{
    public class DeleteArtEventCommand:IRequest<string>
    {
        public int id { get; set; }
    }
}
