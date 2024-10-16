

namespace lastgregslist.Repositories;

public class HousesRepository
{
  public HousesRepository(IDbConnection db)
  {
    _db = db;
  }


  private readonly IDbConnection _db;

  internal List<House> getHouses()
  {
    string sql = @"
    SELECT 
    houses.*,
    accounts.*
    From houses
    JOIN accounts ON houses.creatorId = accounts.id;";

    List<House> houses = _db.Query<House, Account, House>(sql, (house, account) =>
    {
      house.creator = account;
      return house;
    }).ToList();
    return houses;
  }

  internal House createHouse(House houseData)
  {
    string sql = @"
    INSERT INTO 
    houses(sqft, bedrooms, bathrooms, imgUrl, description, price, location, creatorId)
    Values(@Sqft, @Bedrooms, @Bathrooms, @ImgUrl, @Description, @Price, @Location, @CreatorId);
    
    SELECT 
    houses.*,
    accounts.*
    FROM houses
    JOIN accounts on houses.creatorId = accounts.id
    WHERE houses.id = LAST_INSERT_ID();";

    House house = _db.Query<House, Account, House>(sql, (house, account) =>
    {
      house.creator = account;
      return house;
    }, houseData).FirstOrDefault();
    return house;
  }
}