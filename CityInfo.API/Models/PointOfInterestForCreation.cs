using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Models
{
  public class PointsOfInterestForCreation
  {
    [MaxLength(50)]
    [Required(ErrorMessage = "Please provide a name with a maximum length of 50.")]
    public string Name { get; set; }

    [MaxLength(200)]
    public string Description { get; set; }
  }
}