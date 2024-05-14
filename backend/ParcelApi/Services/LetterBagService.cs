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
      bag.IsFinalised = false;
      if (!bagListFromDb.Any(x => x.BagId == bag.BagId))
      {
        BagService.LetterBags.Add(bag);
        break;
      }
    }
  }

  public static void AddLettersToBag(LetterBag bag, int letterCount, decimal weight, decimal price)
  {
    try
    {
      if (bag != null && letterCount > 0 && weight > 0 && price > 0)
      {
        if (bag.IsFinalised) throw new Exception("This shipment has already been finalised. You can no longer add letters to bags in this shipment");
        bag.LetterCount += letterCount;
        bag.Weight += weight;
        bag.Price += price;
      } else throw new Exception("Price, weight and letter count must be greater than 0");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to add letters to bag - Error: {ex.Message}");
      throw;
    }

  }

}