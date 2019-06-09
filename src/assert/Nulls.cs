using Xunit;
using CSharpUnitTesting.assert.Sdk;

namespace CSharpUnitTesting.assert
{
    public class Nulls
    {
        [Fact]
        public void Null()
        {
            AClass parameter = null;

            Assert.Null(parameter);
        }

        [Fact]
        public void NotNull()
        {
            AClass parameter = new AClass(1);

            Assert.NotNull(parameter);
        }
    }
}