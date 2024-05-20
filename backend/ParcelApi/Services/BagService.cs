using Microsoft.EntityFrameworkCore;
using ParcelApi.Data;
using ParcelApi.Helpers;
using ParcelApi.Models;
using ParcelApi.Models.Bags;

namespace ParcelApi.Services;

public class BagService : IBagService
{

  protected readonly ParcelManagerContext _context;

  public BagService(ParcelManagerContext context)
  {

    _context = context;
  }

  public async Task<List<ParcelBag>> GetAllParcelBags()
  {
    try
    {
      return await _context.ParcelBags.Include(p => p.Parcels).ToListAsync();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to get parcel bags - Error: {ex.Message}");
      throw;
    }
  }

  public async Task<ParcelBag?> GetParcelBagById(string id)
  {
    try
    {
      return await _context.ParcelBags.Include(p => p.Parcels).FirstOrDefaultAsync(b => b.BagId == id);
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to get parcel bag - Error: {ex.Message}");
      throw;
    }
  }

  public async Task<List<LetterBag>> GetAllLetterBags()
  {
    try
    {
      return await _context.LetterBags.ToListAsync();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to get letter bags - Error: {ex.Message}");
      throw;
    }
  }

  public async Task<LetterBag?> GetLetterBagById(string id)
  {
    try
    {
      return await _context.LetterBags.FirstOrDefaultAsync(b => b.BagId == id);
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to get letter bag - Error: {ex.Message}");
      throw;
    }
  }

  public async Task<List<Bag>> GetAllBags()
  {

    try
    {
      return await _context.Bags.ToListAsync();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to get bags - Error: {ex.Message}");
      throw;
    }
  }

}
