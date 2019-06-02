using System.Collections;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace CSharpUnitTesting.xUnit
{
    public class MyClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new MyMemberData("Data_00") };
            yield return new object[] { new MyMemberData("Data_01") };
            yield return new object[] { new MyMemberData("Data_02") };           
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [Trait("Category", "Theory")]
    public class _04_Theory_ClassData
    {
        private readonly ITestOutputHelper output;

        public _04_Theory_ClassData(ITestOutputHelper output) => this.output = output;

        [Theory]
        [ClassData(typeof(MyClassData))]
        public void UsingClassData(MyMemberData param)
        {
            output.WriteLine($"Using parameter {param.aProperty}");
        }
    }
}