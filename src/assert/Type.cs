using Xunit;
using Xunit.Sdk;

namespace CSharpUnitTesting.assert
{
    class ABase {};
    class ADerived : ABase {};

    public class Type
    {
        // Warning xUnit2007
        // --> Use Assert.IsType<Type>(reference)
        // Assert.IsType(Type, reference);

        // Warning xUnit2007
        // --> Use Assert.IsType<Type>(reference)
        // Assert.IsType(Type, reference);

        // Warning xUnit2007
        // --> Use Assert.IsAssignableFrom<Type>(reference)
        // Assert.IsAssignableFrom(Type, reference);

        [Fact]
        public void IsType_SameType()
        {
            Assert.IsType<string>("string");
            Assert.IsType<ABase>(new ABase());
            Assert.IsType<ADerived>(new ADerived());
        }

        [Fact]
        public void IsType_ThrowsException_WhenDerivedType()
        {
            Assert.Throws<IsTypeException>(
                () => Assert.IsType<ABase>(new ADerived())
            );
        }

        [Fact]
        public void IsType_ThrowsException_WhenReferenceIsNull()
        {
            string reference = null;

            Assert.Throws<IsTypeException>(
                () => Assert.IsType<string>(reference)
            );
        }

        [Fact]
        public void IsNotType_DifferentType()
        {
            Assert.IsNotType<string>('a');
            Assert.IsNotType<ABase>(new ADerived());
            Assert.IsNotType<ADerived>(new ABase());
        }

        [Fact]
        public void IsNotType_ThrowsException_WhenSameType()
        {
            Assert.Throws<IsNotTypeException>(
                () => Assert.IsNotType<ABase>(new ABase())
            );
        }

        [Fact]
        public void IsNotType_DoesNotThrowException_WhenReferenceIsNull()
        {
            string reference = null;
            Assert.IsNotType<string>(reference);
        }

        [Fact]
        public void IsAssignableFrom_SameType()
        {
            Assert.IsAssignableFrom<string>("string");
            Assert.IsAssignableFrom<ABase>(new ABase());
            Assert.IsAssignableFrom<ADerived>(new ADerived());
        }

        [Fact]
        public void IsAssignableFrom_DerivedType()
        {
            Assert.IsAssignableFrom<ABase>(new ADerived());
        }

        [Fact]
        public void IsAssignableFrom_ThrowsException_WhenNotDerivedType()
        {
            Assert.Throws<IsAssignableFromException>(
                () => Assert.IsAssignableFrom<ADerived>(new ABase())
            );
        }

        [Fact]
        public void IsAssignableFrom_ThrowsException_WhenReferenceIsNull()
        {
            string reference = null;

            Assert.Throws<IsAssignableFromException>(
                () => Assert.IsAssignableFrom<string>(reference)
            );
        }
    }
}