using System.Collections;
using System.Collections.Generic;

namespace CSharpUnitTesting.xUnit.Sdk
{
    public class AnIntsEnumerator : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 0, 0 };
            yield return new object[] { 0, 1 };
            yield return new object[] { 0, 2 };           
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}