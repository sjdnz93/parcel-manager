using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ParcelApi.Helpers;
using ParcelApi.Models.Bags;

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
  public string? ShipmentId { get; set; }

  [Required(ErrorMessage = "Airport is required")]
  [EnumDataType(typeof(AirportCodes), ErrorMessage = "Invalid Airport code")]
  public required AirportCodes Airport { get; set; }

  [Required(ErrorMessage = "Destination country is required")]
  [RegularExpression("^(EE|LV|FI)$", ErrorMessage = "Country must be 'EE', 'LV', or 'FI'")]
  public required string DestinationCountry { get; set; }

  [Required(ErrorMessage = "Flight number is required")]
  [RegularExpression(@"^[A-Z]{2}\d{4}$", ErrorMessage = "Flight number must follow the format LLNNNNN, where 'L' is a letter and 'N' is a number")]
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
