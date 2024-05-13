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

    [HttpPost]
  public ActionResult<LetterBag> CreateParcelBag([FromBody] LetterBag bag)
  {
    LetterBagService.AddLetterBag(bag);
    return bag;
  }

}
