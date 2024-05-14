using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelApi.Models.Bags;

[Table("ParcelBag")]
public class ParcelBag : Bag
{
  
  public List<Parcel> Parcels { get; set; }

  public ParcelBag(string bagId, string bagType) : base(bagId, bagType)
  {
    Parcels = new List<Parcel>();
  }
}


