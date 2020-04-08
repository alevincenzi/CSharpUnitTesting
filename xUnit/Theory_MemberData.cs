using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using CSharpUnitTesting.xUnit.Sdk;

// 04 - Theory - Member Data
//
// MemberData works the same way as ClassData but
// relies on static function or properties instead of enumerator classes.
// Static functions or properties must return an IEnumerable<object[]>.
// They can belong to any external class or to the test class itself.

namespace CSharpUnitTesting.xUnit
{
    [Trait("Category", "Theory")]
    public class Theory_MemberData
    {
        private readonly ITestOutputHelper output;

        public Theory_MemberData(ITestOutputHelper output) => this.output = output;

        // --> This is just a static function of the test class
        // Note that here we yeld values

        public static IEnumerable<object[]> StaticTestClassFunction()
        {
            yield return new object[] { "Data_20" };
            yield return new object[] { "Data_21" };
            yield return new object[] { "Data_22" };
        }

        // --> Again a function ... but with an extra parameter!

        public static IEnumerable<object[]> StaticTestClassFunctionWithAParameter(int qty)
        {
            var aList = new List<object[]>(); 
            aList.Add(new object[] { "Data_30" });
            aList.Add(new object[] { "Data_31" });
            aList.Add(new object[] { "Data_32" });
            return aList.Take(qty);
        }

        // --> This is just a static property of the test class
        // returning a custom class rather than a constant string as above
        // Any way, we build and return an entire list rather than yelding values.

        public static IEnumerable<object[]> StaticTestClassProperty
        {
            get
            {
                var aList = new List<object[]>(); 
                aList.Add(new object[] {
                    new AClassData("Data_40"),
                    new AClassData("Data_41"),
                    new AClassData("Data_42")
                });
                return aList;
            }
        }

        // This theory points to the static function of the external class AClassWithStatics.
        // The parameter MemberType must be used otherwise the static function StaticFunction 
        // must be found in the current test class.

        // Here the static function return a custom object per iteration/unit test.

        [Theory]
        [MemberData(nameof(AClassWithStatics.StaticFunction), MemberType=typeof(AClassWithStatics))]
        public void Using_StaticFunction_ExternalClass(AClassData param)
        {
            output.WriteLine($"Using parameter {param.aProperty}");
        }

        // Here the theory points to a static property.
        // It returns three custom classes per test.

        [Theory]
        [MemberData(nameof(AClassWithStatics.StaticProperty), MemberType=typeof(AClassWithStatics))]
        public void Using_StaticProperty_ExternalClass(AClassData param1, AClassData param2, AClassData param3)
        {
            output.WriteLine($"Using parameters {param1.aProperty}, {param2.aProperty} and {param3.aProperty}");
        }

        // As the test above, but on the staitc function of the current test class.
        // MemberType is not needed!

        [Theory]
        [MemberData(nameof(StaticTestClassFunction))]
        public void Using_StaticFunction_TestClass(string param)
        {
            output.WriteLine($"Using parameter {param}");
        }

        // Here we pass the static fuction an extra parameter,
        // that can help selecting and returning the list of strings

        [Theory]
        [MemberData(nameof(StaticTestClassFunctionWithAParameter), 1)]
        public void Using_StaticFunction_TestClass_WithAParameter(string param)
        {
            output.WriteLine($"Using parameter {param}");
        }

        // Again, but on a static property of the test class

        [Theory]
        [MemberData(nameof(StaticTestClassProperty))]
        public void Using_StaticProperty_TestClass(AClassData param1, AClassData param2, AClassData param3)
        {
            output.WriteLine($"Using parameters {param1.aProperty}, {param2.aProperty} and {param3.aProperty}");
        }
    }
}
