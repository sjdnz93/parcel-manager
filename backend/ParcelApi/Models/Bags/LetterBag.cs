using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelApi.Models.Bags;


[Table("LetterBag")]
public class LetterBag : Bag
{

  [Required(ErrorMessage = "LetterCount is required")]
  public required int LetterCount { get; set; }

  [Required(ErrorMessage = "Weight is required")]
  [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Weight can only be up to 3 decimal places")]
  public required decimal Weight { get; set; }

  [Required(ErrorMessage = "Price is required")]
  [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Price must have up to 2 decimal places")]
  public required decimal Price { get; set; }

  public LetterBag(string bagId, string bagType) : base(bagId, bagType)
  {
    LetterCount = 0;
    Weight = 0;
    Price = 0;
  }

}

// TODO add validation and ranges for weight and price etc
