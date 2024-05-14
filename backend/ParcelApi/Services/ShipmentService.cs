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

  public static void FinaliseShipment(Shipment shipment)
  {
    var todaysDate = DateTime.Now;
    if (shipment != null)
    {
      if (shipment.Bags == null || shipment.Bags.Count == 0) throw new Exception("Shipment has no bags");
      if (shipment.FlightDate < todaysDate) throw new Exception("Shipment flight date has passed");

      var bagList = shipment.Bags;
      foreach (var bag in bagList)
      {
        if (bag != null && bag.BagType != null && bag.BagId != null)
        {
          if (bag.BagType == "Parcel")
          {
            var populatedParcelBag = BagService.GetParcelBagById(bag.BagId);
            if (populatedParcelBag != null)
            {
              if (populatedParcelBag.Parcels == null || populatedParcelBag.Parcels.Count == 0) throw new Exception($"Bag ID {bag.BagId} has no parcels. Please fill bag before finalising shipment.");
            }
          }
          else if (bag.BagType == "Letter")
          {
            var populatedLetterBag = BagService.GetLetterBagById(bag.BagId);
            if (populatedLetterBag != null)
            {
              if (populatedLetterBag.LetterCount == 0) throw new Exception($"Bag ID {bag.BagId} has no letters. Please fill bag before finalising shipment.");
              if (populatedLetterBag.Weight == 0) throw new Exception($"Bag ID {bag.BagId} has no weight. Please fill bag before finalising shipment.");
              if (populatedLetterBag.Price == 0) throw new Exception($"Bag ID {bag.BagId} has no price. Please cost up the bag before finalising shipment.");
            }
          }
        }
      }

      shipment.IsFinalised = true;

    }
  }

}
