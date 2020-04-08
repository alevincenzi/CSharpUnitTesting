namespace CSharpUnitTesting.moq.Sdk
{
    public class ACustomType
    {
        private int _value;

        public ACustomType(int value) => _value = value;

        public int Value {
            get { return _value; }
        }
    }
}
