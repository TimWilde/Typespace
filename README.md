This is a tiny trick to allow nested classes in C# to be used in place of strings when specifying IDs in HTML. This then makes it possible/easier to refactor, find usages, and generally lean on code tooling to get consistent client-side IDs.

For example, given this (comprised of nested classes):

``` csharp
Example.Page.SubSection.Row.Header // Yes, it's excessive
```

This is implicitly converted to a string as:

```
"example-page-subsection-row-header"
```

The C# code defining the above example nested class heirarchy looks like this:

(This becomes more economical when the number of properties - IDs per page - increases)

```csharp
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
```

> Note that the `Test` and `Header` properties are expression bodied properties.
