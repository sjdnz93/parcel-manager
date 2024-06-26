﻿using System.ComponentModel.DataAnnotations;

namespace ParcelApi.Models;



public class Parcel
{
  
  [Key]
  [RegularExpression("^[A-Za-z]{2}[0-9]{6}[A-Za-z]{2}$", ErrorMessage = "Parcel ID must follow the format LLNNNNNNLL")]
  public string? ParcelId { get; set; }

  [Required(ErrorMessage = "RecipientName is required")]
  [MaxLength(100, ErrorMessage = "RecipientName must be 100 characters or less")]
  public required string RecipientName { get; set; }
  
  [Required(ErrorMessage = "DestinationCountry is required")]
  [RegularExpression("^(EE|LV|FI)$", ErrorMessage = "Country must be 'EE', 'LV', or 'FI'")]
  public required string DestinationCountry { get; set; }

  [Required(ErrorMessage = "Weight is required")]
  [Range(0.01, int.MaxValue, ErrorMessage = "Weight must be greater than 0kg")]
  [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Weight can only be up to 3 decimal places")]
  public required decimal Weight { get; set; }
  
  [Required(ErrorMessage = "Price is required")]
  [Range(0.01, int.MaxValue, ErrorMessage = "Price must be greater than 0")]
  [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Price must have up to 2 decimal places")]
  public decimal Price { get; set; }

}
