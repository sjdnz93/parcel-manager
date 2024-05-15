using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelApi.Models.Bags;


[Table("LetterBag")]
public class LetterBag : Bag
{

  [Required]
  public int? LetterCount { get; set; }

  [Required]
  public decimal? Weight { get; set; }

  [Required]
  public decimal? Price { get; set; }

  public LetterBag() : base()
  {
    BagType = "Letter";
    LetterCount = 0;
    Weight = 0;
    Price = 0;
  }

}

