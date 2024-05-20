using Microsoft.EntityFrameworkCore;
using ParcelApi.Data;
using ParcelApi.Helpers;
using ParcelApi.Interfaces;
using ParcelApi.Models;

namespace ParcelApi.Services;

public class ParcelService : IParcelService
{
  private readonly ParcelManagerContext _context;

  public ParcelService(ParcelManagerContext context)
  {
    _context = context;
  }

  public async Task<List<Parcel>> GetAll()
  {
    try
    {
      return await _context.Parcels.ToListAsync();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to get parcels - Error: {ex.Message}");
      throw;
    }
  }

  public async Task<Parcel?> Get(string id)
  {
    try
    {
      return await _context.Parcels.FirstOrDefaultAsync(p => p.ParcelId == id);
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to get parcel - Error: {ex.Message}");
      throw;
    }
  }

  public async Task Add(Parcel parcel)
  {
    try
    {
      var parcelList = await GetAll();
      while (true)
      {
        parcel.ParcelId = IdNumberHelpers.GenerateParcelId();
        if (!parcelList.Any(x => x.ParcelId == parcel.ParcelId))
        {
          await _context.Parcels.AddAsync(parcel);
          await _context.SaveChangesAsync();
          break;
        }
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to add parcel - Error: {ex.Message}");
      throw;
    }

  }
}

