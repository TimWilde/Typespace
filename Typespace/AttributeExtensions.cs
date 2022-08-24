namespace TypespaceConversion;

public static class AttributeExtensions
{
   public static string ToData( this string name, string dataName )
   {
      return string.IsNullOrWhiteSpace( name )
                ? string.Empty
                : $"data-{dataName}=\"{name}\"";
   }
}
