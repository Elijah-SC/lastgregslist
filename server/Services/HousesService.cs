

namespace lastgregslist.Services;

public class HousesService
{
  public HousesService(HousesRepository repository)
  {
    _repository = repository;
  }

  private readonly HousesRepository _repository;

  internal List<House> getHouses()
  {
    List<House> houses = _repository.getHouses();
    return houses;
  }

  internal House createHouse(House houseData)
  {
    House house = _repository.createHouse(houseData);
    return house;
  }
}

