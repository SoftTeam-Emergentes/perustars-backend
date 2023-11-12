using Microsoft.AspNetCore.Mvc;
using PERUSTARS.DataAnalytics.Infrastructure.FeignClients;
using PERUSTARS.DataAnalytics.Infrastructure.FeignClients.Resources.Response;
using System.Threading.Tasks;
using System.Net;

namespace PERUSTARS.DataAnalytics.Interface.REST
{
    [ApiController]
    public class DataAnalyticsController : ControllerBase
    {
        private readonly PeruStarsMLServiceFeignClient _peruStarsMLServiceFeignClient;

        public DataAnalyticsController(PeruStarsMLServiceFeignClient peruStarsMLServiceFeignClient)
        {
            _peruStarsMLServiceFeignClient = peruStarsMLServiceFeignClient;
        }   

        [HttpGet("api/data-analytics/hobbyists/{hobbyistId}/recommended-artists")]
        public async Task<IActionResult> GetFavouristArtistsFrom(long hobbyistId)
        {
            MLResponse result = await _peruStarsMLServiceFeignClient.GetHobbyistRecommendedArtist(hobbyistId);
            if(result.statusCode == HttpStatusCode.InternalServerError)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "An error ocurred while trying to call perustars-ml-service");
            }
            return Ok(result);
        }
    }
}
