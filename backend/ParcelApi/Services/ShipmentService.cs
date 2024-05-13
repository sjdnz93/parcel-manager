using ParcelApi.Helpers;
using ParcelApi.Models;
using ParcelApi.Models.Bags;

namespace ParcelApi.Services;

public static class ShipmentService
{
  public static List<Shipment> Shipments { get; }

  static ShipmentService()
  {
    Shipments = new List<Shipment>
    {
      new Shipment()
      {
        ShipmentId = IdNumberHelpers.GenerateShipmentId(),
        Airport = AirportCodes.TLL,
        FlightNumber = "TL123",
        FlightDate = DateTime.Now.AddDays(1),
      },
      new Shipment()
      {
        ShipmentId = "123-BBBBBB",
        Airport = AirportCodes.RIX,
        FlightNumber = "FN126",
        FlightDate = DateTime.Now.AddDays(6),
      }
    };
  }

  public static List<Shipment> GetAll() => Shipments;

  public static Shipment? Get(string id) => Shipments.FirstOrDefault(s => s.ShipmentId == id);

  public static void Add(Shipment shipment)
  {
    var shipmentList = GetAll();
    while (true)
    {
      shipment.ShipmentId = IdNumberHelpers.GenerateShipmentId();
      shipment.Bags = new List<Bag>();
      shipment.IsFinalised = false;
      if (!shipmentList.Any(x => x.ShipmentId == shipment.ShipmentId))
      {
        Shipments.Add(shipment);
        break;
      }
    }
  }

  public static void AddParcelBagToShipment(Shipment shipment, ParcelBag bag)
  {
    if (shipment != null)
    {
      shipment.Bags ??= new List<Bag>();
      ParcelBagService.AddParcelBag(bag);
      shipment.Bags.Add(bag);
    }

  }

  public static void AddLetterBagToShipment(Shipment shipment, LetterBag bag)
  {
    if (shipment != null)
    {
      shipment.Bags ??= new List<Bag>();
      LetterBagService.AddLetterBag(bag);
      shipment.Bags.Add(bag);
    }

  }

}
