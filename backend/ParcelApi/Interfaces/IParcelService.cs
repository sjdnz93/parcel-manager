using ParcelApi.Models;

namespace ParcelApi.Interfaces;

public interface IParcelService
{

  Task<List<Parcel>> GetAll();

  Task<Parcel?> Get(string id);

  Task Add(Parcel parcel);


}
