namespace CypressAttribute.Tests;

public class Example
{
   public static string Test => Cypress.Name;

   public class Page
   {
      public class SubSection
      {
         public class Row
         {
            public static string Header => Cypress.Name;
         }
      }
   }
}
