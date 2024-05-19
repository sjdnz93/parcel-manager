using System.Text.RegularExpressions;
using ParcelApi.Helpers;

namespace Tests.HelpersTests;

[TestClass]
public class IdNumberHelpersTests
{

  [TestMethod]
  public void GenerateParcelId_ReturnsIdWithCorrectFormat()
  {

    var regex = new Regex(@"^[A-Za-z]{2}[0-9]{6}[A-Za-z]{2}$");

    for (int i = 0; i < 100000; i++)
    {
      var id = IdNumberHelpers.GenerateParcelId();
      Assert.IsTrue(regex.IsMatch(id), $"Generated ID {id} does not match the format");
    }
  }

  [TestMethod]
  public void GenerateShipmentId_ReturnsIdWithCorrectFormat()
  {
    var regex = new Regex(@"^[A-Za-z0-9]{3}-[A-Za-z0-9]{6}$");

    for (int i = 0; i < 100000; i++)
    {
      var id = IdNumberHelpers.GenerateShipmentId();

      Assert.IsTrue(regex.IsMatch(id), $"Generated ID {id} does not match the format");
    }
  }

  [TestMethod]
  public void GenerateBagId_ReturnsIdWithCorrectFormat()
  {
    var regex = new Regex(@"^[A-Za-z0-9]{15}$");

    for (int i = 0; i < 100000; i++)
    {
      var id = IdNumberHelpers.GenerateBagId();
      Assert.IsTrue(regex.IsMatch(id), $"Generated ID {id} does not match the format");
    }
  }

}
