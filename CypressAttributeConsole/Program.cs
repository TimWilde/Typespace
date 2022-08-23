using BenchmarkDotNet.Running;

namespace CypressAttributeConsole;

public class Program
{
   public static void Main( string[] args )
   {
      BenchmarkRunner.Run<Benchmarks>();
   }
}
