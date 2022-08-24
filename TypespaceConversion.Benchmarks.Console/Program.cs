using BenchmarkDotNet.Running;

namespace TypespaceConversion.Benchmarks.Console;

public class Program
{
   public static void Main( string[] args )
   {
      BenchmarkRunner.Run<Benchmarks>();
   }
}
