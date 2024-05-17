using Microsoft.EntityFrameworkCore;
using ParcelApi.Data;
using ParcelApi.Helpers;
using ParcelApi.Models;
using ParcelApi.Models.Bags;

namespace ParcelApi.Services;

public class ShipmentService
{
  private readonly ParcelManagerContext _context;

  public ShipmentService(ParcelManagerContext context)
  {
    _context = context;
  }

  public List<Shipment> GetAll()
  {
    try
    {
      return _context.Shipments.Include(s => s.Bags).ToList();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to get shipments - Error: {ex.Message}");
      throw;
    }
  }

  public Shipment? Get(string id)
  {
    try
    {
      return _context.Shipments.Include(s => s.Bags)
                               .FirstOrDefault(s => s.ShipmentId == id);
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to get shipment - Error: {ex.Message}");
      throw;
    }

  }

  public void AddShipment(Shipment shipment)
  {
    try
    {
      var shipmentList = GetAll();
      while (true)
      {
        if (LocationHelpers.IsFlightInternal(shipment.DestinationCountry, shipment.Airport)) throw new Exception("Shipment destination is in the same country as shipment origin airport. Do you really need to make an internal flight? Probably not.");

        if(DateHelpers.IsDateInPast(shipment.FlightDate)) throw new Exception("Shipment flight date is in the past. Please update.");

        shipment.ShipmentId = IdNumberHelpers.GenerateShipmentId();
        shipment.Bags = new List<Bag>();
        shipment.IsFinalised = false;

        if (!shipmentList.Any(x => x.ShipmentId == shipment.ShipmentId))
        {
          try
          {
            _context.Shipments.Add(shipment);
            _context.SaveChanges();
            break;
          }
          catch (Exception ex)
          {
            Console.WriteLine($"Failed to add shipment - Error: {ex.Message}");
            throw;
          }
        }
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to add shipment - Error: {ex.Message}");
      throw;
    }

  }

  public void AddParcelBagToShipment(string id, ParcelBag bag)
  {
    try
    {
      var shipment = _context.Shipments
                             .Include(s => s.Bags)
                             .FirstOrDefault(s => s.ShipmentId == id);
      if (shipment != null)
      {

        if (shipment.IsFinalised) throw new Exception("Shipment has already been finalised");

        if (LocationHelpers.IsFlightInternal(bag.DestinationCountry, shipment.Airport)) throw new Exception("Bag destination is in the same country as shipment origin airport. Do you really need to make an internal flight to transport this package? Probably not.");

        if (!LocationHelpers.DoesShipmentDestinationMatchBagDestination(shipment.DestinationCountry, bag.DestinationCountry)) throw new Exception("Shipment destination country does not match bag destination country");

        ParcelBagService parcelBagService = new ParcelBagService(_context);
        parcelBagService.AddParcelBag(bag);
        
        shipment.Bags.Add(bag);

        _context.SaveChanges();

      }
      else throw new Exception("Shipment not found");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to add bag to shipment - Error: {ex.Message}");
      throw;
    }

  }

  public void AddLetterBagToShipment(Shipment shipment, LetterBag bag)
  {
    try
    {
      if (shipment != null)
      {
        if (shipment.IsFinalised) throw new Exception("Shipment has already been finalised");

        if (LocationHelpers.IsFlightInternal(bag.DestinationCountry, shipment.Airport)) throw new Exception("Bag destination is in the same country as shipment origin airport. Do you really need to make an internal flight to transport this package? Probably not.");

        if (!LocationHelpers.DoesShipmentDestinationMatchBagDestination(shipment.DestinationCountry, bag.DestinationCountry)) throw new Exception("Shipment destination country does not match bag destination country");

        shipment.Bags ??= new List<Bag>();
        LetterBagService letterBagService = new LetterBagService(_context);
        letterBagService.AddLetterBag(bag);
        shipment.Bags.Add(bag);

        _context.SaveChanges();
      }
      else throw new Exception("Shipment not found");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to add bag to shipment - Error: {ex.Message}");
      throw;
    }


  }

  public void FinaliseShipment(Shipment shipment)
  {
    try
    {
      var todaysDate = DateTime.Now;
      BagService bagService = new BagService(_context);
      if (shipment != null)
      {
        if (shipment.IsFinalised) throw new Exception("Shipment has already been finalised");
        if (shipment.Bags == null || shipment.Bags.Count == 0) throw new Exception("Shipment has no bags");
        if (shipment.FlightDate < todaysDate) throw new Exception("Shipment flight date has passed");

        var bagList = shipment.Bags;
        foreach (var bag in bagList)
        {
          if (bag != null && bag.BagType != null && bag.BagId != null)
          {
            if (bag.BagType == "Parcel")
            {
              var populatedParcelBag = bagService.GetParcelBagById(bag.BagId);
              if (populatedParcelBag != null)
              {
                if (populatedParcelBag.Parcels == null || populatedParcelBag.Parcels.Count == 0) throw new Exception($"Bag ID {bag.BagId} has no parcels. Please fill bag before finalising shipment.");
              }
            }
            else if (bag.BagType == "Letter")
            {
              var populatedLetterBag = bagService.GetLetterBagById(bag.BagId);
              if (populatedLetterBag != null)
              {
                if (populatedLetterBag.LetterCount == 0) throw new Exception($"Bag ID {bag.BagId} has no letters. Please fill bag before finalising shipment.");
                if (populatedLetterBag.Weight == 0) throw new Exception($"Bag ID {bag.BagId} has no weight. Please fill bag before finalising shipment.");
                if (populatedLetterBag.Price == 0) throw new Exception($"Bag ID {bag.BagId} has no price. Please cost up the bag before finalising shipment.");
              }
            }
          }
        }

        foreach (var bag in bagList)
        {
          bag.IsFinalised = true;
        }

        shipment.IsFinalised = true;

        _context.SaveChanges();

      }
    }

    catch (Exception ex)
    {
      Console.WriteLine($"Error occured: {ex.Message}");
      throw;
    }

  }


}

// TODO add PUT and DELETE methods
