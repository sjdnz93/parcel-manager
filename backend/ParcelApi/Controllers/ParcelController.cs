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
      return NotFound();
    }
    return parcel;
  }

  [HttpPost]
  public IActionResult Create(Parcel parcel)
  {
    ParcelService.Add(parcel);
    return CreatedAtAction(nameof(GetAll), new { id = parcel.ParcelId }, parcel);
  }

  [HttpDelete("{id}")]
  public IActionResult Delete(string id)
  {
    var parcel = ParcelService.Get(id);
    if (parcel is null)
      return NotFound();

    ParcelService.Delete(id);
    return NoContent();
  }

}
