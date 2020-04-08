using Xunit;
using Xunit.Abstractions;
using CSharpUnitTesting.xUnit.Sdk;

// 07b - Sharing fixture among tests in the same class
//
// It is possible to inject more than one fixture!

namespace CSharpUnitTesting.xUnit
{
    [Trait("Category", "SharingSetup")]
    [Trait("SharingLevel", "Class")]
    public class Class_Fixtures : IClassFixture<ACounter>, IClassFixture<AnotherCounter>  
    {
        private readonly ITestOutputHelper output;

        ACounter testCounter1;
        AnotherCounter testCounter2;

        // Here we must add parameters to receive
        // the fixtures and save their references.
        public Class_Fixtures(ITestOutputHelper output, ACounter counter1, AnotherCounter counter2)
        {
            this.output = output;
            this.testCounter1 = counter1;
            this.testCounter2 = counter2;
        }
        
        [Fact]
        public void FirstTest()
        {
            output.WriteLine($"First test is running with {testCounter1.Value} and {testCounter2.Value}");
        }

        [Fact]
        public void SecondTest()
        {
            output.WriteLine($"Second test is running with {testCounter1.Value} and {testCounter2.Value}");
        }

        [Fact]
        public void ThirdTest()
        {
            output.WriteLine($"Third test is running with {testCounter1.Value} and {testCounter2.Value}");
        }
    }
}