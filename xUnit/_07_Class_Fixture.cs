using System;
using Xunit;

namespace CSharpUnitTesting.xUnit
{
    public class _07_Class_Fixture : IClassFixture<Counter>  
    {
        Counter testCounter;

        public _07_Class_Fixture(Counter counter)
        {
            this.testCounter = counter;
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