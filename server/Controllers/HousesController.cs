namespace lastgregslist.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HousesController
{
  public HousesController(HousesService housesService)
  {
    _housesService = housesService;
  }

  private readonly HousesService _housesService;


}