using ParcelApi.Helpers;
using ParcelApi.Models;

namespace ParcelApi.Services;

public class BagService
{
  public static List<ParcelBag> ParcelBags { get; }
  public static List<LetterBag> LetterBags { get; }

  static BagService()
  {
    ParcelBags = new List<ParcelBag>
    {
      new ParcelBag("AAAAAAAAAAAAAAA")
      {
        Parcels = new List<Parcel>()
      },
      new ParcelBag("BBBBBBBBBBBBBBB")
      {
        Parcels = new List<Parcel>()
      },
      new ParcelBag("CCCCCCCCCCCCCC")
      {
        Parcels = new List<Parcel>()
      }
    };

    LetterBags = new List<LetterBag>
    {
      new LetterBag("DDDDDDDDDDDDDDD")
      {
        LetterCount = 0,
        Weight = 0,
        Price = 0
      }
    };
  }

  public static List<ParcelBag> GetAllParcelBags() => ParcelBags;

  public static List<LetterBag> GetAllLetterBags() => LetterBags;

  public static List<Bag> GetAllBags()
  {
    var parcelBags = GetAllParcelBags().Cast<Bag>();
    var letterBags = GetAllLetterBags().Cast<Bag>();

    return parcelBags.Concat(letterBags).ToList();
  }

  // public static Bag? Get(string id) => Bags.FirstOrDefault(b => b.BagId == id);

  // public static void Add(Bag bag)
  // {
  //   var bagList = GetAll();
  //   while (true)
  //   {
  //     bag.BagId = IdNumberHelpers.GenerateBagId();
  //     if (!bagList.Any(x => x.BagId == bag.BagId))
  //     {
  //       Bags.Add(bag);
  //       break;
  //     }
  //   }
  // }

  // public static void Delete(string id)
  // {
  //   var bag = Get(id);
  //   if (bag == null) throw new Exception("Bag with this ID does not exist in system");
  //   Bags.Remove(bag);
  // }


}
