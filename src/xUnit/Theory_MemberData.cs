using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using CSharpUnitTesting.xUnit.Sdk;

namespace CSharpUnitTesting.xUnit
{
    [Trait("Category", "Theory")]
    public class Theory_MemberData
    {
        private readonly ITestOutputHelper output;

        public Theory_MemberData(ITestOutputHelper output) => this.output = output;

        public static IEnumerable<object[]> StaticTestClassMember()
        {
            yield return new object[] { new AMemberData("Data_20") };
            yield return new object[] { new AMemberData("Data_21") };
            yield return new object[] { new AMemberData("Data_22") };
        }

        public static IEnumerable<object[]> StaticTestClassMemberWithAParameter(int qty)
        {
            var aList = new List<object[]>(); 
            aList.Add(new object[] { new AMemberData("Data_30") });
            aList.Add(new object[] { new AMemberData("Data_31") });
            aList.Add(new object[] { new AMemberData("Data_32") });
            return aList.Take(qty);
        }

        public static IEnumerable<object[]> StaticTestClassProperty
        {
            get
            {
                var aList = new List<object[]>(); 
                aList.Add(new object[] {
                    new AMemberData("Data_40"),
                    new AMemberData("Data_41"),
                    new AMemberData("Data_42")
                });
                return aList;
            }
        }

        [Theory]
        [MemberData(nameof(AMemberData.StaticMember), MemberType=typeof(AMemberData))]
        public void Using_StaticMember_ExternalClass(AMemberData param)
        {
            output.WriteLine($"Using parameter {param.aProperty}");
        }

        [Theory]
        [MemberData(nameof(AMemberData.StaticProperty), MemberType=typeof(AMemberData))]
        public void Using_StaticProperty_ExternalClass(AMemberData param1, AMemberData param2, AMemberData param3)
        {
            output.WriteLine($"Using parameters {param1.aProperty}, {param2.aProperty} and {param3.aProperty}");
        }

        [Theory]
        [MemberData(nameof(StaticTestClassMember))]
        public void Using_StaticMember_TestClass(AMemberData param)
        {
            output.WriteLine($"Using parameter {param.aProperty}");
        }

        [Theory]
        [MemberData(nameof(StaticTestClassMemberWithAParameter), 1)]
        public void Using_StaticMember_TestClass_WithAParameter(AMemberData param)
        {
            output.WriteLine($"Using parameter {param.aProperty}");
        }

        [Theory]
        [MemberData(nameof(StaticTestClassProperty))]
        public void Using_StaticProperty_TestClass(AMemberData param1, AMemberData param2, AMemberData param3)
        {
            output.WriteLine($"Using parameters {param1.aProperty}, {param2.aProperty} and {param3.aProperty}");
        }
    }
}
