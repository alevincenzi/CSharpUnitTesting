namespace CSharpUnitTesting.xUnit
{
    public class Counter
    {
        static int _value = 0;

        public Counter() => _value++;

        public int Value { get { return _value; } }
    }
}