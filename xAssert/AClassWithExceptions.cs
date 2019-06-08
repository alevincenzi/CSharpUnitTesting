using System;

namespace CSharpUnitTesting.xAssert
{
    class BaseException : Exception
    {
        public BaseException(string message) : base(message) {}
    }

    class DerivedException : BaseException
    {
        public DerivedException(string message) : base(message) {}
    }

    class AClassWithExceptions
    {
        public void Throw(BaseException args)
        {   
            // ...
            if (args != null)
                throw args;
        }
    }
}