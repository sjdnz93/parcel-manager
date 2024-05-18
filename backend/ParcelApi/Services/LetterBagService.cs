using Microsoft.EntityFrameworkCore;
using ParcelApi.Data;
using ParcelApi.Helpers;
using ParcelApi.Models;
using ParcelApi.Models.Bags;
using ParcelApi.RequestClass;

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
        bag.ItemCount = 0;
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

  public void AddLettersToBag(LetterBag bag, LetterBagUpdate request)
  {
    try
    {
      if (bag != null && request.LetterCount > 0 && request.Weight > 0 && request.Price > 0)
      {
        if (bag.IsFinalised) throw new Exception("This shipment has already been finalised. You can no longer add letters to bags in this shipment");

        request.Weight = decimal.Parse(request.Weight.ToString("#.###"));
        request.Price = decimal.Parse(request.Price.ToString("#.##"));

        bag.LetterCount += request.LetterCount;
        bag.Weight += request.Weight;
        bag.Price += request.Price;
        bag.ItemCount += request.LetterCount;

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