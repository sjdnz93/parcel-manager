using ParcelApi.Models;
using ParcelApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ParcelApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ParcelController : ControllerBase
{
  public ParcelController()
  {
  }

  [HttpGet]
  public ActionResult<List<Parcel>> GetAll() => ParcelService.GetAll();

  [HttpGet("{id}")]
  public ActionResult<Parcel> Get(string id)
  {

    var parcel = ParcelService.Get(id);

    if (parcel == null)
    {
      return NotFound("Parcel could not be found");
    }
    return parcel;
  }

}
