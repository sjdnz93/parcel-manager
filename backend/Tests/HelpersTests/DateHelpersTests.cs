using ParcelApi.Helpers;

namespace Tests.HelpersTests;

[TestClass]
public class DateHelpersTests
{
    [TestMethod]
    public void IsDateInPast_ReturnTrue()
    {
      DateTime pastDate = new DateTime(2022, 1, 1, 12, 30, 0);
      bool result = DateHelpers.IsDateInPast(pastDate);
      Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsDateInPast_ReturnFalse()
    {
      DateTime futureDate = DateTime.Now.AddDays(10);
      bool result = DateHelpers.IsDateInPast(futureDate);
      Assert.IsFalse(result);
    }

}