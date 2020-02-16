using System.Collections.Generic;

namespace CityInfo.API.Models
{
  public class City
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public int PointsOfInterestCount
    {
      get
      {
        return PointsOfInterests.Count;
      }
    }

    public ICollection<PointsOfInterest> PointsOfInterests { get; set; } = new List<PointsOfInterest>();
  }
}