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
      if (!bagListFromDb.Any(x => x.BagId == bag.BagId))
      {
        BagService.ParcelBags.Add(bag);
        break;
      }
    }
  }

}
