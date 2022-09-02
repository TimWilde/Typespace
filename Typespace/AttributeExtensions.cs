namespace TypespaceConversion;

public static class AttributeExtensions
{
   public static string ToData( this string value, string dataName ) =>
      string.IsNullOrWhiteSpace( value )
         ? string.Empty
         : $"data-{dataName}=\"{value}\"";
}
