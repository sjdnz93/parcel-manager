using ParcelApi.Models;
using ParcelApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ParcelApi.Models.Bags;

namespace ParcelApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BagController : ControllerBase
{

  protected readonly BagService _bagService;

  public BagController(BagService bagService)
  {
    _bagService = bagService;
  }

  [HttpGet]
  public ActionResult<List<Bag>> GetAllBags()
  {
    try
    {
      var bags = _bagService.GetAllBags();
      return bags;
    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to get bags - Error: {ex.Message}");
    }

  }

}

// TODO add DELETE controller