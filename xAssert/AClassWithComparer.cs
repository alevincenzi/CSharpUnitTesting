using System;

namespace CSharpUnitTesting.xAssert
{
    class AClassWithComparer : IComparable
    {
        private readonly int _value;

        public AClassWithComparer(int value) => _value = value;

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            
            var tmp = obj as AClassWithComparer;
            if (obj != null) 
                return _value.CompareTo(tmp._value);
            else
                throw new ArgumentException("Object is not AClassWithComparer");
        }
    }
}