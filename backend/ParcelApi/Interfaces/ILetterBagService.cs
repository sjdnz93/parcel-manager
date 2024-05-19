using ParcelApi.Models.Bags;
using ParcelApi.RequestClass;

namespace ParcelApi.Interfaces;

public interface ILetterBagService : IBagService
{

  Task AddLetterBag(LetterBag bag);
  Task AddLettersToBag(LetterBag bag, LetterBagUpdate request);

}
