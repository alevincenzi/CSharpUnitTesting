using System;
using Xunit;

namespace CSharpUnitTesting.xUnit
{
    [Trait("Category", "SharingSetup")]
    [Trait("SharingLevel", "Test")]
    public class _06_Construct_Dispose : IDisposable
    {
        Counter testCounter;

        public _06_Construct_Dispose()
        {
            this.testCounter = new Counter();
        }

        public void Dispose()
        {
            // If Needed ....
        }

        [Fact]
        public void FirstTest()
        {
            Console.WriteLine($"First test is running with {testCounter.Value}");
        }

        [Fact]
        public void SecondTest()
        {
            Console.WriteLine($"Second test is running with {testCounter.Value}");
        }

        [Fact]
        public void ThirdTest()
        {
            Console.WriteLine($"Third test is running with {testCounter.Value}");
        }
    }
}