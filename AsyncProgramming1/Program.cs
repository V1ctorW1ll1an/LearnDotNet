// var lines = File.ReadAllLines("./text.txt");

// foreach (var line in lines)
// {
//   Console.WriteLine(line);
// }


static async Task ReadFilesAsync()
{
  // 
  var lines = await File.ReadAllLinesAsync("./text.txt");

  foreach (var line in lines)
  {
    Console.WriteLine(line);
  }
}

await ReadFilesAsync();

static async Task<int> GetDataFromNetworkAsync()
{
  // simulate a network call
  await Task.Delay(150);
  var result = 10;

  return result;
}

var networkResult = await GetDataFromNetworkAsync();

Func<Task<int>> getDataFromNetworkAsyncViaLambda = async () =>
{
  // simulate a network call
  await Task.Delay(150);
  var result = 10;

  return result;
};

var networkResultViaLambda = await getDataFromNetworkAsyncViaLambda();

// var lines = File.ReadAllLinesAsync("./text.txt");
// lines.Wait(); // bad, don't do that


// File.ReadAllLinesAsync("./txt.txt")
//   .ContinueWith(t =>
//   {

//     if (t.IsFaulted)
//     {
//       Console.Error.WriteLine(t.Exception);
//     }

//     // Task will be completed!
//     var lines = t.Result;
//     foreach (var line in lines)
//     {
//       Console.WriteLine(line);
//     }
//   });

// Console.ReadKey();


