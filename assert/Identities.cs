using Xunit;
using CSharpUnitTesting.assert.Sdk;

// 07 Identities
//
// Testa on references ... do they point to the same object?

namespace CSharpUnitTesting.assert
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

        [Fact]
        public void NotSame_ClassWithEqual()
        {
            var param1 = new AClassWithEquals(1);
            var param2 = new AClassWithEquals(1);

            Assert.NotSame(param1, param2);
        }

    }
}
