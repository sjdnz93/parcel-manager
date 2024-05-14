using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using ParcelApi.Models;
using ParcelApi.Models.Bags;
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
  public IActionResult CreateShipment(Shipment shipment)
  {
    ShipmentService.Add(shipment);
    return CreatedAtAction(nameof(Get), new { id = shipment.ShipmentId }, shipment);
  }

  [HttpPut("{id}/add-parcel-bag")]
  public IActionResult Update(string id, ParcelBag bag)
  {
    var shipment = ShipmentService.Get(id);
    if (shipment == null)
    {
      return NotFound();
    }

    if (shipment.ShipmentId != id)
    {
      return BadRequest();
    }

    ShipmentService.AddParcelBagToShipment(shipment, bag);

    return Ok();

  }

  [HttpPut("{id}/add-letter-bag")]
  public IActionResult UpdateShipment(string id, LetterBag bag)
  {
    var shipment = ShipmentService.Get(id);
    if (shipment == null)
    {
      return NotFound();
    }

    if (shipment.ShipmentId != id)
    {
      return BadRequest();
    }

    ShipmentService.AddLetterBagToShipment(shipment, bag);

    return Ok();

  }

  [HttpPut("{id}/finalise-shipment")]
  public IActionResult FinaliseShipment(string id)
  {
    var shipment = ShipmentService.Get(id);
    if (shipment == null)
    {
      return NotFound();
    }

    if (shipment.ShipmentId != id)
    {
      return BadRequest();
    }

    ShipmentService.FinaliseShipment(shipment);

    return Ok();

  }


}
