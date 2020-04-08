namespace CSharpUnitTesting.moq.Sdk
{
    public class APropertyUser
    {
        private IPropertyType _user;
        private int _testReference;

        public APropertyUser(IPropertyType user, int reference)
        {
            _user = user;
            _testReference = reference;
        }

        public bool CompareBase()
            => _user.BaseTypeProperty == _testReference;

        public bool CompareCustom()
            => _user.CustomTypeProperty.Property == _testReference;

        public void Add(int value)
            => _user.Counter += value;
    }
}