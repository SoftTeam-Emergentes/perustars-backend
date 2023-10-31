using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PERUSTARS.DataAnalytics.Infrastructure.FeignClients
{
    public class MLServiceFeignClient
    {
        private readonly HttpClient _httpClient;
        private readonly IDistributedCache _cache;
        private const string _endpoint = "http://localhost:8090/api/ml_service";
        public MLServiceFeignClient(IDistributedCache cache)
        {
            _httpClient = new HttpClient();
            _cache = cache;
        }

        public async Task<IEnumerable<MLRDataResource>?> setCacheMlDataAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_endpoint);
            if (!response.IsSuccessStatusCode) return null;
            string content = await response.Content.ReadAsStringAsync();
            IEnumerable<MLRDataResource>? deserializedContent = JsonSerializer.Deserialize<IEnumerable<MLRDataResource>>(content);
            return deserializedContent;
        }

        public record MLRDataResource(long ArtistId, long HobbystId, long rating);
    }
}
