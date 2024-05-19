using ParcelApi.Services;
using Microsoft.AspNetCore.Mvc;
using ParcelApi.Models.Bags;
using ParcelApi.Models;
using ParcelApi.Interfaces;

namespace ParcelApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ParcelBagController : BagController
{
  private readonly IParcelBagService _parcelBagService;
  public ParcelBagController(IBagService bagService, IParcelBagService parcelBagService) : base(bagService)
  {
    _parcelBagService = parcelBagService;
  }

  [HttpGet("parcel-bags")]
  public async Task<ActionResult<List<ParcelBag>>> GetAllParcelBags()
  {
    try
    {
      var bags = await _bagService.GetAllParcelBags();
      if (bags == null)
      {
        return NotFound("No parcel bags exist in the system");
      }
      return Ok(bags);
    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to get bags - Error: {ex.Message}");
    }

  }

  [HttpGet("{id}")]
  public async Task<ActionResult<ParcelBag>> Get(string id)
  {
    try
    {
      var bag = await _bagService.GetParcelBagById(id);
      if (bag == null)
      {
        return NotFound("Parcel bag with this ID does not exist in the system");
      }
      return Ok(bag);
    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to get bag - Error: {ex.Message}");
    }

  }

  [HttpPut("{id}/add-parcel")]
  public async Task<IActionResult> Update(string id, Parcel parcel)
  {
    try
    {
      var bag = await _bagService.GetParcelBagById(id);
      if (bag == null)
      {
        return NotFound("Parcel bag with this ID does not exist in system");
      }

      if (bag.BagId != id)
      {
        return BadRequest("Unauthorised");
      }

      await _parcelBagService.AddParcelToBag(id, parcel);
      return Ok();
    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to add parcel to bag - Error: {ex.Message}");
    }

  }

}