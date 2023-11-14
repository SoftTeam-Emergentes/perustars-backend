using Microsoft.AspNetCore.Mvc;
using PERUSTARS.DataAnalytics.Infrastructure.FeignClients;
using PERUSTARS.DataAnalytics.Infrastructure.FeignClients.Resources.Response;
using System.Threading.Tasks;
using System.Net;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Attributes;

namespace PERUSTARS.DataAnalytics.Interface.REST
{
    [ApiController]
    [Authorize]
    [Route("api/v1/[controller]")]
    public class DataAnalyticsController : ControllerBase
    {
        private readonly PeruStarsMLServiceFeignClient _peruStarsMLServiceFeignClient;

        public DataAnalyticsController(PeruStarsMLServiceFeignClient peruStarsMLServiceFeignClient)
        {
            _peruStarsMLServiceFeignClient = peruStarsMLServiceFeignClient;
        }   

        [HttpGet("hobbyists/{hobbyistId}/recommended-artists")]
        public async Task<IActionResult> GetFavouristArtistsFrom(long hobbyistId)
        {
            MLResponse result = await _peruStarsMLServiceFeignClient.GetHobbyistRecommendedArtist(hobbyistId);
            if(result.statusCode == HttpStatusCode.InternalServerError)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "An error ocurred while trying to call perustars-ml-service");
            }
            return Ok(result.Data);
        }
    }
}
