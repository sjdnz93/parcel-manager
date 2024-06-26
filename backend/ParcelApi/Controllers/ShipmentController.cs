﻿using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using ParcelApi.Models;
using ParcelApi.Models.Bags;
using ParcelApi.Services;
using ParcelApi.Interfaces;

namespace ParcelApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ShipmentController : ControllerBase
{
  private readonly IShipmentService _shipmentService;

  public ShipmentController(IShipmentService shipmentService)
  {
    _shipmentService = shipmentService;
  }

  [HttpGet]
  public async Task<ActionResult<List<Shipment>>> GetAll() //=> ShipmentService.GetAll();
  {
    try
    {
      var shipments = await _shipmentService.GetAll();
      return Ok(shipments);
    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to get shipments - Error: {ex.Message}");
    }
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Shipment>> Get(string id)
  {
    try
    {
      var shipment = await _shipmentService.Get(id);
      if (shipment == null)
      {
        return NotFound("Shipment could not be found");
      }
      return Ok(shipment);
    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to get shipment - Error: {ex.Message}");
    }
  }

  [HttpPost]
  public async Task<IActionResult> CreateShipment(Shipment shipment)
  {
    try
    {
      if (shipment == null)
      {
        return BadRequest("Shipment cannot be null");
      }
      await _shipmentService.AddShipment(shipment);
      return CreatedAtAction(nameof(Get), new { id = shipment.ShipmentId }, shipment);
    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to create shipment - Error: {ex.Message}");
    }

  }

  [HttpPut("{id}/add-parcel-bag")]
  public async Task<IActionResult> AddParcelBagToShipment(string id, ParcelBag bag)
  {
    try
    {
      var shipment = await _shipmentService.Get(id);
      if (shipment == null)
      {
        return NotFound("Shipment with this ID does not exist");
      }

      if (shipment.ShipmentId != id)
      {
        return BadRequest("Not authorised");
      }

      await _shipmentService.AddParcelBagToShipment(id, bag);

      return Ok();
    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to add parcel bag to shipment - Error: {ex.Message}");
    }

  }

  [HttpPut("{id}/add-letter-bag")]
  public async Task<IActionResult> AddLetterBagToShipment(string id, LetterBag bag)
  {
    try
    {
      var shipment = await _shipmentService.Get(id);
      if (shipment == null)
      {
        return NotFound("Shipment with this ID does not exist");
      }

      if (shipment.ShipmentId != id)
      {
        return BadRequest("Not authorised");
      }

      await _shipmentService.AddLetterBagToShipment(shipment, bag);

      return Ok();

    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to add letter bag to shipment - Error: {ex.Message}");
    }

  }

  [HttpPut("{id}/finalise-shipment")]
  public async Task<IActionResult> FinaliseShipment(string id)
  {
    try
    {
      var shipment = await _shipmentService.Get(id);
      if (shipment == null)
      {
        return NotFound();
      }

      if (shipment.ShipmentId != id)
      {
        return BadRequest();
      }

      await _shipmentService.FinaliseShipment(shipment);

      return Ok();
    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to finalise shipment - Error: {ex.Message}");
    }

  }


}
