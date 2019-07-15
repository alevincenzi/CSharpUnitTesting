using Xunit;
using Xunit.Abstractions;
using CSharpUnitTesting.xUnit.Sdk;

// 03 - Theory - Class Data
//
// Class data is a more flexible alternative to InlineData
// Instead of test data/parameters specified inline, it is
// possible to give the name of a class that implements
// the interface IEnumerable<object[]>.
//
// Since we return objects, any object is possible.

namespace CSharpUnitTesting.xUnit
{
    [Trait("Category", "Theory")]
    public class Theory_ClassData
    {
        private readonly ITestOutputHelper output;

        public Theory_ClassData(ITestOutputHelper output) => this.output = output;

        // There will be as many execution of this
        // following test as strings returned by the enumerator.
        // The signature of the test function must match
        // the type returned by the enumerator.

        [Theory]
        [ClassData(typeof(AStringEnumerator))]
        public void UsingString(string param)
        {
            output.WriteLine($"Using parameter {param}");
        }

        // Here the ClassData returns a series of arrays of int

        [Theory]
        [ClassData(typeof(AnIntArrayEnumerator))]
        public void UsingIntArray(int[] param)
        {
            output.WriteLine($"Using parameter {param[0]} and {param[1]}");
        }

        // --> Here there is an int value for each parameter!
        // The control of the runtime type retuned by the enumeration
        // (an array of objects) the signature of the theory is done
        // only at runtime!

        [Theory]
        [ClassData(typeof(AnIntsEnumerator))]
        public void UsingInts(int param0, int param1)
        {
            output.WriteLine($"Using parameter {param0} and {param1}");
        }

        [Theory]
        [ClassData(typeof(AClassDataEnumerator))]
        public void UsingAClassData(AClassData param)
        {
            output.WriteLine($"Using parameter {param.aProperty}");
        }
    }
}