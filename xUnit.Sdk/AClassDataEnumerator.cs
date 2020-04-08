using System.Collections;
using System.Collections.Generic;

namespace CSharpUnitTesting.xUnit.Sdk
{
    public class AClassDataEnumerator : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new AClassData("Data_00") };
            yield return new object[] { new AClassData("Data_01") };
            yield return new object[] { new AClassData("Data_02") };           
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}