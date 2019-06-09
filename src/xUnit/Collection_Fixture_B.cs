using Xunit;
using Xunit.Abstractions;
using CSharpUnitTesting.sdk;

namespace CSharpUnitTesting.xUnit
{
    [Trait("Category", "SharingSetup")]
    [Trait("SharingLevel", "Collection")]
    [Collection("Counter Collection")]
    public class Collection_Fixture_B
    {
        private readonly ITestOutputHelper output;

        ACounter testCounter;

        public Collection_Fixture_B(ITestOutputHelper output, ACounter counter)
        {
            this.output = output;
            this.testCounter = counter;
        }

        [Fact]
        public void FirstTest()
        {
            output.WriteLine($"First test is running with {testCounter.Value}");
        }

        [Fact]
        public void SecondTest()
        {
            output.WriteLine($"Second test is running with {testCounter.Value}");
        }

        [Fact]
        public void ThirdTest()
        {
            output.WriteLine($"Third test is running with {testCounter.Value}");
        }
    }
}
