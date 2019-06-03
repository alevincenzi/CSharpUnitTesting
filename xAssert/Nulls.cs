using Xunit;

namespace CSharpUnitTesting.xAssert
{
    class NullsClass
    {
        private readonly int _value;

        public NullsClass(int value) => _value = value;
    }

    public class Nulls
    {
        [Fact]
        public void Null()
        {
            NullsClass parameter = null;

            Assert.Null(parameter);
        }

        [Fact]
        public void NotNull()
        {
            NullsClass parameter = new NullsClass(1);

            Assert.NotNull(parameter);
        }
    }
}