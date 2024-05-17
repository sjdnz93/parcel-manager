using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelApi.Models.Bags;


[Table("LetterBag")]
public class LetterBag : Bag
{

  [Required]
  public int? LetterCount { get; set; }

  public LetterBag() : base()
  {
    BagType = "Letter";
    LetterCount = 0;
  }

}

