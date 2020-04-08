namespace CSharpUnitTesting.moq.Sdk
{
    public class AnExceptionUser
    {
        private AnInterface _interface;

        public AnExceptionUser(AnInterface i)
            => _interface = i;

        public string HandleException()
        {
            string result;
            try
            {
                int tmp = _interface.AFunction(10);
                result = "OK";
            }
            catch 
            {
                result = "KO";
            }
            return result;
        }
    }
}