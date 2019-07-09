using Xunit;
using Moq;
using CSharpUnitTesting.moq.Sdk;

// 01 - State based testing
// Set up what functions returns

namespace CSharpUnitTesting.moq
{
    public class FunctionsReturn
    {
        [Fact]
        public void BaseType()
        {
            // Strict behaviour --> Throws errors if sut uses any
            // function/property in the mock without a
            // corresponding setup --> Defaults not accepted!
            var moq = new Mock<AnInterface>(MockBehavior.Strict);
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
        public void BaseType_DefaultLoose()
        {
            // Loose behaviour (default), does not throw exceptions if
            // setup of any mock function called by sut is not specified
            // --> Default values are accepted/tolerated
            var moq = new Mock<AnInterface>(MockBehavior.Loose);
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