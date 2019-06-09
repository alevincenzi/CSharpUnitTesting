using System;

namespace CSharpUnitTesting.assert.Sdk
{
    class AClassWithEquals
    {
        private readonly int _value;

        public AClassWithEquals(int value) => _value = value;

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            var tmp = obj as AClassWithEquals;
            if ((Object)tmp == null)
                return false;

            return _value == tmp._value;
        }

        public bool Equals(AClassWithEquals obj)
        {
            if ((object)obj == null)
                return false;

            return _value == obj._value;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
}