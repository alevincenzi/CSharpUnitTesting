using System;

namespace CSharpUnitTesting.moq.Sdk
{
    public interface IEventType
    {
        event EventHandler<AnEventArg> TheEvent;

        void TheOperation(int v);
    }
}
