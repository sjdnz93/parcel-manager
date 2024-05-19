using ParcelApi.Models;
using ParcelApi.Models.Bags;

namespace ParcelApi.Interfaces;

public interface IParcelBagService : IBagService
{
  Task AddParcelBag(ParcelBag bag);
  Task AddParcelToBag(string id, Parcel parcel);

}
