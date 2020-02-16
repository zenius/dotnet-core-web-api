using System.Linq;
using CityInfo.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
  [ApiController]
  [Route("api/cities")]
  public class CitiesController : ControllerBase
  {
    [HttpGet]
    public IActionResult GetCities()
    {
      return Ok(CityData.Current.Cities);
    }

    [HttpGet("{id}")]
    public IActionResult GetCity(int id)
    {
      var cityToReturn = CityData.Current.Cities.FirstOrDefault(city => city.Id == id);

      if (cityToReturn == null)
      {
        return NotFound();
      }

      return Ok(cityToReturn);
    }
  }
}
