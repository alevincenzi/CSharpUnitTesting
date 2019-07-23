using Xunit;
using Moq;
using CSharpUnitTesting.moq.Sdk;

// 03a - State based testing
// Set up what functions returns w.r.t out and ref prarameters

namespace CSharpUnitTesting.moq
{
    public class FunctionsRefOut
    {
        [Fact]
        public void Out_BaseType()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            int outValue = 42;

            moq.Setup(x => x.AFunctionBaseOut(out outValue));

            Assert.Equal<int>(42, sut.Call_AFunctionBaseOut());
        }

        [Fact]
        public void Out_CustomType()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            var outValue = new ACustomType(42);

            moq.Setup(x => x.AFunctionCustomOut(out outValue));

            Assert.Equal<int>(42, sut.Call_AFunctionCustomOut());
        }

        delegate void BaseRefCallback(ref int param);

        [Fact]
        public void Ref_BaseType()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.Setup(x => x.AFunctionBaseRef(ref It.Ref<int>.IsAny))
               .Callback(new BaseRefCallback((ref int param) => param = 42));

            Assert.Equal<int>(42, sut.Call_AFunctionBaseRef());
        }

        delegate void CustomRefCallback(ref ACustomType param);

        [Fact]
        public void Ref_CustomType()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.Setup(x => x.AFunctionCustomRef(ref It.Ref<ACustomType>.IsAny))
               .Callback(new CustomRefCallback((ref ACustomType param) => param = new ACustomType(42)));

            Assert.Equal<int>(42, sut.Call_AFunctionCustomRef());
        }
    }
}