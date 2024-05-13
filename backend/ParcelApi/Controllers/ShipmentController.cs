using Microsoft.AspNetCore.Mvc;
using ParcelApi.Models;
using ParcelApi.Services;

namespace ParcelApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ShipmentController : ControllerBase
{
  public ShipmentController()
  {
  }

  [HttpGet]
  public ActionResult<List<Shipment>> GetAll() => ShipmentService.GetAll();

  [HttpGet("{id}")]
  public ActionResult<Shipment> Get(string id)
  {
    var shipment = ShipmentService.Get(id);
    if (shipment == null)
    {
      return NotFound();
    }
    return shipment;
  }

  [HttpPost]
  public IActionResult Create(Shipment shipment)
  {
    ShipmentService.Add(shipment);
    return CreatedAtAction(nameof(Get), new { id = shipment.ShipmentId }, shipment);
  }
}
