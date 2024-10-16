using System.ComponentModel.DataAnnotations;

namespace lastgregslist.Models;

public class House
{
  public int id { get; set; }
  [Range(0, 1000000000)] public int sqft { get; set; }
  [Range(0, 100)] public int bedrooms { get; set; }
  [Range(0, 100)] public int bathrooms { get; set; }
  [MinLength(10), MaxLength(500)] public string imgUrl { get; set; }
  [MaxLength(10000)] public string description { get; set; }
  [Range(0, 1000000000)] public int price { get; set; }
  public string location { get; set; } = "unknown";
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string creatorId { get; set; }
  public Account creator { get; set; }
}