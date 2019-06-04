using System.Collections.Generic;

namespace CSharpUnitTesting.xAssert
{
    class AClass
    {
        private readonly int _value;

        public int Value { get { return _value; }}

        public AClass(int value) => _value = value;
    }

    class AClassComparer : IEqualityComparer<AClass>
    {
        public bool Equals(AClass x, AClass y)
        {
            return x.Value == y.Value;
        }

        public int GetHashCode(AClass obj)
        {
            return obj.GetHashCode();
        }
    }
}