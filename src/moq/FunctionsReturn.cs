using Xunit;
using Moq;
using CSharpUnitTesting.moq.Sdk;

namespace CSharpUnitTesting.moq
{
    public class FunctionsReturn
    {
        [Fact]
        public void ReturnValue()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.Setup(x => x.AFunctionWithoutParameters()).Returns(42);
            Assert.Equal<int>(42, sut.CallAFunctionWithoutParameters());
        }

        [Fact]
        public void Default()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            Assert.Equal<int>(0, sut.CallAFunctionWithoutParameters());
        }

        [Fact]
        public void CustomDefault()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.SetReturnsDefault<int>(42);

            Assert.Equal<int>(42, sut.CallAFunctionWithoutParameters());
        }

        [Fact]
        public void WorksTwice()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.Setup(x => x.AFunctionWithoutParameters()).Returns(42);

            Assert.Equal<int>(42, sut.CallAFunctionWithoutParameters());
            Assert.Equal<int>(42, sut.CallAFunctionWithoutParameters());
        }

        [Fact]
        public void Interchanging()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.Setup(x => x.AFunctionWithoutParameters()).Returns(42);
            Assert.Equal<int>(42, sut.CallAFunctionWithoutParameters());

            moq.Setup(x => x.AFunctionWithoutParameters()).Returns(52);
            Assert.Equal<int>(52, sut.CallAFunctionWithoutParameters());
        }

        [Fact]
        public void Reset()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.Setup(x => x.AFunctionWithoutParameters()).Returns(42);
            Assert.Equal<int>(42, sut.CallAFunctionWithoutParameters());

            moq.Reset();
            Assert.Equal<int>(0, sut.CallAFunctionWithoutParameters());
        }

        [Fact]
        public void LocalReference()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            int theReturn = 52;

            moq.Setup(x => x.AFunctionWithoutParameters()).Returns(() => theReturn);
            Assert.Equal<int>(52, sut.CallAFunctionWithoutParameters());
        }
    }
}