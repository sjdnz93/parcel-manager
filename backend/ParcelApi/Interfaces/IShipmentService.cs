using ParcelApi.Models;
using ParcelApi.Models.Bags;

namespace ParcelApi.Interfaces;

public interface IShipmentService
{
    Task<List<Shipment>> GetAll();
    Task<Shipment?> Get(string id);
    Task AddShipment(Shipment shipment);
    Task AddParcelBagToShipment(string id, ParcelBag bag);
    Task AddLetterBagToShipment(Shipment shipment, LetterBag bag);
    Task FinaliseShipment(Shipment shipment);

}
