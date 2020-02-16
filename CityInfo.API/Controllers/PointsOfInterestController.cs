using System.Linq;
using CityInfo.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
  [ApiController]
  [Route("api/cities/{cityId}/pointsofinterest")]
  public class PointsOfInterestController : ControllerBase
  {
    [HttpGet]
    public IActionResult GetPointsOfInterest(int cityId)
    {
      var cityToReturn = CityData.Current.Cities.FirstOrDefault(city => city.Id == cityId);

      if (cityToReturn == null)
      {
        return NotFound();
      }

      return Ok(cityToReturn.PointsOfInterests);
    }

    [HttpGet("{Id}")]
    public IActionResult GetSinglePointOfInterest(int cityId, int Id)
    {
      var cityToReturn = CityData.Current.Cities.FirstOrDefault(city => city.Id == cityId);

      if (cityToReturn == null)
      {
        return NotFound();
      }

      var pointOfInterest = cityToReturn.PointsOfInterests.FirstOrDefault(p => p.Id == Id);

      if (pointOfInterest == null)
      {
        return NotFound();
      }

      return Ok(pointOfInterest);
    }

  }
}