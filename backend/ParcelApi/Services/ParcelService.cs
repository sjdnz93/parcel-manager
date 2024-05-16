using Microsoft.EntityFrameworkCore;
using ParcelApi.Data;
using ParcelApi.Helpers;
using ParcelApi.Models;

namespace ParcelApi.Services;

public class ParcelService
{
  private readonly ParcelManagerContext _context;

  public ParcelService(ParcelManagerContext context)
  {
    _context = context;
  }

  public List<Parcel> GetAll()
  {
    try
    {
      return _context.Parcels.ToList();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to get parcels - Error: {ex.Message}");
      throw;
    }
  }

  public Parcel? Get(string id)
  {
    try
    {
      return _context.Parcels.FirstOrDefault(p => p.ParcelId == id);
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to get parcel - Error: {ex.Message}");
      throw;
    }
  }

  public void Add(Parcel parcel)
  {
    try
    {
      var parcelList = GetAll();
      while (true)
      {
        parcel.ParcelId = IdNumberHelpers.GenerateParcelId();
        if (!parcelList.Any(x => x.ParcelId == parcel.ParcelId))
        {
          _context.Parcels.Add(parcel);
          _context.SaveChanges();
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

// TODO add PUT and DELETE methods