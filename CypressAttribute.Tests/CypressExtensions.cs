namespace CypressAttribute.Tests;

public static class CypressExtensions
{
   public static string ToDataCy( this string name )
   {
      return string.IsNullOrWhiteSpace( name )
                ? string.Empty
                : $"data-cy=\"{name}\"";
   }
}
