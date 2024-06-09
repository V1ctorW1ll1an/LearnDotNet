using Classes;

static int Add(int a, int b)
{
  return a + b;
}

static int Sub(int a, int b)
{
  return a - b;
}

static void ProcessAndPrint(int a, int b, DelegateCalc f)
{
  var result = f(a, b);
  Console.WriteLine($"O resultado eh {result}");
}

static void ProcessAndPrintAnything<T>(T x, T y, Combination<T> f)
{
  var result = f(x, y);
  Console.WriteLine($"O resultado eh {result}");
}


ProcessAndPrint(10, 10, Add);
ProcessAndPrint(20, 10, Sub);

ProcessAndPrintAnything(10, 10, Add);
ProcessAndPrintAnything(20, 10, Sub);

ProcessAndPrintAnything(2, 100, (x, y) => x * y);

ProcessAndPrintAnything(true, true, (x, y) => x && y);
ProcessAndPrintAnything("Victor", "Willian", (firstName, lastName) => $"{firstName} {lastName}");

GenericList<Employee> gl = new();

// Employee employee = new("Victor", 10);
// Employee employee1 = new("Foo", 11);
// Employee employee2 = new("Bar", 12);

var employees = new List<Employee>
{
    new("Victor", 10),
    new("Foo", 11),
    new("Bar", 12)
};

foreach (var employee in employees)
{
  gl.AddHead(employee);
}

foreach (var employee in gl)
{
  Console.WriteLine($"Name: {employee.Name} | ID: {employee.ID}");
}

delegate int DelegateCalc(int a, int b);
delegate T Combination<T>(T a, T b);
