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
      Cities = new List<City>()
      {
          new  City{ Id = 1 , Name =  "Kakinada", Description = "First Smart City in Andhra Pradesh"},
          new  City{ Id = 2 , Name = "Hyderabad", Description = "City of Biryani"}
      };
    }
  }
}