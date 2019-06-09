using System.Collections;
using System.Collections.Generic;

namespace CSharpUnitTesting.xUnit.Sdk
{
    public class AClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new AMemberData("Data_00") };
            yield return new object[] { new AMemberData("Data_01") };
            yield return new object[] { new AMemberData("Data_02") };           
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}