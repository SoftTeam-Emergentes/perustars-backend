using PERUSTARS.DataAnalytics.Application.Commands;
using PERUSTARS.DataAnalytics.Domain.Model.Entities;
using System.Threading.Tasks;

namespace PERUSTARS.DataAnalytics.Domain.Services
{
    public interface IDataAnalyticsCommandService
    {
        Task<MLTrainingData> RetrieveTrainingDataToML();
    }
}
