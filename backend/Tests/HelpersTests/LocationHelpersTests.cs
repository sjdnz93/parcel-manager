using ParcelApi.Helpers;
using ParcelApi.Models;

namespace Tests.HelpersTests;
[TestClass]
public class LocationHelpersTests
{

  [TestMethod]
  public void IsFlightInternal_ReturnsTrue()
  {
    var destinationCountry = "EE";
    var originAirport = AirportCodes.TLL;

    var result = LocationHelpers.IsFlightInternal(destinationCountry, originAirport);
    Assert.IsTrue(result);
  }

  [TestMethod]
  public void IsFlightInternal_ReturnsFalse()
  {
    var destinationCountry = "EE";
    var originAirport1 = AirportCodes.HEL;
    var originAirport2 = AirportCodes.RIX;

    var result1 = LocationHelpers.IsFlightInternal(destinationCountry, originAirport1);
    Assert.IsFalse(result1);

    var result2 = LocationHelpers.IsFlightInternal(destinationCountry, originAirport2);
    Assert.IsFalse(result2);

  }


  [TestMethod]
  public void DoDestinationsMatch_ReturnsTrue()
  {
    var destination1 = "EE";
    var destination2 = "EE";

    var result = LocationHelpers.DoDestinationsMatch(destination1, destination2);
    Assert.IsTrue(result);

  }

  [TestMethod]
  public void DoDestinationsMatch_ReturnsFalse()
  {
    var destination1 = "EE";
    var destination2 = "LV";

    var result = LocationHelpers.DoDestinationsMatch(destination1, destination2);
    Assert.IsFalse(result);
  }

}
