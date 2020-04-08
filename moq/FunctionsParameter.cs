using System.Collections.Generic;
using Xunit;
using Moq;
using CSharpUnitTesting.moq.Sdk;

// 02 - State based testing
// Set up what functions returns w.r.t their prarameters

namespace CSharpUnitTesting.moq
{
    public class FunctionsParameter
    {
        [Fact]
        public void Parameter()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.Setup(x => x.AFunction(42)).Returns(52);
            moq.Setup(x => x.AFunction(43)).Returns(53);
            moq.Setup(x => x.AFunction(44)).Returns(54);

            Assert.Equal<int>(52, sut.Call_AFunction(42));
            Assert.Equal<int>(53, sut.Call_AFunction(43));
            Assert.Equal<int>(54, sut.Call_AFunction(44));
        }

        [Fact]
        public void Default()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.Setup(x => x.AFunction(42)).Returns(52);

            Assert.Equal<int>(52, sut.Call_AFunction(42));
            Assert.Equal<int>(0, sut.Call_AFunction(43));
        }

        [Fact]
        public void Any()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.Setup(x => x.AFunction(It.IsAny<int>())).Returns(42);

            Assert.Equal<int>(42, sut.Call_AFunction(0));
            Assert.Equal<int>(42, sut.Call_AFunction(42));
            Assert.Equal<int>(42, sut.Call_AFunction(52));
        }

        [Fact]
        public void InRange()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.Setup(x => x.AFunction(It.IsInRange(10, 20, Range.Inclusive))).Returns(42);

            Assert.Equal<int>(42, sut.Call_AFunction(10));
            Assert.Equal<int>(42, sut.Call_AFunction(11));
            Assert.Equal<int>( 0, sut.Call_AFunction(21));
        }

        [Fact]
        public void In()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            var values = new int[] { 10, 11, 12 };

            moq.Setup(x => x.AFunction(It.IsIn<int>(values))).Returns(42);

            Assert.Equal<int>(42, sut.Call_AFunction(10));
            Assert.Equal<int>(42, sut.Call_AFunction(11));
            Assert.Equal<int>( 0, sut.Call_AFunction(21));
        }

        [Fact]
        public void PostProcess()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.Setup(x => x.AFunction(It.IsAny<int>())).Returns((int x) => x + 1);

            Assert.Equal<int>(43, sut.Call_AFunction(42));
        }
    }
}