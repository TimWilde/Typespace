using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using CypressAttribute.Tests;

namespace CypressAttributeConsole;

[MemoryDiagnoser]
[Orderer( SummaryOrderPolicy.FastestToSlowest )]
[RankColumn]
public class Benchmarks
{
   [Benchmark]
   public void RunTheThing()
   {
      Example.Page.SubSection.Row.Header.ToString();
   }
}
