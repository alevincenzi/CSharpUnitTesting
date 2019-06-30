using Xunit;
using Moq;
using CSharpUnitTesting.moq.Sdk;

namespace CSharpUnitTesting.moq
{
    public class FunctionsParameter
    {
        [Fact]
        public void Parameter()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.Setup(x => x.AFunctionWithParameter(42)).Returns(52);
            moq.Setup(x => x.AFunctionWithParameter(43)).Returns(53);
            moq.Setup(x => x.AFunctionWithParameter(44)).Returns(54);

            Assert.Equal<int>(52, sut.CallAFunctionWithParameter(42));
            Assert.Equal<int>(53, sut.CallAFunctionWithParameter(43));
            Assert.Equal<int>(54, sut.CallAFunctionWithParameter(44));
        }

        [Fact]
        public void Default()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            Assert.Equal<int>(0, sut.CallAFunctionWithParameter(42));
        }

        [Fact]
        public void Any()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.Setup(x => x.AFunctionWithParameter(It.IsAny<int>())).Returns(42);

            Assert.Equal<int>(42, sut.CallAFunctionWithParameter(0));
            Assert.Equal<int>(42, sut.CallAFunctionWithParameter(42));
            Assert.Equal<int>(42, sut.CallAFunctionWithParameter(52));
        }

        [Fact]
        public void PostProcess()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.Setup(x => x.AFunctionWithParameter(It.IsAny<int>())).Returns((int x) => x + 1);

            Assert.Equal<int>(43, sut.CallAFunctionWithParameter(42));
        }
    }
}