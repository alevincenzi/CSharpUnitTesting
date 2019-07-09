using System;
using Xunit;
using Moq;
using CSharpUnitTesting.moq.Sdk;

// 05 - Setup exceptions

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

            Assert.Equal<string>("KO", sut.HandleException());
        }

        [Fact]
        void CustomException()
        {
            var mock = new Mock<AnInterface>();
            var sut = new AnExceptionUser(mock.Object);

            mock.Setup(x => x.AFunction(It.IsAny<int>())).Throws(new InvalidOperationException("A Message"));

            Assert.Equal<string>("KO", sut.HandleException());
        }

        [Fact]
        void NoException()
        {
            var mock = new Mock<AnInterface>();
            var sut = new AnExceptionUser(mock.Object);

            Assert.Equal<string>("OK", sut.HandleException());
        }
    }
}