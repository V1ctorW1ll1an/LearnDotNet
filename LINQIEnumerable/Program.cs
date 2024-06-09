using System;
// Random randNum = new Random();
// int[] test2 = Enumerable
//     .Repeat(0, numberOfRepetitions)
//     .Select(i => randNum.Next(Min, Max))
//     .ToArray();

// NOTE: When we use yield, we have to be careful because each time
// the variable that stores the result of GenerateNumbers is called,
// it will have different numbers since the GenerateNumbers function is actually
// processed only when the value of its return is really used.
static IEnumerable<int> GenerateNumbers(int numberOfRepetitions)
{
  // Random random = new();
  for (int i = 0; i < numberOfRepetitions; i++)
    yield return i;
  // yield return random.Next(MIN, MAX)
}

static void PrintNumbers(IEnumerable<int> numbersArr)
{
  foreach (var number in numbersArr)
    Console.Write($" {number} ");
}

// Methods in pipeline, defer operations, lazy evaluation
var numbers = GenerateNumbers(10);
var evenNumbers = numbers
  .Where(n => n % 2 == 0);
var numbersMultByTwo =
  (IEnumerable<int> numbersEnumerable) => numbersEnumerable.Select(n => n * 2);
var orderByDescendingNumbers = numbers.OrderByDescending(n => n);

// prints
Console.Write("\nNumbers: ");
PrintNumbers(numbers);

Console.Write("\nEven Numbers: ");
PrintNumbers(evenNumbers);

Console.Write("\nNumbers multiply by 2: ");
PrintNumbers(numbersMultByTwo(numbers));