using ParcelApi.Helpers;
using ParcelApi.Models;

namespace ParcelApi.Services;

public static class ParcelService
{
  public static List<Parcel> Parcels { get; }

  static ParcelService()
  {
    Parcels = new List<Parcel>();
  }

  public static List<Parcel> GetAll() => Parcels;

  public static Parcel? Get(string id) => Parcels.FirstOrDefault(p => p.ParcelId == id);

  public static void Add(Parcel parcel)
  {
    var parcelList = GetAll();
    while (true)
    {
      parcel.ParcelId = IdNumberHelpers.GenerateParcelId();
      if (!parcelList.Any(x => x.ParcelId == parcel.ParcelId))
      {
        Parcels.Add(parcel);
        break;
      }
    }
  }

  public static void Delete(string id)
  {
    var parcel = Get(id);
    if (parcel == null) throw new Exception("Parcel with this ID does not exist in system");
    Parcels.Remove(parcel);
  }

}

// TODO make sure service methods are case insensitive, particularly for retrieval IDs etc. This should be handled by helper function, however
// TODO decide if I need PUT method for parcel service
// TODO update service methods to work with actual DB rather than in-memory list