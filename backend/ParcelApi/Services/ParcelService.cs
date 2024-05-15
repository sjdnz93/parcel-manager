using Microsoft.EntityFrameworkCore;
using ParcelApi.Data;
using ParcelApi.Helpers;
using ParcelApi.Models;

namespace ParcelApi.Services;

public class ParcelService
{
  //public  List<Parcel> Parcels { get; }

  private readonly ParcelManagerContext _context;

  public ParcelService(ParcelManagerContext context)
  {
    _context = context;
    //Parcels = new List<Parcel>();
  }

  public List<Parcel> GetAll() // => Parcels;
  {
    try
    {
      return _context.Parcels.AsNoTracking().ToList();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to get parcels - Error: {ex.Message}");
      throw;
    }
  }

  public Parcel? Get(string id) // => Parcels.FirstOrDefault(p => p.ParcelId == id);
  {
    try
    {
      return _context.Parcels.AsNoTracking().FirstOrDefault(p => p.ParcelId == id);
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
          //Parcels.Add(parcel);
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

  // public void Delete(string id)
  // {
  //   var parcel = Get(id);
  //   if (parcel == null) throw new Exception("Parcel with this ID does not exist in system");
  //   Parcels.Remove(parcel);
  // }

}

// TODO make sure service methods are case insensitive, particularly for retrieval IDs etc. This should be handled by helper function, however
// TODO decide if I need PUT method for parcel service
// TODO update service methods to work with actual DB rather than in-memory list