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

  public Bag()
  {
    IsFinalised = false;
  }

}

// TODO double check all data types and validations