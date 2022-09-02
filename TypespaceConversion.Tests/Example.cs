namespace TypespaceConversion.Tests;

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
