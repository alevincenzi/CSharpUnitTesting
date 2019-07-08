namespace CSharpUnitTesting.moq.Sdk
{
    public class AnInterfaceUser
    {
        private AnInterface _interface;

        public AnInterfaceUser(AnInterface i)
            => _interface = i;

        public int CallBaseFunction()
            => _interface.ABaseFunction();

        public int CallAFunction(int value)
            => _interface.AFunction(value);

        public int CallAFunctionTwiceWithSame(int value)
        {
            return _interface.AFunction(value) + _interface.AFunction(value);
        }

        public int CallAFunctionTwiceWithDifferent(int value)
        {
            return _interface.AFunction(value+1) + _interface.AFunction(value+2);
        }
    }
}