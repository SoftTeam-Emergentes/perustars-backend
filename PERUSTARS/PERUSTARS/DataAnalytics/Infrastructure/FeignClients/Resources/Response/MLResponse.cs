using PERUSTARS.DataAnalytics.Infrastructure.FeignClients.Resources.Dto;
using System.Net;

namespace PERUSTARS.DataAnalytics.Infrastructure.FeignClients.Resources.Response
{
    public class MLResponse
    {
        public MLDto? Data { get; set; }
        public HttpStatusCode statusCode { get; set; }
    }
}
