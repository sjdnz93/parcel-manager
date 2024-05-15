using ParcelApi.Models;
using ParcelApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ParcelApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ParcelController : ControllerBase
{

  private readonly ParcelService _parcelService;
  public ParcelController(ParcelService parcelService)
  {
    _parcelService = parcelService;
  }

  [HttpGet]
  public ActionResult<List<Parcel>> GetAll() //=> ParcelService.GetAll();
  {
    try
    {
      return _parcelService.GetAll();
    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to get parcels - Error: {ex.Message}");
    }
  }

  [HttpGet("{id}")]
  public ActionResult<Parcel> Get(string id)
  {
    try
    {
      var parcel = _parcelService.Get(id);

      if (parcel == null)
      {
        return NotFound("Parcel could not be found");
      }
      return parcel;
    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to get parcel - Error: {ex.Message}");
    }

  }

}
