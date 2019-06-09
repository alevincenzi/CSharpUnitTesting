using System.Collections.Generic;

namespace CSharpUnitTesting.sdk
{
    class AClass
    {
        private readonly int _value;

        public int Value { get { return _value; }}

        public AClass(int value) => _value = value;
    }

    class AClassEqualityComparer : IEqualityComparer<AClass>
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

    class AClassComparer : IComparer<AClass>
    {
        public int Compare(AClass x, AClass y)
        {
            return x.Value.CompareTo(y.Value);
        }
    }
}