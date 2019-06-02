using System;
using Xunit;

namespace CSharpUnitTesting.xUnit
{
    public class Counter
    {
        static int _value = 0;

        public Counter() => _value++;

        public int Value { get { return _value; } }
    }

    public class _06_Construct_Dispose : IDisposable
    {
        Counter testCounter;

        public _06_Construct_Dispose()
        {
            testCounter = new Counter();
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