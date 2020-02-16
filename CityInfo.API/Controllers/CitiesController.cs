using System.Collections.Generic;
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
      return new JsonResult(
        new List<object>() {
          new { Id = 1 , Name =  "Kakinada"},
          new { Id = 2 , Name = "Hyderabad"}
        }
      );
    }
  }
}
