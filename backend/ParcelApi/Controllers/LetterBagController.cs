using ParcelApi.Services;
using Microsoft.AspNetCore.Mvc;
using ParcelApi.Models.Bags;
using Microsoft.VisualBasic;
using ParcelApi.RequestClass;
using ParcelApi.Interfaces;

namespace ParcelApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LetterBagController : BagController
{

  private readonly ILetterBagService _letterBagService;
  public LetterBagController(IBagService bagService, ILetterBagService letterBagService) : base(bagService)
  {
    _letterBagService = letterBagService;
  }

  [HttpGet("letter-bags")]
  public async Task<ActionResult<List<LetterBag>>> GetAllLetterBags()
  {
    try
    {
      var bags = await _bagService.GetAllLetterBags();
      return Ok(bags);
    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to get letter bags - Error: {ex.Message}");
    }

  }

  [HttpGet("{id}")]
  public async Task<ActionResult<LetterBag>> GetLetterBagById(string id)
  {
    try
    {
      var bag = await _bagService.GetLetterBagById(id);
      if (bag == null)
      {
        return NotFound("Letter bag with this ID does not exist in system");
      }
      return Ok(bag);
    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to get letter bag - Error: {ex.Message}");
    }
  }
  

  [HttpPut("{id}/add-letters")]
  public async Task<IActionResult> Update(string id, LetterBagUpdate request)
  {
    try
    {
      var bag = await _bagService.GetLetterBagById(id);
      if (bag == null)
      {
        return NotFound("Letter bag with this ID does not exist in system");
      }

      if (bag.BagId != id)
      {
        return BadRequest("Unauthorised");
      }

      await _letterBagService.AddLettersToBag(bag, request);
      return Ok();

    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to add letters to bag - Error: {ex.Message}");
    }

  }

}
