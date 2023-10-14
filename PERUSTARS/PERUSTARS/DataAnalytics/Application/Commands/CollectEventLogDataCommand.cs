using MediatR;
using PERUSTARS.DataAnalytics.Application.Commands.Response;

namespace PERUSTARS.DataAnalytics.Application.Commands
{
    public class CollectEventLogDataCommand: IRequest<bool>
    {
        public int EventId { get; set; }
    }
}
