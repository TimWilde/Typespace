using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using TypespaceConversion.Tests;

namespace TypespaceConversion.Benchmarks.Console;

[MemoryDiagnoser]
[Orderer( SummaryOrderPolicy.FastestToSlowest )]
[RankColumn]
public class Benchmarks
{
   [Benchmark]
   public void RunTheThing()
   {
      string? _ = Example.Page.SubSection.Row.Header;
   }
}
