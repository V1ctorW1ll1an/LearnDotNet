using System.Diagnostics;

// using BenchmarkDotNet.Attributes;
// using BenchmarkDotNet.Running;
// var summary = BenchmarkRunner.Run<MemoryBenchmarkerDemo>();

// [MemoryDiagnoser, RPlotExporter]
// public class MemoryBenchmarkerDemo
// {
//   [Benchmark]
//   public void Count()
//   {
//     for (var i = 0; i < 100000000; i++) ;
//   }
// }

MeasureTime(Count);

static void MeasureTime(Action a)
{
  var watch = Stopwatch.StartNew();
  a();
  watch.Stop();
  Console.WriteLine($"Tempo: {watch.Elapsed}");
}

static void Count()
{
  for (var i = 0; i < 2000000000; i++) ;
}