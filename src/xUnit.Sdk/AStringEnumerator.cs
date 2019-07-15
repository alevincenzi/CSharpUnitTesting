using System.Collections;
using System.Collections.Generic;

namespace CSharpUnitTesting.xUnit.Sdk
{
    public class AStringEnumerator : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "Data_00" };
            yield return new object[] { "Data_01" };
            yield return new object[] { "Data_02" };           
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}