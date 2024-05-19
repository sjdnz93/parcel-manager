using Moq;
using Moq.Language;
using ParcelApi.Models;
using ParcelApi.Models.Bags;
using ParcelApi.Services;
using Tests.DataMock;


namespace Tests.ServiceTests;

[TestClass]
public class ShipmentServiceTests
{

  [TestMethod]
  public void GetAll_ReturnsAllShipments()
  {

    // Arrange
    var mockShipmentService = new Mock<ShipmentService>();

    var shipments = MockDb.GetMockData();

    mockShipmentService.Setup(s => s.GetAll()).Returns(shipments);

    // Act

    var result = mockShipmentService.Object.GetAll();

    // Assert
    Assert.IsNotNull(result);
    Assert.AreEqual(shipments, result);

  }

  [TestMethod]
  public void Get_ReturnsSingleShipment()
  {

    var mockShipmentService = new Mock<ShipmentService>();

    var shipment = MockDb.GetMockData()[0];

    var shipmentId = shipment.ShipmentId!;

    mockShipmentService.Setup(s => s.Get(shipmentId)).Returns(shipment);

    var result = mockShipmentService.Object.Get(shipmentId);

    Assert.IsNotNull(result);
    Assert.AreEqual(shipment, result);
  }

  // [TestMethod]
  // public void AddShipment_AddsShipment()
  // {

  //   var mockShipmentService = new Mock<ShipmentService>();
  //   var shipments = MockDb.GetMockData();

  //   var originalCount = shipments.Count;

  //   var newShipment = new Shipment
  //   {
  //     ShipmentId = "BBB-111111",
  //     FlightDate = DateTime.Now.AddDays(10),
  //     FlightNumber = "AA0994",
  //     DestinationCountry = "LV",
  //     Airport = AirportCodes.TLL,
  //     Bags = new List<Bag>(),
  //     IsFinalised = false
  //   };

  //   mockShipmentService.Setup(s => s.AddShipment(newShipment));

  //   mockShipmentService.Object.AddShipment(newShipment);

  //   var updatedShipments = MockDb.GetMockData();

  //   var createdShipment = mockShipmentService.Object.Get(newShipment.ShipmentId);
  //   var newCount = updatedShipments.Count;

  //   Assert.IsNotNull(createdShipment);
  //   Assert.AreEqual(newCount, originalCount + 1);





  // }

}
