using ParcelApi.Services;
using Microsoft.AspNetCore.Mvc;
using ParcelApi.Models.Bags;

namespace ParcelApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LetterBagController : BagController
{

  private readonly LetterBagService _letterBagService;
  public LetterBagController(BagService bagService, LetterBagService letterBagService) : base(bagService)
  {
    _letterBagService = letterBagService;
  }

  [HttpGet("letter-bags")]
  public ActionResult<List<LetterBag>> GetAllLetterBags()
  {
    try
    {
      var bags = _bagService.GetAllLetterBags();
      return bags;
    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to get letter bags - Error: {ex.Message}");
    }

  }

  [HttpGet("{id}")]
  public ActionResult<LetterBag> GetLetterBagById(string id)
  {
    try
    {
      var bag = _bagService.GetLetterBagById(id);
      if (bag == null)
      {
        return NotFound("Letter bag with this ID does not exist in system");
      }
      return bag;
    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to get letter bag - Error: {ex.Message}");
    }
  }
  

  [HttpPut("{id}/add-letters")]
  public IActionResult Update(string id, int letterCount, decimal weight, decimal price)
  {
    try
    {
      var bag = _bagService.GetLetterBagById(id);
      if (bag == null)
      {
        return NotFound("Letter bag with this ID does not exist in system");
      }

      if (bag.BagId != id)
      {
        return BadRequest("Unauthorised");
      }

      _letterBagService.AddLettersToBag(bag, letterCount, weight, price);
      return Ok();

    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to add letters to bag - Error: {ex.Message}");
    }

  }

}
