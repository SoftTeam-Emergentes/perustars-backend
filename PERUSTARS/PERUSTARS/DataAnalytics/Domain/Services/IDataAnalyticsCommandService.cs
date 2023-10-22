using PERUSTARS.DataAnalytics.Application.Commands;
using System.Threading.Tasks;

namespace PERUSTARS.DataAnalytics.Domain.Services
{
    public interface IDataAnalyticsCommandService
    {
        Task<bool> ExecuteCollectEventLogDataCommandAsync(CollectEventLogDataCommand command);
    }
}
