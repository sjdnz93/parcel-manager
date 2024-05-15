using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelApi.Models.Bags;

[Table("ParcelBag")]
public class ParcelBag : Bag
{
  
  public List<Parcel> Parcels { get; set; }

  public ParcelBag() : base()
  {
    BagType = "Parcel";
    Parcels = new List<Parcel>();
  }
}


