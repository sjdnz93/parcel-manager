using Microsoft.Extensions.Options;
using System;
using System.Text;

namespace ParcelApi.Helpers;

public static class IdNumberHelpers
{

  public static string GenerateParcelId()
  {
    var letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    var numbers = "1234567890";
    var idLength = 10;

    StringBuilder sb = new StringBuilder();

    for (int i = 0; i < idLength; i++)
    {
      if (i < 2)
      {
        sb.Append(letters[new Random().Next(0, letters.Length)]);
      }

      if (i >= 2 && i < 8)
      {
        sb.Append(numbers[new Random().Next(0, numbers.Length)]);
      }

      if (i >= 8)
      {
        sb.Append(letters[new Random().Next(0, letters.Length)]);
      }
    }

    Console.WriteLine($"Parcel ID: {sb.ToString()}");

    return sb.ToString();
  }

  public static string GenerateShipmentId()
  {
    var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
    var idLength = 10;

    StringBuilder sb = new StringBuilder();

    for (int i = 0; i < idLength; i++)
    {
      if (i < 3)
      {
        sb.Append(characters[new Random().Next(0, characters.Length)]);
      }

      if (i == 3)
      {
        sb.Append('-');
      }

      if (i >= 4)
      {
        sb.Append(characters[new Random().Next(0, characters.Length)]);
      }

    }

    Console.WriteLine($"Shipment ID: {sb.ToString()}");

    return sb.ToString();
  }

  public static string GenerateBagId()
  {
    var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
    var idLength = 15;

    StringBuilder sb = new StringBuilder();

    for (int i = 0; i < idLength; i++)
    {
      sb.Append(characters[new Random().Next(0, characters.Length)]);
    }

    Console.WriteLine($"Bag ID: {sb.ToString()}");

    return sb.ToString();
  }

}
