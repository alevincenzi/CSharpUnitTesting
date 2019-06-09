using System;
using Xunit;
using Xunit.Abstractions;
using CSharpUnitTesting.xUnit.Sdk;

namespace CSharpUnitTesting.xUnit
{
    [Trait("Category", "Theory")]
    public class Theory_InlineData
    {
        private readonly ITestOutputHelper output;

        public Theory_InlineData(ITestOutputHelper output) => this.output = output;
        
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ATheoryIsaTestWithAParameter(int param)
        {
            output.WriteLine($"Using parameter {param}");
        }

        [Theory]
        [InlineData(1, "A parameter", typeof(int))]
        [InlineData(2, "Another parameter", typeof(string))]
        public void ATheoryIsaTestWithManyParameters(int param1, string param2, Type param3)
        {
            output.WriteLine($"Using parameters {param1}, {param2} and {param3}");
        }

        [Theory]
        [InlineData("an input string")]
        [InlineData("another input string")]
        public void Using_Strings(string param)
        {
            output.WriteLine($"Using string {param}");
        }

        [Theory]
        [InlineData(new int[] {1, 2, 3})]
        public void Using_ArrayOfConsts(int[] param)
        {
            output.WriteLine($"Using array of consts {param}");
        }

        [Theory]
        [InlineData(typeof(AInlineData))]
        public void Using_Types(Type param)
        {
            output.WriteLine($"Using type {param}");
        }

        [Theory]
        [InlineData(null)]
        public void Using_Null(Type param)
        {
            output.WriteLine($"Using null {param}");
        }
    }
}
