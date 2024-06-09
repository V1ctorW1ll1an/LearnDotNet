using System.Text.Json;
using System.Text.Json.Serialization;

var fileContent = await File.ReadAllTextAsync("./MOCK_DATA.json");
// The ! ensure that car is not null
IEnumerable<CarData> cars = JsonSerializer.Deserialize<IEnumerable<CarData>>(fileContent)!;

var carsWithAtLeastFourDoors = cars.Where(c => c.NumberOfDoors >= 4);

// foreach (var car in carsWithAtLeastFourDoors)
// {
//   Console.WriteLine($"The car {car.Model} has {car.NumberOfDoors} doors!");
// }

var mazdasWithAtLeastFourDoors = cars
                                  .Where(c => c.Make == "Mazda")
                                  .Where(c => c.NumberOfDoors >= 4);

// foreach (var car in mazdasWithAtLeastFourDoors)
// {
//   Console.WriteLine($"The Mazdar car {car.Model} has {car.NumberOfDoors} doors!");
// }

// cars
//   .Where(c => c.Make.StartsWith('M'))
//   .Select(c => $"{c.Make} - {c.Model}")
//   .ToList()
//   .ForEach(c => Console.WriteLine($"Start with M: {c}"));

// Display a list of the 10 most powerfull cars (in term of hp)
cars
  .OrderByDescending(c => c.HP)
  .Take(10) // Skip(page * items_per_page) and Take(items_per_page) to paginations
  .Select(c => $"{c.Make} HP: {c.HP}")
  .ToList()
  .ForEach(Console.WriteLine);

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
