using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelApi.Models;

public class Bag
{
  [Key]
  [MaxLength(15, ErrorMessage = "BagId must be 15 characters or less")]
  public required string BagId { get; set; }

  public Bag(string bagId) 
  {
    BagId = bagId;
  }
}

[Table("ParcelBag")]
public class ParcelBag : Bag
{
  [Required]
  public List<Parcel>? Parcels { get; set; }

  public ParcelBag(string bagId) : base(bagId)
  {
    Parcels = new List<Parcel>();
  }
}

[Table("LetterBag")]
public class LetterBag : Bag
{
  [Required(ErrorMessage = "LetterCount is required")]
  public int LetterCount { get; set; }

  [Required(ErrorMessage = "Weight is required")]
  [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Weight can only be up to 3 decimal places")]
  public decimal Weight { get; set; }

  [Required(ErrorMessage = "Price is required")]
  [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Price must have up to 2 decimal places")]
  public decimal Price { get; set; }

  public LetterBag(string bagId) : base(bagId) 
  {
    LetterCount = 0;
    Weight = 0;
    Price = 0;
  }

}

// TODO double check all data types and validations