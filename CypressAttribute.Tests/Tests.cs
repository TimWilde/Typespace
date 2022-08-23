using FluentAssertions;

namespace CypressAttribute.Tests;

public class Tests
{
   [Test]
   public void Should_parse_the_type_structure_into_a_valid_cypress_data_name()
   {
      Example.Test
         .Should().Be( "example-test" );

      Example.Page.SubSection.Row.Header
         .Should().Be( "example-page-subsection-row-header" );
   }

   private static string Diversion => Example.Page.SubSection.Row.Header;
   private static readonly string Capture = Example.Test;

   [Test]
   public void Should_still_work_through_intermediates()
   {
      Capture
         .Should().Be( "example-test" );

      Diversion
         .Should().Be( "example-page-subsection-row-header" );
   }

   [Test]
   public void Should_build_a_valid_cypress_data_attribute()
   {
      Example.Page.SubSection.Row.Header.ToDataCy()
         .Should().Be( "data-cy=\"example-page-subsection-row-header\"" );
   }
}
