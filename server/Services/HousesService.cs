namespace lastgregslist.Services;

public class HousesService
{
  public HousesService(HousesRepository repository)
  {
    _repository = repository;
  }

  private readonly HousesRepository _repository;

}

