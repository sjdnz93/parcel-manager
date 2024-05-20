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

}

