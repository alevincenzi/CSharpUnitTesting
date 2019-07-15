using Xunit;
using Xunit.Abstractions;
using CSharpUnitTesting.xUnit.Sdk;

// 05 - Theory - Custom Data Attribute
//
// Instead of InlineData, ClassData or MemberData theories can
// work with custom attributes. The attribute must be the name
// of a class extending the abstract class DataAttribute.
// The constructor can help setting parameters.
// The function GetData returns the expected IEnumerable<object[]>.

namespace CSharpUnitTesting.xUnit
{
    [Trait("Category", "Theory")]
    public class Theory_CustomDataAttribute
    {
        private readonly ITestOutputHelper output;

        public Theory_CustomDataAttribute(ITestOutputHelper output) => this.output = output;

        // --> As any other theory, but the attribute is a class of ours!
        // The parameter in the signature depends on the type returned by
        // the enumerator.

        [Theory]
        [ACustomData(2)]
        public void UsingCustomDataAttribute(AClassData param)
        {
            output.WriteLine($"Using parameter {param.aProperty}");
        }
    }
}