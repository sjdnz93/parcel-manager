using System.ComponentModel.DataAnnotations;

namespace ParcelApi.Models.Bags;

public class Bag
{
  [Key]
  public string? BagId { get; set; }

  public string? BagType { get; set; }

  public bool IsFinalised { get; set; }

  [Required(ErrorMessage = "DestinationCountry is required")]
  [RegularExpression("^(EE|LV|FI)$", ErrorMessage = "Country must be 'EE', 'LV', or 'FI'")]
  public required string DestinationCountry { get; set; }

  public int ItemCount { get; set; }

  public decimal Price { get; set; }

  public decimal? Weight { get; set; }

  public Bag()
  {
    ItemCount = 0;
    Price = 0;
    Weight = 0;
    IsFinalised = false;
  }

}

// TODO add field to get total price of bags

// TODO double check all data types and validations