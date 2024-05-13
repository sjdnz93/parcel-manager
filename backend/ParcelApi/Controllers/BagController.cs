using ParcelApi.Models;
using ParcelApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace ParcelApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BagController : ControllerBase
{

  public BagController()
  {
  }

  [HttpGet]
  public ActionResult<List<Bag>> GetAllBags()
  {
    var bags = BagService.GetAllBags();
    return bags;
  }



  // [HttpGet("{id}")]
  // public ActionResult<Bag> Get(string id)
  // {
  //   var bag = BagService.Get(id);
  //   if (bag == null)
  //   {
  //     return NotFound();
  //   }
  //   return bag;
  // }

  // [HttpPost]
  // public IActionResult Create(Bag bag)
  // {
  //   BagService.Add(bag);
  //   return CreatedAtAction(nameof(Get), new { id = bag.BagId }, bag);
  // }

  // [HttpDelete("{id}")]
  // public IActionResult Delete(string id)
  // {
  //   var bag = BagService.Get(id);
  //   if (bag == null)
  //   {
  //     return NotFound();
  //   }
  //   BagService.Delete(id);
  //   return NoContent();
  // }
}
