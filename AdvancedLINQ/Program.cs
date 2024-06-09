using System.Text.Json;
using System.Text.Json.Serialization;

var fileContent = await File.ReadAllTextAsync("./MOCK_DATA.json");
var cars = JsonSerializer.Deserialize<IEnumerable<CarData>>(fileContent);

var carsWithAtLeastFourDoors = cars!.Where(c => c.NumberOfDoors >= 4);

foreach (var car in carsWithAtLeastFourDoors)
{
  Console.WriteLine($"The car {car.Model} has {car.NumberOfDoors} doors!");
}

class CarData
{
  [JsonPropertyName("id")]
  public int ID { get; set; }
  [JsonPropertyName("car_make")]
  public string Make { get; set; } = string.Empty;
  [JsonPropertyName("car_models")]
  public string Model { get; set; } = string.Empty;
  [JsonPropertyName("car_year")]
  public int Year { get; set; }
  [JsonPropertyName("number_of_doors")]
  public int NumberOfDoors { get; set; }
  [JsonPropertyName("hp")]
  public int HP { get; set; }
}
