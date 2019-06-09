using Xunit;
using Xunit.Abstractions;

namespace CSharpUnitTesting.xUnit
{
    [Trait("Category", "Fact")]
    public class Fact
    {
        private readonly ITestOutputHelper output;

        public Fact(ITestOutputHelper output) => this.output = output;

        [Fact]
        public void AFactIsATest()
        {
            output.WriteLine("I am a Fact");
        }

        [Fact(DisplayName="MyDisplayName")]
        public void ThisTestHasADisplayName()
        {
            output.WriteLine("I have my own display name");
        }

        [Fact(Skip="To be implemented...")]
        public void ThisTestWontRun()
        {
            output.WriteLine("I wont be executed");     
        }

        [Fact(Timeout=1000)]
        public void ThisTestMustTakeLessThanOneSecond()
        {
            output.WriteLine("I must terminate soon");
        }

        [Trait("Category", "Timeout")]
        [Fact(Timeout=1000)]
        public void ThisTestHasACategory()
        {
            // To run tests by category:
            // dotnet test --filter "Category=Timeout"
            output.WriteLine("I have my own display name");
        }
    }
}
