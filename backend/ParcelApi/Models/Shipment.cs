using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelApi.Models;

public enum AirportCodes
{
  TLL,
  HEL,
  RIX,
}

public class Shipment
{

  [Key]
  [RegularExpression("^[A-Z0-9]{3}-[A-Z0-9]{6}$", ErrorMessage = "Parcel ID must follow the format XXX-XXXXXX")]
  public string? ShipmentId { get; set; }

  [Required(ErrorMessage = "Airport is required")]
  public required AirportCodes Airport { get; set; }

  [Required(ErrorMessage = "Flight number is required")]
  [RegularExpression(@"^[A-Za-z]{2}\d{4}$", ErrorMessage = "Flight number must follow the format LLNNNNN, where 'L' is a letter and 'N' is a number")]
  public required string FlightNumber { get; set; }

  [Required]
  public required DateTime FlightDate { get; set; }

  public List<Bag> Bags { get; set; }

  public bool IsFinalised { get; set; }

  public Shipment()
  {
    Bags = new List<Bag>();
    IsFinalised = false;
  }

}

// TODO double check all data types and validations
