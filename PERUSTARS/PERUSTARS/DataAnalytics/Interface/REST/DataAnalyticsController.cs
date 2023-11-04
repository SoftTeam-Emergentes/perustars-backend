using Microsoft.AspNetCore.Mvc;

namespace PERUSTARS.DataAnalytics.Interface.REST
{
    [ApiController]
    [Route("/data-analytics")]
    public class DataAnalyticsController : ControllerBase
    {
        [HttpGet(Name = "/hobbyists/{hobbyistId}/favourites-artists")]
        public IActionResult GetFavouristArtistsFrom(long hobbyistId)
        {

            return Ok();
        }
    }
}
