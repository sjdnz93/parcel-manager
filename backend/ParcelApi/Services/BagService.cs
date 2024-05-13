using ParcelApi.Helpers;
using ParcelApi.Models;
using ParcelApi.Models.Bags;

namespace ParcelApi.Services;

public class BagService
{
  public static List<ParcelBag> ParcelBags { get; }
  public static List<LetterBag> LetterBags { get; }

  static BagService()
  {
    ParcelBags = new List<ParcelBag>
    {
      new ParcelBag("AAAAAAAAAAAAAAA", "Parcel")
      {
        Parcels = new List<Parcel>()
      },
      new ParcelBag("BBBBBBBBBBBBBBB", "Parcel")
      {
        Parcels = new List<Parcel>()
      },
      new ParcelBag("CCCCCCCCCCCCCCC", "Parcel")
      {
        Parcels = new List<Parcel>()
      }
    };

    LetterBags = new List<LetterBag>
    {
      new LetterBag("DDDDDDDDDDDDDDD", "Letter")
      {
        LetterCount = 0,
        Weight = 0,
        Price = 0
      }
    };
  }

  public static List<ParcelBag> GetAllParcelBags() => ParcelBags;

  public static ParcelBag? GetParcelBagById(string id) => ParcelBags.FirstOrDefault(b => b.BagId == id);

  public static List<LetterBag> GetAllLetterBags() => LetterBags;

  public static LetterBag? GetLetterBagById(string id) => LetterBags.FirstOrDefault(b => b.BagId == id);


  public static List<Bag> GetAllBags()
  {
    var parcelBags = GetAllParcelBags();
    var letterBags = GetAllLetterBags();

    var bags = new List<Bag>();
    bags.AddRange(parcelBags);
    bags.AddRange(letterBags);
    return bags;
  }

}

// public static Bag? Get(string id) => Bags.FirstOrDefault(b => b.BagId == id);



// public static void Delete(string id)
// {
//   var bag = Get(id);
//   if (bag == null) throw new Exception("Bag with this ID does not exist in system");
//   Bags.Remove(bag);
// }
