using Moq;
using Moq.Language.Flow;
using ParcelApi.Interfaces;
using ParcelApi.Models;
using ParcelApi.Models.Bags;
using ParcelApi.Services;
using Tests.DataMock;
using ParcelApi.Data;
using Microsoft.EntityFrameworkCore;

using ParcelApi.Helpers;


namespace Tests.ServiceTests;

[TestClass]
public class ShipmentServiceTests
{

  [TestMethod]
  public async Task GetAll_ReturnsAllShipments()
  {

    // Arrange
    var mockShipmentService = new Mock<IShipmentService>();

    var shipments = MockDb.GetMockData();

    mockShipmentService.Setup(s => s.GetAll()).Returns(Task.FromResult(shipments));

    // Act

    var result = await mockShipmentService.Object.GetAll();

    // Assert
    Assert.IsNotNull(result);
    Assert.AreEqual(shipments, result);

  }

  [TestMethod]
  public async Task Get_ReturnsSingleShipment()
  {

    var mockShipmentService = new Mock<IShipmentService>();

    var shipment = MockDb.GetMockData()[0];

    var shipmentId = shipment.ShipmentId!;

    mockShipmentService.Setup(s => s.Get(shipmentId)).Returns(Task.FromResult<Shipment?>(shipment));

    var result = await mockShipmentService.Object.Get(shipmentId);

    Assert.IsNotNull(result);
    Assert.AreEqual(shipment, result);
  }



  // [TestMethod]
  // public async Task AddShipment_AddsShipment()
  // {
  //   // Arrange
  //   var options = new DbContextOptionsBuilder<ParcelManagerContext>()
  //       .UseInMemoryDatabase(databaseName: "TestDatabase")
  //       .Options;

  //   var mockContext = new Mock<ParcelManagerContext>(options);
  //   var shipmentService = new ShipmentService(mockContext.Object);

  //   Shipment newShipment = new Shipment
  //   {
  //     ShipmentId = "BBB-111111",
  //     DestinationCountry = "EE",
  //     FlightDate = DateTime.Now.AddDays(10),
  //     Airport = AirportCodes.TLL,
  //     Bags = new List<Bag>(),
  //     IsFinalised = false,
  //     FlightNumber = "BB1111"
  //   };

  //   // Act
  //   await shipmentService.AddShipment(newShipment);

  //   // Assert
  //   Assert.IsNotNull(newShipment.ShipmentId);
  //   Assert.IsTrue(newShipment.Bags.Count == 0);
  //   Assert.IsFalse(newShipment.IsFinalised);
  //   Assert.IsFalse(string.IsNullOrEmpty(newShipment.FlightNumber));

  // }

}
