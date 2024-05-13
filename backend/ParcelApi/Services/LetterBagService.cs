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

  public static void AddLettersToBag(LetterBag bag, int letterCount, decimal weight, decimal price)
  {
    if (bag != null && letterCount > 0 && weight > 0 && price > 0)
    {
      bag.LetterCount += letterCount;
      bag.Weight += weight;
      bag.Price += price;
    }
  }

}