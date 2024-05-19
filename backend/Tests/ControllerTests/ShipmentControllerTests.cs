//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ParcelApi.Controllers;
using ParcelApi.Models;
using ParcelApi.Services;
using Tests.MockData;
//using System.Collections.Generic;

namespace ParcelApi.Tests
{
  [TestClass]
  public class ShipmentControllerTests
  {
    [TestMethod]
    public void GetAll_ReturnsListOfShipments_And_HttpStatusCode_200()
    {
      // Arrange
      var mockShipmentService = new Mock<ShipmentService>();
      var shipments = MockData.GetMockData();

      mockShipmentService.Setup(s => s.GetAll()).Returns(shipments);

      var controller = new ShipmentController(mockShipmentService.Object);

      // Act
      var result = controller.GetAll();

      // Assert
      Assert.IsInstanceOfType(result, typeof(ActionResult<List<Shipment>>));
      var actionResult = result;
      Assert.IsNotNull(actionResult);

      var statusCode = actionResult?.Result?.GetType()?.GetProperty("StatusCode")?.GetValue(actionResult.Result);

      Console.WriteLine("Status Code: " + statusCode);

      // Test HTTP status code
      Assert.AreEqual(200, statusCode);
    }


    [TestMethod]
    public void GetAll_ThrowsException_WhenServiceThrowsException()
    {
      // Arrange
      var mockShipmentService = new Mock<ShipmentService>();
      mockShipmentService.Setup(s => s.GetAll()).Throws(new Exception("Test exception"));

      var controller = new ShipmentController(mockShipmentService.Object);

      // Act
      var result = controller.GetAll();

      // Assert
      Assert.IsInstanceOfType(result.Result, typeof(ObjectResult));
      var objectResult = result.Result as ObjectResult;
      Assert.AreEqual(400, objectResult!.StatusCode);
      var badRequestResult = objectResult as BadRequestObjectResult;
      Assert.AreEqual("Failed to get shipments - Error: Test exception", badRequestResult!.Value);

    }

    [TestMethod]
    public void Get_ReturnsOkObjectResultWithCorrectShipment()
    {
      // Arrange
      var mockShipmentService = new Mock<ShipmentService>();
      var shipments = MockData.GetMockData();

      var shipment = shipments[0];

      var mockShipmentId = shipment.ShipmentId!;

      var testShipmentId = "AA1-AAAAA1";

      mockShipmentService.Setup(s => s.Get(mockShipmentId)).Returns(shipment);

      var controller = new ShipmentController(mockShipmentService.Object);

      // Act
      var result = controller.Get(testShipmentId);

      // Assert
      Assert.IsNotNull(result);
      var objectResult = result.Result as ObjectResult;
      Assert.IsNotNull(objectResult);
      Assert.AreEqual(200, objectResult.StatusCode);
      Assert.AreEqual(testShipmentId, mockShipmentId);
      Assert.AreEqual(shipment, objectResult.Value);
    }

    [TestMethod]
    public void Get_ReturnsNotFoundObjectResultIfShipmentNotFound()
    {
      // Arrange
      var mockShipmentService = new Mock<ShipmentService>();
      var shipments = MockData.GetMockData();

      var shipment = shipments[0];

      var mockShipmentId = shipment.ShipmentId!;

      var testShipmentId = "BB1-BBBBB1";

      mockShipmentService.Setup(s => s.Get(mockShipmentId)).Returns(shipment);

      var controller = new ShipmentController(mockShipmentService.Object);

      // Act
      var result = controller.Get(testShipmentId);

      // Assert
      Assert.IsNotNull(result);
      var objectResult = result.Result as ObjectResult;
      Assert.IsNotNull(objectResult);
      Assert.AreEqual(404, objectResult.StatusCode);
      Assert.AreNotEqual(testShipmentId, mockShipmentId);
      Assert.AreNotEqual(shipment, objectResult.Value);
    }




  }
}

