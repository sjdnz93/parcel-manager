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

  public static bool DoDestinationsMatch(string destination1, string destination2)
  {
    return destination1 == destination2 ? true : false;
  }
  
}
