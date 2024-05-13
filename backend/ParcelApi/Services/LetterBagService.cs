using ParcelApi.Helpers;
using ParcelApi.Models;
using ParcelApi.Models.Bags;

namespace ParcelApi.Services;

public class LetterBagService
{

    public static void AddLetterBag(LetterBag bag)
  {
    var bagListFromDb = BagService.GetAllBags();

    while (true)
    {
      bag.BagId = IdNumberHelpers.GenerateBagId();
      bag.BagType = "Letter";
      if (!bagListFromDb.Any(x => x.BagId == bag.BagId))
      {
        BagService.LetterBags.Add(bag);
        break;
      }
    }
  }

}