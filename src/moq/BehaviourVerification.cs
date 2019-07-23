using Xunit;
using Moq;
using CSharpUnitTesting.moq.Sdk;

// 03b - Behavoir based testing
// Verify that functions are called

namespace CSharpUnitTesting.moq
{
    public class BehaviourVerification
    {
        [Fact]
        void FunctionIsCalled()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AnInterfaceUser(moq.Object);

            var unused = sut.CallBaseFunction();

            moq.Verify(x => x.ABaseFunction());

            // This asserts that no other interaction
            // were done to the moq object, except the
            // one in the above "Verifiy"
            moq.VerifyNoOtherCalls();
        }

        [Fact]
        void FunctionIsCalledWithParameter()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AnInterfaceUser(moq.Object);

            var unused = sut.CallAFunction(42);

            moq.Verify(x => x.AFunction(42));
        }

        [Fact]
        void FunctionIsCalledWithAnyParameter()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AnInterfaceUser(moq.Object);

            var unused = sut.CallAFunction(42);

            moq.Verify(x => x.AFunction(It.IsAny<int>()));
        }

        [Fact]
        void FunctionIsCalledWithParameterInRange()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AnInterfaceUser(moq.Object);

            var unused = sut.CallAFunction(42);

            moq.Verify(x => x.AFunction(It.IsInRange<int>(41, 43, Range.Exclusive)));
        }

        [Fact]
        void FunctionIsCalledTwice()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AnInterfaceUser(moq.Object);

            var unused = sut.CallAFunctionTwiceWithSame(42);

            moq.Verify(x => x.AFunction(42), Times.Exactly(2));
        }

        [Fact]
        void FunctionIsCalledTwiceWithDifferentParameters()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AnInterfaceUser(moq.Object);

            var unused = sut.CallAFunctionTwiceWithDifferent(42);

            moq.Verify(x => x.AFunction(44));
            moq.Verify(x => x.AFunction(43));
            moq.VerifyNoOtherCalls();
        }

        [Fact]
        void PropertyIsGet()
        {
            var moq = new Mock<IPropertyType>();
            var sut = new APropertyUser(moq.Object, 42);

            var unused = sut.CompareBase();

            moq.VerifyGet(x => x.BaseTypeProperty, Times.Once);
        }

        [Fact]
        void PropertyIsSet()
        {
            var moq = new Mock<IPropertyType>();
            var sut = new APropertyUser(moq.Object, 42);

            sut.Add(10);

            moq.VerifySet(x => x.Counter = 10, Times.Once);
        }
    }
}