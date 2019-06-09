using Xunit;
using Xunit.Abstractions;
using CSharpUnitTesting.sdk;

namespace CSharpUnitTesting.xUnit
{
    [Trait("Category", "Theory")]
    public class Theory_ClassData
    {
        private readonly ITestOutputHelper output;

        public Theory_ClassData(ITestOutputHelper output) => this.output = output;

        [Theory]
        [ClassData(typeof(AClassData))]
        public void UsingClassData(AMemberData param)
        {
            output.WriteLine($"Using parameter {param.aProperty}");
        }
    }
}