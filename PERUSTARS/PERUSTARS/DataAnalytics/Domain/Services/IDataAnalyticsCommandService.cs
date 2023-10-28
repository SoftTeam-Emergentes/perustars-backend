using PERUSTARS.DataAnalytics.Application.Commands;
using PERUSTARS.DataAnalytics.Domain.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PERUSTARS.DataAnalytics.Domain.Services
{
    public interface IDataAnalyticsCommandService
    {
        Task<IEnumerable<MLTrainingData>> RetrieveTrainingDataToML();
    }
}
