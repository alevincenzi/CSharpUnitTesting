using System;

namespace CSharpUnitTesting.xAssert
{
    class BaseEventArgs : EventArgs
    {
        public int IValue;

        public BaseEventArgs(int value)
            => IValue = value;
    }

    class DerivedEventArgs : BaseEventArgs
    {
        public string SValue;

        public DerivedEventArgs(int iValue, string sValue) : base(iValue)
            => SValue = sValue; 
    }

    class AClassWithEvents
    {
        public void Raise(BaseEventArgs args)
        {   
            // ...
            if (args != null)
                OnEvent(args);
        }

        protected void OnEvent(BaseEventArgs e)
            => AnEvent.Invoke(this, e);

        public event EventHandler<BaseEventArgs> AnEvent;
    }
}