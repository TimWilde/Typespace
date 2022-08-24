namespace TypespaceConversion.Tests;

public class Example
{
   public static string Test => Typespace.Name;

   public class Page
   {
      public class SubSection
      {
         public class Row
         {
            public static string Header => Typespace.Name;
         }
      }
   }
}
