using ParcelApi.Services;
using Microsoft.AspNetCore.Mvc;
using ParcelApi.Models.Bags;
using ParcelApi.Models;

namespace ParcelApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ParcelBagController : ControllerBase
{

  [HttpGet]
  public ActionResult<List<ParcelBag>> GetAllParcelBags()
  {
    var bags = BagService.GetAllParcelBags();
    return bags;
  }

  [HttpGet("{id}")]
  public ActionResult<ParcelBag> Get(string id)
  {
    var bag = BagService.GetParcelBagById(id);
    if (bag == null)
    {
      return NotFound();
    }
    return bag;
  }

  [HttpPut("{id}/add-parcel")]
  public IActionResult Update(string id, Parcel parcel)
  {
    var bag = BagService.GetParcelBagById(id);
    if (bag == null)
    {
      return NotFound("Bag with this ID does not exist in system");
    }

    if (bag.BagId != id)
    {
      return BadRequest();
    }

    ParcelBagService.AddParcelToBag(bag, parcel);
    return Ok();
  }

}

  // [HttpPost]
  // public ActionResult<ParcelBag> CreateParcelBag([FromBody] ParcelBag bag)
  // {
  //   ParcelBagService.AddParcelBag(bag);
  //   return bag;
  // }