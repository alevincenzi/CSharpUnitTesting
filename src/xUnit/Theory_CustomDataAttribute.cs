using Xunit;
using Xunit.Abstractions;
using CSharpUnitTesting.xUnit.Sdk;

namespace CSharpUnitTesting.xUnit
{
    [Trait("Category", "Theory")]
    public class Theory_CustomDataAttribute
    {
        private readonly ITestOutputHelper output;

        public Theory_CustomDataAttribute(ITestOutputHelper output) => this.output = output;

        [Theory]
        [ACustomData(2)]
        public void UsingCustomDataAttribute(AMemberData param)
        {
            output.WriteLine($"Using parameter {param.aProperty}");
        }
    }
}