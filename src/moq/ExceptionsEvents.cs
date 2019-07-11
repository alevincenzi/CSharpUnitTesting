using System;
using Xunit;
using Moq;
using CSharpUnitTesting.moq.Sdk;

// 05 - Setup exceptions and events

namespace CSharpUnitTesting.moq
{
    public class Exceptions
    {
        [Fact]
        void Exception()
        {
            var mock = new Mock<AnInterface>();
            var sut = new AnExceptionUser(mock.Object);

            mock.Setup(x => x.AFunction(It.IsAny<int>())).Throws<InvalidOperationException>();

            Assert.Equal("KO", sut.HandleException());
        }

        [Fact]
        void CustomException()
        {
            var mock = new Mock<AnInterface>();
            var sut = new AnExceptionUser(mock.Object);

            mock.Setup(x => x.AFunction(It.IsAny<int>())).Throws(new InvalidOperationException("A Message"));

            Assert.Equal("KO", sut.HandleException());
        }

        [Fact]
        void NoException()
        {
            var mock = new Mock<AnInterface>();
            var sut = new AnExceptionUser(mock.Object);

            Assert.Equal("OK", sut.HandleException());
        }

        [Fact]
        void RaiseEventManually()
        {
            var mock = new Mock<IEventType>();
            var sut = new AnEventUser(mock.Object);

            mock.Raise(x => x.TheEvent += null, new AnEventArg() { Value = 42 });

            Assert.Equal<int>(42, sut.Received);
        }

        [Fact]
        void RaiseEventOnFunctionCall()
        {
            var mock = new Mock<IEventType>();
            var sut = new AnEventUser(mock.Object);

            int value = 42;

            mock.Setup(x => x.TheOperation(value))
                .Raises(x => x.TheEvent += null, new AnEventArg() { Value = value });

            // This is just to trigger the call on a function
            // Sould be placed inside a second sut
            mock.Object.TheOperation(value);

            Assert.Equal<int>(value, sut.Received);
        }
    }
}