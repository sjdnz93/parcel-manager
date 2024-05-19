using Microsoft.AspNetCore.Mvc;
using Moq;
using ParcelApi.Controllers;
using ParcelApi.Models;
using ParcelApi.Models.Bags;
using ParcelApi.Services;
using Tests.DataMock;

namespace Tests.ControllerTests;

[TestClass]
public class ShipmentControllerTests
{
  [TestMethod]
  public void GetAll_ReturnsOkObjectResult()
  {
    // Arrange
    var mockShipmentService = new Mock<ShipmentService>();
    var shipments = MockDb.GetMockData();

    mockShipmentService.Setup(s => s.GetAll()).Returns(shipments);

    var controller = new ShipmentController(mockShipmentService.Object);

    // Act
    var result = controller.GetAll();

    // Assert
    var okResult = result.Result as OkObjectResult;
    Assert.IsNotNull(okResult);
    Assert.AreEqual(200, okResult.StatusCode);

  }


  [TestMethod]
  public void GetAll_ReturnsBadRequestObjectResult_OnFailure()
  {
    // Arrange
    var mockShipmentService = new Mock<ShipmentService>();
    mockShipmentService.Setup(s => s.GetAll()).Throws(new Exception("Test exception"));

    var controller = new ShipmentController(mockShipmentService.Object);

    // Act
    var result = controller.GetAll();

    // Assert
    Assert.IsNotNull(result);
    var badRequestResult = result.Result as BadRequestObjectResult;
    Assert.IsNotNull(badRequestResult);
    Assert.AreEqual(400, badRequestResult.StatusCode);

  }

  [TestMethod]
  public void Get_ReturnsOkObjectResult()
  {
    // Arrange
    var mockShipmentService = new Mock<ShipmentService>();
    var shipments = MockDb.GetMockData();

    var shipment = shipments[0];

    var mockShipmentId = shipment.ShipmentId!;

    var testShipmentId = "AA1-AAAAA1";

    mockShipmentService.Setup(s => s.Get(mockShipmentId)).Returns(shipment);

    var controller = new ShipmentController(mockShipmentService.Object);

    // Act
    var result = controller.Get(testShipmentId);

    // Assert
    Assert.IsNotNull(result);
    var okResult = result.Result as OkObjectResult;
    Assert.AreEqual(200, okResult!.StatusCode);
    Assert.AreEqual(testShipmentId, mockShipmentId);
    Assert.AreEqual(shipment, okResult.Value);
  }

  [TestMethod]
  public void Get_ReturnsNotFoundObjectResultIfShipmentNotFound()
  {
    // Arrange
    var mockShipmentService = new Mock<ShipmentService>();
    var shipments = MockDb.GetMockData();

    var shipment = shipments[0];

    var mockShipmentId = shipment.ShipmentId!;

    var testShipmentId = "BB1-BBBBB1";

    mockShipmentService.Setup(s => s.Get(mockShipmentId)).Returns(shipment);

    var controller = new ShipmentController(mockShipmentService.Object);

    // Act
    var result = controller.Get(testShipmentId);

    // Assert
    Assert.IsNotNull(result);
    var notFoundResult = result.Result as NotFoundObjectResult;
    Assert.IsNotNull(notFoundResult);
    Assert.AreEqual(404, notFoundResult.StatusCode);
  }

  [TestMethod]
  public void CreateShipment_ReturnsCreatedAtAction()
  {
    // Arrange
    var mockShipmentService = new Mock<ShipmentService>();

    var controller = new ShipmentController(mockShipmentService.Object);

    var newShipment = new Shipment
    {
      ShipmentId = "AA1-AAAAA1",
      FlightDate = DateTime.Now,
      FlightNumber = "AA0994",
      DestinationCountry = "LV",
      Airport = AirportCodes.TLL,
      Bags = new List<Bag>(),
      IsFinalised = false
    };

    // Act
    var result = controller.CreateShipment(newShipment);

    // Assert
    Assert.IsNotNull(result);

    var createdAtActionResult = result as CreatedAtActionResult;
    Assert.IsNotNull(createdAtActionResult);
    Assert.AreEqual(201, createdAtActionResult!.StatusCode);
    Assert.AreEqual(nameof(controller.Get), createdAtActionResult.ActionName);
    Assert.AreEqual(newShipment, createdAtActionResult!.Value);
  }

}


