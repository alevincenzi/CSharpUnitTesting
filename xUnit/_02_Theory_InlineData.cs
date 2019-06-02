using System;
using Xunit;

namespace CSharpUnitTesting.xUnit
{
    public class MyInlineData
    {
        public string aProperty { get; }

        public MyInlineData(string aValue) => aProperty = aValue;
    }

    public class _02_Theory_InlineData
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ATheoryIsaTestWithAParameter(int param)
        {
            Console.WriteLine($"Using parameter {param}");
        }

        [Theory]
        [InlineData(1, "A parameter", typeof(int))]
        [InlineData(2, "Another parameter", typeof(string))]
        public void ATheoryIsaTestWithManyParameters(int param1, string param2, Type param3)
        {
            Console.WriteLine($"Using parameters {param1}, {param2} and {param3}");
        }

        [Theory]
        [InlineData("an input string")]
        [InlineData("another input string")]
        public void Using_Strings(string param)
        {
            Console.WriteLine($"Using string {param}");
        }

        [Theory]
        [InlineData(new int[] {1, 2, 3})]
        public void Using_ArrayOfConsts(int[] param)
        {
            Console.WriteLine($"Using array of consts {param}");
        }

        [Theory]
        [InlineData(typeof(MyInlineData))]
        public void Using_Types(Type param)
        {
            Console.WriteLine($"Using type {param}");
        }
    }
}
