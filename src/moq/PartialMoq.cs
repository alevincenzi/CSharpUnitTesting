using Xunit;
using Moq;
using Moq.Protected;
using CSharpUnitTesting.moq.Sdk;

// 06 - Partial Mock
// Mock a class rathen than an interface

namespace CSharpUnitTesting.moq
{
    public class PartialMoq
    {
        [Fact]
        void MockPublicVirtualFunction()
        {
            // Note that, since we're mocking a class
            // it is possible to pass parameters for construction

            var moq = new Mock<AClassType>(42);

            // If nothing is done, the moq object
            // will behave like a normal class
            // for all non virtual functions, but
            // returns default values for virtuals

            Assert.Equal(42, moq.Object.PublicReturnValue());
            Assert.Equal(0, moq.Object.VirtualReturnValue());

            // this will force the call to the
            // base method in the mocked object

            moq.CallBase = true;

            Assert.Equal(42, moq.Object.PublicReturnValue());
            Assert.Equal(42, moq.Object.VirtualReturnValue());

            moq.CallBase = false;

            // Despite being a class, it works like
            // setting the returns for an interface

            moq.Setup(x => x.VirtualReturnValue()).Returns(100);

            Assert.Equal(100, moq.Object.VirtualReturnValue());
        }

        [Fact]
        void MockProtectedFunction()
        {
            var moq = new Mock<AClassType>(42);

            moq.Protected()
               .Setup<int>("ProtectedReturnValue")
               .Returns(100);

            Assert.Equal(100, moq.Object.ReturnValue());
        }

        interface IProtectedMembers
        {
            int ProtectedReturnValue();
        }

        [Fact]
        void MockProtectedFunctionWithInterface()
        {
            var moq = new Mock<AClassType>(42);

            moq.Protected()
               .As<IProtectedMembers>()
               .Setup(x => x.ProtectedReturnValue()).Returns(100);

            Assert.Equal(100, moq.Object.ReturnValue());
        }
    }
}