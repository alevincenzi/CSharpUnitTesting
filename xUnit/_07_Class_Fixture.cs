using Xunit;
using Xunit.Abstractions;

namespace CSharpUnitTesting.xUnit
{
    [Trait("Category", "SharingSetup")]
    [Trait("SharingLevel", "Class")]
    public class _07_Class_Fixture : IClassFixture<Counter>  
    {
        private readonly ITestOutputHelper output;

        Counter testCounter;

        public _07_Class_Fixture(ITestOutputHelper output, Counter counter)
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