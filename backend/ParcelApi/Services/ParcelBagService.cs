using Microsoft.EntityFrameworkCore;
using ParcelApi.Data;
using ParcelApi.Helpers;
using ParcelApi.Interfaces;
using ParcelApi.Models;
using ParcelApi.Models.Bags;
using ParcelApi.Services;

namespace ParcelApi.Services;

public class ParcelBagService : BagService, IParcelBagService
{
  public ParcelBagService(ParcelManagerContext context) : base(context)
  {
  }

  public async Task AddParcelBag(ParcelBag bag)
  {
    var bagListFromDb = await _context.Bags.ToListAsync();

    while (true)
    {
      bag.BagId = IdNumberHelpers.GenerateBagId();
      bag.BagType = "Parcel";
      bag.Parcels = new List<Parcel>();
      bag.IsFinalised = false;
      bag.Price = 0;
      bag.Weight = 0;
      bag.ItemCount = 0;
      if (!bagListFromDb.Any(x => x.BagId == bag.BagId))
      {
        await _context.ParcelBags.AddAsync(bag);
        await _context.SaveChangesAsync();
        break;
      }
    }
  }

  public async Task AddParcelToBag(string id, Parcel parcel)
  {
    try
    {
      var bag = await _context.ParcelBags.Include(p => p.Parcels).FirstOrDefaultAsync(b => b.BagId == id);
      if (bag != null && parcel != null)
      {
        if (bag.IsFinalised) throw new Exception("This shipment has already been finalised. You can no longer add parcels to bags in this shipment.");

        if (!LocationHelpers.DoDestinationsMatch(bag.DestinationCountry, parcel.DestinationCountry)) throw new Exception($"This bag is bound for {bag.DestinationCountry}. You cannot add a parcel to {parcel.DestinationCountry} to this bag.");

        if(parcel.Weight <= 0 || parcel.Price <= 0) throw new Exception("Weight and price must be greater than 0");

        if (parcel.RecipientName == "string" || parcel.RecipientName == "") throw new Exception("Please input a valid recipient name");

        ParcelService parcelService = new ParcelService(_context);
        await parcelService.Add(parcel);
        bag.Parcels.Add(parcel);
        bag.ItemCount++;
        bag.Price += parcel.Price;
        bag.Weight += parcel.Weight;

        await _context.SaveChangesAsync();
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to add parcel to bag - Error: {ex.Message}");
      throw;
    }

  }

}
