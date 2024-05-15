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
  private readonly ShipmentService _shipmentService;

  public ShipmentController(ShipmentService shipmentService)
  {
    _shipmentService = shipmentService;
  }

  [HttpGet]
  public ActionResult<List<Shipment>> GetAll() //=> ShipmentService.GetAll();
  {
    try
    {
      return _shipmentService.GetAll();
    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to get shipments - Error: {ex.Message}");
    }
  }

  [HttpGet("{id}")]
  public ActionResult<Shipment> Get(string id)
  {
    try
    {
      var shipment = _shipmentService.Get(id);
      if (shipment == null)
      {
        return NotFound("Shipment could not be found");
      }
      return shipment;
    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to get shipment - Error: {ex.Message}");
    }
  }

  [HttpPost]
  public IActionResult CreateShipment(Shipment shipment)
  {
    try
    {
      if (shipment == null)
      {
        return BadRequest("Shipment cannot be null");
      }
      _shipmentService.Add(shipment);
      return CreatedAtAction(nameof(Get), new { id = shipment.ShipmentId }, shipment);
    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to create shipment - Error: {ex.Message}");
    }

  }

  [HttpPut("{id}/add-parcel-bag")]
  public IActionResult AddParcelBagToShipment(string id, ParcelBag bag)
  {
    try
    {
      var shipment = _shipmentService.Get(id);
      if (shipment == null)
      {
        return NotFound("Shipment with this ID does not exist");
      }

      if (shipment.ShipmentId != id)
      {
        return BadRequest("Not authorised");
      }

      _shipmentService.AddParcelBagToShipment(id, bag);

      return Ok();
    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to add parcel bag to shipment - Error: {ex.Message}");
    }

  }

  [HttpPut("{id}/add-letter-bag")]
  public IActionResult AddLetterBagToShipment(string id, LetterBag bag)
  {
    try
    {
      var shipment = _shipmentService.Get(id);
      if (shipment == null)
      {
        return NotFound("Shipment with this ID does not exist");
      }

      if (shipment.ShipmentId != id)
      {
        return BadRequest("Not authorised");
      }

      _shipmentService.AddLetterBagToShipment(shipment, bag);

      return Ok();

    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to add letter bag to shipment - Error: {ex.Message}");
    }

  }

  [HttpPut("{id}/finalise-shipment")]
  public IActionResult FinaliseShipment(string id)
  {
    try
    {
      var shipment = _shipmentService.Get(id);
      if (shipment == null)
      {
        return NotFound();
      }

      if (shipment.ShipmentId != id)
      {
        return BadRequest();
      }

      _shipmentService.FinaliseShipment(shipment);

      return Ok();
    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to finalise shipment - Error: {ex.Message}");
    }

  }


}
