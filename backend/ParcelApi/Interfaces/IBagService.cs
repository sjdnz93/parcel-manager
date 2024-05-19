using ParcelApi.Models.Bags;

namespace ParcelApi;

public interface IBagService
{
    Task<List<Bag>> GetAllBags();
    Task<List<ParcelBag>> GetAllParcelBags();

    Task<ParcelBag?> GetParcelBagById(string id);

    Task<List<LetterBag>> GetAllLetterBags();
    Task<LetterBag?> GetLetterBagById(string id);
}