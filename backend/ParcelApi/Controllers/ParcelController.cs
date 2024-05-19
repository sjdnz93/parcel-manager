using ParcelApi.Models;
using ParcelApi.Services;
using Microsoft.AspNetCore.Mvc;
using ParcelApi.Interfaces;

namespace ParcelApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ParcelController : ControllerBase
{

  private readonly IParcelService _parcelService;
  public ParcelController(IParcelService parcelService)
  {
    _parcelService = parcelService;
  }

  [HttpGet]
  public async Task<ActionResult<List<Parcel>>> GetAll()
  {
    try
    {
      var parcels = await _parcelService.GetAll();
      return Ok(parcels);
    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to get parcels - Error: {ex.Message}");
    }
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Parcel>> Get(string id)
  {
    try
    {
      var parcel = await _parcelService.Get(id);

      if (parcel == null)
      {
        return NotFound("Parcel could not be found");
      }
      return Ok(parcel);
    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to get parcel - Error: {ex.Message}");
    }

  }

  // [HttpPut("{id}")]
  // public IActionResult UpdateParcel(string id, string? recipientName, decimal? weight, decimal? price)
  // {
  //   try
  //   {
  //     var parcel = _parcelService.Get(id);
  //     if (parcel == null)
  //     {
  //       return NotFound("Parcel with this ID does not exist");
  //     }
      
  //     if (parcel.ParcelId != id)
  //     {
  //       return BadRequest("Unauthorised");
  //     }

  //     _parcelService.UpdateParcel(id, recipientName, weight, price);
  //     return Ok();
  //   }
  //   catch (Exception ex)
  //   {
  //     return BadRequest($"Failed to update parcel - Error: {ex.Message}");
  //   }
  // }

  // [HttpDelete("{id}")]
  // public IActionResult DeleteParcel(string id)
  // {
  //   try
  //   {
  //     var parcel = _parcelService.Get(id);
  //     if (parcel == null)
  //     {
  //       return NotFound("Parcel with this ID does not exist");
  //     }
  //     _parcelService.DeleteParcel(id);
  //     return Ok();
  //   }
  //   catch (Exception ex)
  //   {
  //     return BadRequest($"Failed to delete parcel - Error: {ex.Message}");
  //   }
  // }

}

