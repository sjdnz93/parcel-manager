using ParcelApi.Services;
using Microsoft.AspNetCore.Mvc;
using ParcelApi.Models.Bags;

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

  [HttpPost]
  public ActionResult<ParcelBag> CreateParcelBag([FromBody] ParcelBag bag)
  {
    ParcelBagService.AddParcelBag(bag);
    return bag;
  }

}