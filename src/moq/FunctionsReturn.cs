using Xunit;
using Moq;
using CSharpUnitTesting.moq.Sdk;

namespace CSharpUnitTesting.moq
{
    public class FunctionsReturn
    {
        [Fact]
        public void ReturnValue_BaseType()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.Setup(x => x.ABaseFunctionWithoutParameters()).Returns(42);
            Assert.Equal<int>(42, sut.CallABaseFunctionWithoutParameters());
        }

        [Fact]
        public void ReturnValue_CustomType()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.Setup(x => x.ACustomFunctionWithoutParameters()).Returns(new ACustomType(42));
            Assert.Equal<int>(42, sut.CallACustomFunctionWithoutParameters().Value);
        }

        [Fact]
        public void Default_BaseType()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            Assert.Equal<int>(0, sut.CallABaseFunctionWithoutParameters());
        }

        [Fact]
        public void Default_CustomType()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            Assert.Null(sut.CallACustomFunctionWithoutParameters());
        }

        [Fact]
        public void Custom_BaseDefault()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.SetReturnsDefault<int>(42);

            Assert.Equal<int>(42, sut.CallABaseFunctionWithoutParameters());
        }

        [Fact]
        public void Custom_NullCustom()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.Setup(x => x.ACustomFunctionWithoutParameters()).Returns<ACustomType>(null);

            Assert.Null(sut.CallACustomFunctionWithoutParameters());
        }

        [Fact]
        public void WorksTwice()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.Setup(x => x.ABaseFunctionWithoutParameters()).Returns(42);

            Assert.Equal<int>(42, sut.CallABaseFunctionWithoutParameters());
            Assert.Equal<int>(42, sut.CallABaseFunctionWithoutParameters());
        }

        [Fact]
        public void Interchanging()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.Setup(x => x.ABaseFunctionWithoutParameters()).Returns(42);
            Assert.Equal<int>(42, sut.CallABaseFunctionWithoutParameters());

            moq.Setup(x => x.ABaseFunctionWithoutParameters()).Returns(52);
            Assert.Equal<int>(52, sut.CallABaseFunctionWithoutParameters());
        }

        [Fact]
        public void Reset()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.Setup(x => x.ABaseFunctionWithoutParameters()).Returns(42);
            Assert.Equal<int>(42, sut.CallABaseFunctionWithoutParameters());

            moq.Reset();
            Assert.Equal<int>(0, sut.CallABaseFunctionWithoutParameters());
        }

        [Fact]
        public void LocalReference()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            int theReturn = 52;

            moq.Setup(x => x.ABaseFunctionWithoutParameters()).Returns(() => theReturn);
            Assert.Equal<int>(52, sut.CallABaseFunctionWithoutParameters());
        }
    }
}