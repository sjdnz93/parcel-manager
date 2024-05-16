using Microsoft.EntityFrameworkCore;
using ParcelApi.Data;
using ParcelApi.Helpers;
using ParcelApi.Models;
using ParcelApi.Models.Bags;

namespace ParcelApi.Services;

public class BagService
{

  protected readonly ParcelManagerContext _context;

  public BagService(ParcelManagerContext context)
  {

    _context = context;
  }

  public List<ParcelBag> GetAllParcelBags()
  {
    try
    {
      return _context.ParcelBags.Include(p => p.Parcels).ToList();
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
      return _context.ParcelBags.Include(p => p.Parcels).FirstOrDefault(b => b.BagId == id);
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
      return _context.LetterBags.ToList();
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
      return _context.LetterBags.FirstOrDefault(b => b.BagId == id);
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
      return _context.Bags.ToList();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to get bags - Error: {ex.Message}");
      throw;
    }
  }

}

// TODO add DELETE methods
