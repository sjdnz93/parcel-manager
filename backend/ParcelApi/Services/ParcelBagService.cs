using ParcelApi.Helpers;
using ParcelApi.Models;
using ParcelApi.Models.Bags;
using ParcelApi.Services;

namespace ParcelApi.Services;

public class ParcelBagService
{
  public static void AddParcelBag(ParcelBag bag)
  {
    var bagListFromDb = BagService.GetAllBags();

    while (true)
    {
      bag.BagId = IdNumberHelpers.GenerateBagId();
      bag.BagType = "Parcel";
      bag.Parcels = new List<Parcel>();
      bag.IsFinalised = false;
      if (!bagListFromDb.Any(x => x.BagId == bag.BagId))
      {
        BagService.ParcelBags.Add(bag);
        break;
      }
    }
  }

  public static void AddParcelToBag(ParcelBag bag, Parcel parcel)
  {
    try
    {
      if (bag != null && parcel != null)
      {
        if (bag.IsFinalised) throw new Exception("This shipment has already been finalised. You can no longer add parcels to bags in this shipment.");

        if (!LocationHelpers.DoesBagDestinationMatchParcelDestination(bag.DestinationCountry, parcel.DestinationCountry)) throw new Exception($"This bag is bound for {bag.DestinationCountry}. You cannot add a parcel to {parcel.DestinationCountry} to this bag.");
        
        bag.Parcels ??= new List<Parcel>();
        ParcelService.Add(parcel);
        bag.Parcels.Add(parcel);
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to add parcel to bag - Error: {ex.Message}");
      throw;
    }

  }

}
