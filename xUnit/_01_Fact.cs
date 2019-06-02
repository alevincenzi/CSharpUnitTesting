using System;
using Xunit;

namespace CSharpUnitTesting.xUnit
{
    public class _01_Fact
    {
        [Fact]
        public void AFactIsATest()
        {
            Console.WriteLine("I am a Fact");
        }

        [Fact(DisplayName="MyDisplayName")]
        public void ThisTestHasADisplayName()
        {
            Console.WriteLine("I have my own display name");
        }

        [Fact(Skip="To be implemented...")]
        public void ThisTestWontRun()
        {
            Console.WriteLine("I wont be executed");     
        }

        [Fact(Timeout=1000)]
        public void ThisTestMustTakeLessThanOneSecond()
        {
            Console.WriteLine("I must terminate soon");
        }

        [Trait("MyCategory", "ACategory")]
        [Fact(Timeout=1000)]
        public void ThisTestHasACategory()
        {
            Console.WriteLine("I must terminate soon");
        }

    }
}
