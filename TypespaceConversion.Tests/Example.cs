namespace TypespaceConversion.Tests;

public static class Example
{
   private static string? test;
   public static string Test => Typespace.Name( ref test );

   public static class Page
   {
      public static class SubSection
      {
         public static class Row
         {
            private static string? header;
            public static string Header => Typespace.Name( ref header );
         }
      }
   }
}
