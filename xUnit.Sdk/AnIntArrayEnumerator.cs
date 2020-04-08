using System.Collections;
using System.Collections.Generic;

namespace CSharpUnitTesting.xUnit.Sdk
{
    public class AnIntArrayEnumerator : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new int[] {0, 0} };
            yield return new object[] { new int[] {0, 1} };
            yield return new object[] { new int[] {0, 2} };           
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}