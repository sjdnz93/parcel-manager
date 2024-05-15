using Microsoft.EntityFrameworkCore;
using ParcelApi.Data;
using ParcelApi.Helpers;
using ParcelApi.Models;
using ParcelApi.Models.Bags;

namespace ParcelApi.Services;

public class LetterBagService : BagService
{
  public LetterBagService(ParcelManagerContext context) : base(context)
  {
  }

  public void AddLetterBag(LetterBag bag)
  {

    try
    {
      var bagListFromDb = _context.Bags.ToList();

      while (true)
      {
        bag.BagId = IdNumberHelpers.GenerateBagId();
        bag.BagType = "Letter";
        bag.IsFinalised = false;
        bag.Weight = 0;
        bag.Price = 0;
        bag.LetterCount = 0;
        if (!bagListFromDb.Any(x => x.BagId == bag.BagId))
        {
          //maybe i need to also add to Bags table?
          _context.LetterBags.Add(bag);
          _context.SaveChanges();
          break;
        }
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to add letter bag - Error: {ex.Message}");
      throw;
    }

  }

  public void AddLettersToBag(LetterBag bag, int letterCount, decimal weight, decimal price)
  {
    try
    {
      if (bag != null && letterCount > 0 && weight > 0 && price > 0)
      {
        if (bag.IsFinalised) throw new Exception("This shipment has already been finalised. You can no longer add letters to bags in this shipment");

        weight = decimal.Parse(weight.ToString("#.###"));
        price = decimal.Parse(price.ToString("#.##"));

        bag.LetterCount += letterCount;
        bag.Weight += weight;
        bag.Price += price;

        _context.SaveChanges();
        
      }
      else throw new Exception("Price, weight and letter count must be greater than 0");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to add letters to bag - Error: {ex.Message}");
      throw;
    }

  }

}