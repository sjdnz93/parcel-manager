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

  protected readonly IBagService _bagService;

  public BagController(IBagService bagService)
  {
    _bagService = bagService;
  }

  [HttpGet]
  public async Task<ActionResult<List<Bag>>> GetAllBags()
  {
    try
    {
      var bags = await _bagService.GetAllBags();
      return bags;
    }
    catch (Exception ex)
    {
      return BadRequest($"Failed to get bags - Error: {ex.Message}");
    }

  }

}