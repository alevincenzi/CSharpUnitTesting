using Xunit;
using Moq;
using CSharpUnitTesting.moq.Sdk;

namespace CSharpUnitTesting.moq
{
    public class FunctionsReturn
    {
        [Fact]
        public void BaseType()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.Setup(x => x.ABaseFunction()).Returns(42);
            Assert.Equal<int>(42, sut.Call_ABaseFunction());
        }

        [Fact]
        public void CustomType()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.Setup(x => x.ACustomFunction()).Returns(new ACustomType(42));
            Assert.Equal<int>(42, sut.Call_ACustomFunction().Value);
        }

        [Fact]
        public void BaseType_Default()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            Assert.Equal<int>(0, sut.Call_ABaseFunction());
        }

        [Fact]
        public void CustomType_Default()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            Assert.Null(sut.Call_ACustomFunction());
        }

        [Fact]
        public void BaseType_SetDefault()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.SetReturnsDefault<int>(42);

            Assert.Equal<int>(42, sut.Call_ABaseFunction());
        }

        [Fact]
        public void CustomType_Null()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.Setup(x => x.ACustomFunction()).Returns<ACustomType>(null);

            Assert.Null(sut.Call_ACustomFunction());
        }

        [Fact]
        public void WorksTwice()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.Setup(x => x.ABaseFunction()).Returns(42);

            Assert.Equal<int>(42, sut.Call_ABaseFunction());
            Assert.Equal<int>(42, sut.Call_ABaseFunction());
        }

        [Fact]
        public void Interchanging()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.Setup(x => x.ABaseFunction()).Returns(42);
            Assert.Equal<int>(42, sut.Call_ABaseFunction());

            moq.Setup(x => x.ABaseFunction()).Returns(52);
            Assert.Equal<int>(52, sut.Call_ABaseFunction());
        }

        [Fact]
        public void Reset()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.Setup(x => x.ABaseFunction()).Returns(42);
            Assert.Equal<int>(42, sut.Call_ABaseFunction());

            moq.Reset();
            Assert.Equal<int>(0, sut.Call_ABaseFunction());
        }

        [Fact]
        public void UseLocalReference()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            int theReturn = 52;

            moq.Setup(x => x.ABaseFunction()).Returns(() => theReturn);
            Assert.Equal<int>(52, sut.Call_ABaseFunction());
        }
    }
}