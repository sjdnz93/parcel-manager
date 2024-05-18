namespace ParcelApi.RequestClass;

public class LetterBagUpdate
{

  public required string Id { get; set; }

  public required int LetterCount { get; set; }

  public required decimal Weight { get; set; }

  public required decimal Price { get; set; }

  public LetterBagUpdate(string id, int letterCount, decimal weight, decimal price)
  {
    Id = id;
    LetterCount = letterCount;
    Weight = weight;
    Price = price;
  }

}
