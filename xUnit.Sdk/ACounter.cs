namespace CSharpUnitTesting.xUnit.Sdk
{
    public class ACounter
    {
        static int _value = 0;

        public ACounter() => _value++;

        public int Value { get { return _value; } }
    }
}