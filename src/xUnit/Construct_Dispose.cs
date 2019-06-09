using System;
using Xunit;
using Xunit.Abstractions;
using CSharpUnitTesting.xUnit.Sdk;

namespace CSharpUnitTesting.xUnit
{
    [Trait("Category", "SharingSetup")]
    [Trait("SharingLevel", "Test")]
    public class Construct_Dispose : IDisposable
    {
        private readonly ITestOutputHelper output;

        ACounter testCounter;

        public Construct_Dispose(ITestOutputHelper output)
        {
            this.output = output;
            this.testCounter = new ACounter();
        }

        public void Dispose()
        {
            // If Needed ....
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