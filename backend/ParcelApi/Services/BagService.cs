using Microsoft.EntityFrameworkCore;
using ParcelApi.Data;
using ParcelApi.Helpers;
using ParcelApi.Models;
using ParcelApi.Models.Bags;

namespace ParcelApi.Services;

public class BagService
{
  // public List<ParcelBag> ParcelBags { get; }
  // public List<LetterBag> LetterBags { get; }

  protected readonly ParcelManagerContext _context;

  public BagService(ParcelManagerContext context)
  {

    _context = context;
    // ParcelBags = new List<ParcelBag>();

    // LetterBags = new List<LetterBag>();
  }

  public List<ParcelBag> GetAllParcelBags()
  {
    try
    {
      return _context.ParcelBags.AsNoTracking().ToList();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to get parcel bags - Error: {ex.Message}");
      throw;
    }
  } 

  public ParcelBag? GetParcelBagById(string id)
  {
    try
    {
      return _context.ParcelBags.AsNoTracking().FirstOrDefault(b => b.BagId == id);
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to get parcel bag - Error: {ex.Message}");
      throw;
    }
  }

  public List<LetterBag> GetAllLetterBags()
  {
    try
    {
      return _context.LetterBags.AsNoTracking().ToList();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to get letter bags - Error: {ex.Message}");
      throw;
    }
  }

  public LetterBag? GetLetterBagById(string id)
  {
    try
    {
      return _context.LetterBags.AsNoTracking().FirstOrDefault(b => b.BagId == id);
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to get letter bag - Error: {ex.Message}");
      throw;
    }
  }

  public List<Bag> GetAllBags()
  {

    try
    {
      return _context.Bags.AsNoTracking().ToList();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to get bags - Error: {ex.Message}");
      throw;
    }

    // var parcelBags = GetAllParcelBags();
    // var letterBags = GetAllLetterBags();

    // var bags = new List<Bag>();
    // bags.AddRange(parcelBags);
    // bags.AddRange(letterBags);
    // return bags;
  }

}
