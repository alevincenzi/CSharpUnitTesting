using Xunit;
using Xunit.Abstractions;
using CSharpUnitTesting.xUnit.Sdk;

namespace CSharpUnitTesting.xUnit
{
    [Trait("Category", "SharingSetup")]
    [Trait("SharingLevel", "Class")]
    public class Class_Fixture : IClassFixture<ACounter>  
    {
        private readonly ITestOutputHelper output;

        ACounter testCounter;

        public Class_Fixture(ITestOutputHelper output, ACounter counter)
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