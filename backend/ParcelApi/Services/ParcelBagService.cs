using Microsoft.EntityFrameworkCore;
using ParcelApi.Data;
using ParcelApi.Helpers;
using ParcelApi.Models;
using ParcelApi.Models.Bags;
using ParcelApi.Services;

namespace ParcelApi.Services;

public class ParcelBagService : BagService
{
  public ParcelBagService(ParcelManagerContext context) : base(context)
  {
  }

  public void AddParcelBag(ParcelBag bag)
  {
    var bagListFromDb = _context.Bags.ToList();

    while (true)
    {
      bag.BagId = IdNumberHelpers.GenerateBagId();
      bag.BagType = "Parcel";
      bag.Parcels = new List<Parcel>();
      bag.IsFinalised = false;
      bag.Price = 0;
      bag.ItemCount = 0;
      if (!bagListFromDb.Any(x => x.BagId == bag.BagId))
      {
        _context.ParcelBags.Add(bag);
        _context.SaveChanges();
        break;
      }
    }
  }

  public void AddParcelToBag(string id, Parcel parcel)
  {
    try
    {
      var bag = _context.ParcelBags.Include(p => p.Parcels).FirstOrDefault(b => b.BagId == id);
      if (bag != null && parcel != null)
      {
        if (bag.IsFinalised) throw new Exception("This shipment has already been finalised. You can no longer add parcels to bags in this shipment.");

        if (!LocationHelpers.DoesBagDestinationMatchParcelDestination(bag.DestinationCountry, parcel.DestinationCountry)) throw new Exception($"This bag is bound for {bag.DestinationCountry}. You cannot add a parcel to {parcel.DestinationCountry} to this bag.");

        if(parcel.Weight <= 0 || parcel.Price <= 0) throw new Exception("Weight and price must be greater than 0");

        if (parcel.RecipientName == "string") throw new Exception("Please input a valid recipient name");

        ParcelService parcelService = new ParcelService(_context);
        parcelService.Add(parcel);
        bag.Parcels.Add(parcel);
        bag.ItemCount++;
        bag.Price += parcel.Price;

        _context.SaveChanges();
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to add parcel to bag - Error: {ex.Message}");
      throw;
    }

  }

}
