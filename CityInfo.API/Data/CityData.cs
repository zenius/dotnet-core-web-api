using System.Collections.Generic;
using CityInfo.API.Models;

namespace CityInfo.API.Data
{
  public class CityData
  {
    public static CityData Current { get; } = new CityData();
    public List<City> Cities { get; set; }

    public CityData()
    {
      Cities = new List<City>() {
        new City {
          Id = 1,
          Name = "Kakinada",
          Description = "First Smart City in Andhra Pradesh",
          PointsOfInterest = {
            new PointOfInterest {
              Id = 1,
              Name = "Kakinada beach",
              Description = "Famous destination for weekend"
            },
            new PointOfInterest {
              Id = 2,
              Name = "JNTUK",
              Description = "Educational instution for master and bachelor in engineering"
            }
          }

        },
        new City {
          Id = 2,
          Name = "Hyderabad",
          Description = "City of Biryani",

          PointsOfInterest = {
            new PointOfInterest {
              Id = 3,
              Name = "Paradise",
              Description = "Legend in making Biryani"
            },

          }

        }
      };
    }
  }
}