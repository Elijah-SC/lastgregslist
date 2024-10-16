using Microsoft.AspNetCore.Http.HttpResults;

namespace lastgregslist.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HousesController : ControllerBase
{

  public HousesController(HousesService housesService, Auth0Provider auth0Provider)
  {
    _housesService = housesService;
    _auth0Provider = auth0Provider;
  }
  private readonly HousesService _housesService;
  private readonly Auth0Provider _auth0Provider;

  [HttpGet]
  public ActionResult<List<House>> getHouses()
  {
    try
    {
      List<House> houses = _housesService.getHouses();
      return Ok(houses);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }

  [HttpPost]
  public async Task<ActionResult<House>> createHouse([FromBody] House HouseData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      HouseData.creatorId = userInfo.Id;
      House house = _housesService.createHouse(HouseData);
      return house;
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }
}
