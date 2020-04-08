using Xunit;
using Xunit.Abstractions;
using CSharpUnitTesting.xUnit.Sdk;

// 07a - Sharing fixture among tests in the same class
//
// It is possible to inject a fixture that is build only
// once and shared for all tests in the same test class.
//
// The fixture must be a class, and 
//
// * The test class must implement the interface IClassFixture<Type>.
// * The constructor mus have a parameter of type Type
//
// Here ACounter is built only once and injected into the constructor.

namespace CSharpUnitTesting.xUnit
{
    [Trait("Category", "SharingSetup")]
    [Trait("SharingLevel", "Class")]
    public class Class_Fixture : IClassFixture<ACounter>
    {
        private readonly ITestOutputHelper output;

        ACounter testCounter;

        // Here we must add a parameter to receive
        // the fixture and save its reference.
        public Class_Fixture(ITestOutputHelper output, ACounter counter)
        {
            this.output = output;
            this.testCounter = counter;
        }
        
        // The three tests simply print the counter to prove that
        // is is constructed only once. The property Value
        // will will alwas be 1.

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