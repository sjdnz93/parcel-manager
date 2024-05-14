using System.ComponentModel.DataAnnotations;

namespace ParcelApi.Models.Bags;

public class Bag
{
  [Key]
  [MaxLength(15, ErrorMessage = "BagId must be 15 characters or less")]
  public string? BagId { get; set; }

  public string? BagType { get; set; }

  public required bool IsFinalised { get; set; }

  public Bag(string bagId, string bagType) 
  {
    BagId = bagId;
    BagType = bagType;
    IsFinalised = false;
  }
}

// TODO double check all data types and validations