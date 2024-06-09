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
// cars
//   .OrderByDescending(c => c.HP)
//   .Take(10) // Skip(page * items_per_page) and Take(items_per_page) to paginations
//   .Select(c => $"{c.Make} HP: {c.HP}")
//   .ToList()
//   .ForEach(Console.WriteLine);

// Display the number of models per make that appeared after 2011
// cars.Where(c => c.Year >= 2011)
//     .GroupBy(c => c.Make)
//     .Select(c => new { Make = c.Key, NumberOfModels = c.Count() })
//     .Select(c => $"{c.Make}: {c.NumberOfModels}")
//     .ToList()
//     .ForEach(Console.WriteLine);

// Display the number of models per make that appeared after 2011
// Makes should be displayed with a number of zero if there are no models after 2011
// cars.GroupBy(c => c.Make)
//     .Select(cGroup => new { Make = cGroup.Key, NumberOfModels = cGroup
//                                                 .Where(car => car.Year >= 2011)
//                                                 .Count() })
//     .Select(c => $"{c.Make}: {c.NumberOfModels}")
//     .ToList()
//     .ForEach(Console.WriteLine);

// Display a list of makes that have at least 2 models with >= 400hp
// cars
//   .Where(c => c.HP >= 400)
//   .GroupBy(c => c.Make)
//   .Select(c => new { Make = c.Key, NumberOfPowerfulCars = c.Count() })
//   .Where(c => c.NumberOfPowerfulCars >= 2)
//   .ToList()
//   .ForEach(Console.WriteLine);

// Display there average HP per make
// cars
//   .GroupBy(c => c.Make)
//   .Select(c => new { Make = c.Key, HPAvg = c.Average(car => car.HP) })
//   .ToList()
//   .ForEach(Console.WriteLine);

// How many makes build cars with HP between 0..100, 101..200. 201..300, 301..400, 401..500
cars
  .GroupBy(car => car.HP switch // The Switch expression is different from the Switch statement
  {
    <= 100 => "0..100",
    <= 200 => "101..200",
    <= 300 => "201..300",
    <= 400 => "301..400",
    _ => "401..500"
  })
  .Select(car => new
  {
    HPCategory = car.Key,
    NumberOfMake = car.Select(c => c.Make).Distinct().Count()
  }) // looks like Count() but distinct groups
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
