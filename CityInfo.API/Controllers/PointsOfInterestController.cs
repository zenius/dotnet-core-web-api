using System.Linq;
using CityInfo.API.Data;
using CityInfo.API.Models;
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

      return Ok(cityToReturn.PointsOfInterest);
    }

    [HttpGet("{Id}", Name = "GetPointOfInterest")]
    public IActionResult GetSinglePointOfInterest(int cityId, int Id)
    {
      var cityToReturn = CityData.Current.Cities.FirstOrDefault(city => city.Id == cityId);

      if (cityToReturn == null)
      {
        return NotFound();
      }

      var pointOfInterest = cityToReturn.PointsOfInterest.FirstOrDefault(p => p.Id == Id);

      if (pointOfInterest == null)
      {
        return NotFound();
      }

      return Ok(pointOfInterest);
    }

    [HttpPost]
    public IActionResult CreatePointOfInterest(int cityId,
                   [FromBody] PointsOfInterestForCreation pointOfInterest)
    {
      var city = CityData.Current.Cities.FirstOrDefault(city => city.Id == cityId);
      if (city == null)
      {
        return NotFound();
      }

      var maxPointOfInterestId = CityData.Current.Cities.SelectMany(city => city.PointsOfInterest).Max(city => city.Id);

      var finalPointOfInterest = new PointOfInterest()
      {
        Id = ++maxPointOfInterestId,
        Name = pointOfInterest.Name,
        Description = pointOfInterest.Description
      };

      city.PointsOfInterest.Add(finalPointOfInterest);

      return CreatedAtRoute(
        "GetPointOfInterest",
        new { cityId, Id = finalPointOfInterest.Id },
        finalPointOfInterest
      );
    }

  }
}