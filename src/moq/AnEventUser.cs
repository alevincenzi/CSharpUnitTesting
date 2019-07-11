using System;
using CSharpUnitTesting.moq.Sdk;

namespace CSharpUnitTesting.moq
{
    internal class AnEventUser
    {
        private int _value;

        public AnEventUser(IEventType @interface)
            => @interface.TheEvent += OnTheEvent;


        private void OnTheEvent(Object sender, AnEventArg e)
            => _value = e.Value;

        public int Received {
            get { return _value; }
        }
    }
}