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
    public JsonResult GetCities()
    {
      return new JsonResult(CityData.Current.Cities);
    }

    [HttpGet("{id}")]
    public JsonResult GetCity(int id)
    {
      return new JsonResult(CityData.Current.Cities.FirstOrDefault(city => city.Id == id));
    }
  }
}
