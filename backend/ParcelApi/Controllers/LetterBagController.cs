using ParcelApi.Services;
using Microsoft.AspNetCore.Mvc;
using ParcelApi.Models.Bags;

namespace ParcelApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LetterBagController : ControllerBase
{

  [HttpGet]
  public ActionResult<List<LetterBag>> GetAllLetterBags()
  {
    var bags = BagService.GetAllLetterBags();
    return bags;
  }

  [HttpPut("{id}/add-letters")]
  public IActionResult Update(string id, int letterCount, decimal weight, decimal price)
  {
    try
    {
      var bag = BagService.GetLetterBagById(id);
      if (bag == null)
      {
        return NotFound("Bag with this ID does not exist in system");
      }

      if (bag.BagId != id)
      {
        return BadRequest("Unauthorised");
      }

      LetterBagService.AddLettersToBag(bag, letterCount, weight, price);
      return Ok();

    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to add letters to bag - Error: {ex.Message}");
    }

  }

}

// [HttpPost]
// public ActionResult<LetterBag> CreateParcelBag([FromBody] LetterBag bag)
// {
//   LetterBagService.AddLetterBag(bag);
//   return bag;
// }
