using Xunit;
using Xunit.Abstractions;

// 01 - Facts - Simple unit tests

namespace CSharpUnitTesting.xUnit
{
    [Trait("Category", "Fact")]
    public class Fact
    {
        private readonly ITestOutputHelper output;

        // --> Output should be done injecting the class ITestOutputHelper
        // via the constructor. Output will be aligned with test results.

        public Fact(ITestOutputHelper output) => this.output = output;

        // --> A Fact is a unit test

        [Fact]
        public void AFactIsATest()
        {
            output.WriteLine("I am a Fact");
        }

        // --> Any test can be customized with a DisplayName

        [Fact(DisplayName="MyDisplayName")]
        public void ThisTestHasADisplayName()
        {
            output.WriteLine("I have my own display name");
        }

        // --> Skip will suspend the execution of the test
        // Better skip than commenting out the code!

        [Fact(Skip="To be implemented...")]
        public void ThisTestWontRun()
        {
            output.WriteLine("I wont be executed");     
        }

        // --> Test will fail if execution takes more
        // than the milliseconds specified as Timeout

        [Fact(Timeout=1000)]
        public void ThisTestMustTakeLessThanOneSecond()
        {
            output.WriteLine("I must terminate soon");
        }

        // Traits can be used to classify tests (or classes)
        // with a Key/Value. IDEs and command line can use
        // them for grouping.

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
