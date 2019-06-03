using Xunit;

namespace CSharpUnitTesting.xAssert
{
    public class Identity
    {
        class IdentityClass
        {
            private readonly int _value;

            public IdentityClass(int value) => _value = value;

        }

        [Fact]
        public void Same()
        {
            var param1 = new IdentityClass(1);
            var param2 = param1;

            Assert.Same(param1, param2);
        }

        [Fact]
        public void Same_Null()
        {
            IdentityClass param1 = null;
            IdentityClass param2 = null;

            Assert.Same(param1, param2);
        }

        [Fact]
        public void NotSame()
        {
            var param1 = new IdentityClass(1);
            var param2 = new IdentityClass(1);

            Assert.NotSame(param1, param2);
        }
    }
}
