namespace CSharpUnitTesting.moq.Sdk
{
    public class AClassType
    {
        private int _value;

        public AClassType(int value) => _value = value;

        public int PublicReturnValue()
            => _value;

        public virtual int VirtualReturnValue()
            => _value;

        protected virtual int ProtectedReturnValue()
            => _value;

        public int ReturnValue()
            => ProtectedReturnValue();
    }
}
