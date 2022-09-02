# Typespace

This is a tiny trick to allow nested classes in C# to be used in place of strings when specifying IDs in HTML. This then makes it possible/easier to refactor, find usages, and generally lean on code tooling to get consistent client-side IDs.

For example, given this (comprised of nested classes):

``` csharp
Example.Page.SubSection.Row.Header // Yes, it's excessive. Maybe.
```

This is implicitly converted to a string as:

```
"example-page-subsection-row-header"
```

The C# code defining the above example nested class heirarchy looks like this:

(This becomes more economical when the number of properties - IDs per page - increases)

```csharp
public static class Example
{
   private static string? test;
   public static string Test => test ??= Typespace.Name;

   public static class Page
   {
      public static class SubSection
      {
         public static class Row
         {
            private static string? header;
            public static string Header => header ??= Typespace.Name;
         }
      }
   }
}
```

## Usage pattern

To get this to generate the correct name, a specific pattern needs to be used as seen in the `Example` above. 

> Each string property **has** to be an expression bodied property.

This, when called, will then execute in the context of the property getter rather than the `Typespace` constructor, so we can grab the property name from the callstack metadata.

### Caching fields

The null coalescing assignment operator seen in the `Example` helps to speed things up immensely. `Typespace` is fast, but why do the same work more than once?

## But is it quick enough?

This is a primary concern - if this is going to be used in the render pipeline, it needs to be fast and efficient.

```
// * Detailed results *
Benchmarks.RunTheThing: DefaultJob
Runtime = .NET 6.0.8 (6.0.822.36306), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.065 ns, StdErr = 0.001 ns (0.14%), N = 15, StdDev = 0.006 ns
Min = 1.058 ns, Q1 = 1.060 ns, Median = 1.065 ns, Q3 = 1.071 ns, Max = 1.074 ns
IQR = 0.011 ns, LowerFence = 1.044 ns, UpperFence = 1.087 ns
ConfidenceInterval = [1.059 ns; 1.071 ns] (CI 99.9%), Margin = 0.006 ns (0.57% of Mean)
Skewness = 0.21, Kurtosis = 1.37, MValue = 2
-------------------- Histogram --------------------
[1.055 ns ; 1.077 ns) | @@@@@@@@@@@@@@@
---------------------------------------------------

// * Summary *

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i9-9900K CPU 3.60GHz (Coffee Lake), 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.400
  [Host]     : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT
  DefaultJob : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT


|      Method |     Mean |     Error |    StdDev | Rank | Allocated |
|------------ |---------:|----------:|----------:|-----:|----------:|
| RunTheThing | 1.065 ns | 0.0061 ns | 0.0057 ns |    1 |         - |

// * Legends *
  Mean      : Arithmetic mean of all measurements
  Error     : Half of 99.9% confidence interval
  StdDev    : Standard deviation of all measurements
  Rank      : Relative position of current benchmark mean among all benchmarks (Arabic style)
  Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
  1 ns      : 1 Nanosecond (0.000000001 sec)
```
