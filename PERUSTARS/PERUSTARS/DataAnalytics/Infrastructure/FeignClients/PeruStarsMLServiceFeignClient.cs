using Microsoft.Extensions.Logging;
using PERUSTARS.DataAnalytics.Infrastructure.FeignClients.Resources;
using PERUSTARS.DataAnalytics.Infrastructure.FeignClients.Resources.Dto;
using PERUSTARS.DataAnalytics.Infrastructure.FeignClients.Resources.Response;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PERUSTARS.DataAnalytics.Infrastructure.FeignClients
{
    public class PeruStarsMLServiceFeignClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<PeruStarsMLServiceFeignClient> _logger;

        public PeruStarsMLServiceFeignClient(HttpClient httpClient, ILogger<PeruStarsMLServiceFeignClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            _httpClient.BaseAddress = new Uri("https://perustars-ml-service.onrender.com");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<bool> ComputeRecommendationSystem()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/recommendation-system/compute-data");
            if (!response.IsSuccessStatusCode) return false;
            string message = await response.Content.ReadAsStringAsync();
            _logger.LogInformation("Result from ml-api: {}", message);
            return true;
        }
        public async Task<MLResponse> GetHobbyistRecommendedArtist(long hobbyistId)
        {
            string path = $"/recommendation-system/hobbyists/{hobbyistId}/recommended-artists";
            _logger.LogInformation($"Calling endpoint {path} from perustars-ml-service");
            HttpResponseMessage response = await _httpClient.GetAsync(path);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Something went wrong when calling perustars-ml-api");
                return new MLResponse { Data = null, statusCode = HttpStatusCode.InternalServerError };
            }
            MLDto data = await response.Content.ReadFromJsonAsync<MLDto>();
            _logger.LogInformation("API call to {} done successfully", path);
            return new MLResponse { Data = data, statusCode = HttpStatusCode.OK };
        }
    }
}
