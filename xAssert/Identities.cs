using Xunit;

namespace CSharpUnitTesting.xAssert
{
    public class Identities
    {
        [Fact]
        public void Same()
        {
            var param1 = new AClass(1);
            var param2 = param1;

            Assert.Same(param1, param2);
        }

        [Fact]
        public void Same_Null()
        {
            AClass param1 = null;
            AClass param2 = null;

            Assert.Same(param1, param2);
        }

        [Fact]
        public void NotSame()
        {
            var param1 = new AClass(1);
            var param2 = new AClass(1);

            Assert.NotSame(param1, param2);
        }
    }
}
