using ParcelApi.Services;
using Microsoft.AspNetCore.Mvc;
using ParcelApi.Models.Bags;
using ParcelApi.Models;

namespace ParcelApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ParcelBagController : BagController
{
  private readonly ParcelBagService _parcelBagService;
  public ParcelBagController(BagService bagService, ParcelBagService parcelBagService) : base(bagService)
  {
    _parcelBagService = parcelBagService;
  }

  [HttpGet("parcel-bags")]
  public ActionResult<List<ParcelBag>> GetAllParcelBags()
  {
    try
    {
      var bags = _bagService.GetAllParcelBags();
      if (bags == null)
      {
        return NotFound("No parcel bags exist in the system");
      }
      return bags;
    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to get bags - Error: {ex.Message}");
    }

  }

  [HttpGet("{id}")]
  public ActionResult<ParcelBag> Get(string id)
  {
    try
    {
      var bag = _bagService.GetParcelBagById(id);
      if (bag == null)
      {
        return NotFound("Parcel bag with this ID does not exist in the system");
      }
      return bag;
    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to get bag - Error: {ex.Message}");
    }

  }

  [HttpPut("{id}/add-parcel")]
  public IActionResult Update(string id, Parcel parcel)
  {
    try
    {
      var bag = _bagService.GetParcelBagById(id);
      if (bag == null)
      {
        return NotFound("Parcel bag with this ID does not exist in system");
      }

      if (bag.BagId != id)
      {
        return BadRequest("Unauthorised");
      }

      _parcelBagService.AddParcelToBag(id, parcel);
      return Ok();
    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to add parcel to bag - Error: {ex.Message}");
    }

  }

}