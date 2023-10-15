using PERUSTARS.DataAnalytics.Domain.Model.Aggregates;
using System.Collections.Concurrent;

namespace PERUSTARS.DataAnalytics.Domain.Services
{
    public class DataAnalyticsFormatter
    {
        public static ConcurrentQueue<DataAnalytic> pendingToCompleteDataAnalyticsElements = new ConcurrentQueue<DataAnalytic>();
        public static ConcurrentBag<DataAnalytic> dataAnalyticsToSendToMLModel = new ConcurrentBag<DataAnalytic>();

    }
}
