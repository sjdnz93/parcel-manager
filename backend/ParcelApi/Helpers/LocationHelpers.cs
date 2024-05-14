using ParcelApi.Models;

namespace ParcelApi.Helpers;

public static class LocationHelpers
{

  public static bool IsFlightInternal(string destinationCountry, AirportCodes originAirport)
  {
    if (destinationCountry == "EE" && originAirport == AirportCodes.TLL)
    {
      return true;
    }
    else if (destinationCountry == "LV" && originAirport == AirportCodes.RIX)
    {
      return true;
    }
    else if (destinationCountry == "FI" && originAirport == AirportCodes.HEL)
    {
      return true;
    }
    else return false;
  }

  public static bool DoesShipmentDestinationMatchBagDestination(string shipmentDestination, string bagDestination)
  {
    return shipmentDestination == bagDestination ? true : false;
  }

  public static bool DoesBagDestinationMatchParcelDestination(string bagDestination, string parcelDestination)
  {
    return parcelDestination == bagDestination ? true : false;
  }

}
