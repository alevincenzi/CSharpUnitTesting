using Xunit;
using Moq;
using CSharpUnitTesting.moq.Sdk;

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

            moq.Setup(x => x.AFunctionWithBaseOutParameter(out outValue));

            Assert.Equal<int>(42, sut.CallAFunctionWithBaseOutParameter());
        }

        [Fact]
        public void Out_CustomType()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            var outValue = new ACustomType(42);

            moq.Setup(x => x.AFunctionWithCustomOutParameter(out outValue));

            Assert.Equal<int>(42, sut.CallAFunctionWithCustomOutParameter());
        }

        delegate void BaseRefCallback(ref int param);

        [Fact]
        public void Ref_BaseType()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.Setup(x => x.AFunctionWithBaseRefParameter(ref It.Ref<int>.IsAny))
               .Callback(new BaseRefCallback((ref int param) => param = 42));

            Assert.Equal<int>(42, sut.CallAFunctionWithBaseRefParameter());
        }

        delegate void CustomRefCallback(ref ACustomType param);

        [Fact]
        public void Ref_CustomType()
        {
            var moq = new Mock<AnInterface>();
            var sut = new AFunctionClass(moq.Object);

            moq.Setup(x => x.AFunctionWithCustomRefParameter(ref It.Ref<ACustomType>.IsAny))
               .Callback(new CustomRefCallback((ref ACustomType param) => param = new ACustomType(42)));

            Assert.Equal<int>(42, sut.CallAFunctionWithCustomRefParameter());
        }
    }
}