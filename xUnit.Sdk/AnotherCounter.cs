namespace CSharpUnitTesting.xUnit.Sdk
{
    public class AnotherCounter
    {
        static int _value = 0;

        public AnotherCounter() => _value++;

        public int Value { get { return _value; } }
    }
}