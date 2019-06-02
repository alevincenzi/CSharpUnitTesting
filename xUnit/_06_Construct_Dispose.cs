using System;
using Xunit;
using Xunit.Abstractions;

namespace CSharpUnitTesting.xUnit
{
    [Trait("Category", "SharingSetup")]
    [Trait("SharingLevel", "Test")]
    public class _06_Construct_Dispose : IDisposable
    {
        private readonly ITestOutputHelper output;

        Counter testCounter;

        public _06_Construct_Dispose(ITestOutputHelper output)
        {
            this.output = output;
            this.testCounter = new Counter();
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