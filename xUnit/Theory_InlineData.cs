using System;
using Xunit;
using Xunit.Abstractions;
using CSharpUnitTesting.xUnit.Sdk;

// 02 - Theory - Const InlineData
//
// Theories are unit tests with a parameter.
// There will be as many execution of a theory as lines
// With the attribute InlineData. 

namespace CSharpUnitTesting.xUnit
{
    // Note the usage of Traits to classify
    // test classes as well into groups

    [Trait("Category", "Theory")]
    public class Theory_InlineData
    {
        private readonly ITestOutputHelper output;

        public Theory_InlineData(ITestOutputHelper output) => this.output = output;
        
        // --> This will execute a total of 3 unit tests.
        // Inline data can be constant (known at compile time) 
        // values as integers.

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ATheoryIsaTestWithAParameter(int param)
        {
            output.WriteLine($"Using parameter {param}");
        }

        // Here we inject strings

        [Theory]
        [InlineData("an input string")]
        [InlineData("another input string")]
        public void Using_Strings(string param)
        {
            output.WriteLine($"Using string {param}");
        }

        // Or arrays of integers

        [Theory]
        [InlineData(new int[] {1, 2, 3})]
        public void Using_ArrayOfConsts(int[] param)
        {
            output.WriteLine($"Using array of consts {param}");
        }

        // Or types (class names)

        [Theory]
        [InlineData(typeof(AInlineData))]
        public void Using_Types(Type param)
        {
            output.WriteLine($"Using type {param}");
        }

        // Nulls references as well! 

        [Theory]
        [InlineData(null)]
        public void Using_Null(Type param)
        {
            output.WriteLine($"Using null {param}");
        }

        // Inline data is indeed a tuple of values.
        // The type of each value must match, from left to right
        // the parameters of the function/test.

        [Theory]
        [InlineData(1, "A parameter", typeof(int))]
        [InlineData(2, "Another parameter", typeof(string))]
        public void ATheoryIsaTestWithManyParameters(int param1, string param2, Type param3)
        {
            output.WriteLine($"Using parameters {param1}, {param2} and {param3}");
        }
    }
}
