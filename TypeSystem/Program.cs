// See https://aka.ms/new-console-template for more information


using System.Text;

decimal n1 = 0.1M;
decimal n2 = 0.2M;

Console.WriteLine(n1 + n2 == 0.3M);

var myName = "Victor";

Console.WriteLine(myName.ToUpper());


object o = 10;

// boxing
if (o is 10)
{
  Console.WriteLine("O: Same value!");
}

// Unboxing
int o2 = (int)o;
if (o2 is 10)
{
  Console.WriteLine("O2: Same value!");
}


// spread c# 12
int[] row0 = [1, 2, 3];
int[] row1 = [4, 5, 6];
int[] row2 = [7, 8, 9];
int[] single = [.. row0, .. row1, .. row2];

foreach (var element in single)
{
  Console.Write($"{element}, "); // 1, 2, 3, 4, 5, 6, 7, 8, 9,
}

Console.WriteLine();

static void RestFunc(int x, int y, params int[] rest)
{

  int[] arr = [x, y, .. rest];

  Console.WriteLine($"Array sum: {arr.Sum()}");
}

RestFunc(10, 20, 30, 40, 50, 60, 70, 80, 90, 100);

static void DoSomething()
{

  DateTime date = new();
  var dt = date;

  StringBuilder stringBuilder = new();
  var sb = stringBuilder;

  GC.Collect();
}

DoSomething();