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
  public required string ShipmentId { get; set; }

  [Required]
  public required AirportCodes Airport { get; set; }

  [Required]
  public required string FlightNumber { get; set; }

  [Required]
  public required DateTime FlightDate { get; set; }

  [Required]
  public required List<Bag> Bags { get; set; }

  public required bool IsFinalised { get; set; }

  public Shipment(string shipmentId)
  {
    ShipmentId = shipmentId;
    Bags = new List<Bag>();
    IsFinalised = false;
  }

}

// TODO double check all data types and validations
