using System;
using Xunit;
using Xunit.Sdk;
using CSharpUnitTesting.assert.Sdk;

namespace CSharpUnitTesting.assert
{
    public class Equalities
    {
        // Warning xUnit2004
        // --> Use Assert.True(expression)
        // Assert.Equal<bool>(true, bActual);

        // Warning xUnit2006
        // --> Use Assert.Equal("x", "x")
        // Assert.Equal<string>("x", "x");

        // Warning xUnit2004
        // --> Use Assert.True(expression)
        // Assert.NotEqual<bool>(true, bActual);

        // Warning xUnit2006
        // --> Use Assert.NotEqual("x", "y")
        // Assert.NotEqual<string>("x", "x");

        [Fact]
        public void Equal_Double()
        {
            Assert.Equal(0.3d, 0.1d + 0.2d, 1);
            Assert.Throws<EqualException>(
                () => Assert.Equal<double>(0.3d, 0.1d + 0.2d)
            );
        }

        [Fact]
        public void NotEqual_Double()
        {
            Assert.NotEqual(0.3d, 0.1d + 0.2d);
            Assert.NotEqual<double>(0.3d, 0.1d + 0.2d);
        }

        [Fact]
        public void Equal_Decimal()
        {
            Assert.Equal(0.30m, 0.10m + 0.20m, 0);
            Assert.Equal<decimal>(0.30m, 0.3m);
        }

        [Fact]
        public void NotEqual_Decimal()
        {
            Assert.NotEqual(0.3m, 0.11m + 0.20m);
            Assert.NotEqual<decimal>(0.30m, 0.31m);
        }

        [Fact]
        public void Equal_DateTime()
        {
            Assert.Equal(
                new DateTime(2000, 12, 25, 12, 30, 10),
                new DateTime(2000, 12, 25, 12, 30, 11),
                                new TimeSpan(0,  0,  1)
            );
            Assert.Equal<DateTime>(
                new DateTime(2000, 12, 25, 12, 30, 10),
                new DateTime(2000, 12, 25, 12, 30, 10)
            );
        }

        [Fact]
        public void Equal_SameReference()
        {
            var reference = new AClass(1);
            Assert.Equal(reference, reference);
            Assert.Equal<AClass>(reference, reference);
        }

        [Fact]
        public void NotEqual_ThrowsException_WhenSameReference()
        {
            var reference = new AClass(1);
            Assert.Throws<NotEqualException>(
                () => Assert.NotEqual(reference, reference)
            );
            Assert.Throws<NotEqualException>(
                () => Assert.NotEqual<AClass>(reference, reference)
            );
        }

        [Fact]
        public void Equal_ClassWithoutEqual_ThrowsException()
        {
            Assert.Throws<EqualException>(
                () => Assert.Equal(new AClass(1), new AClass(1))
            );
            Assert.Throws<EqualException>(
                () => Assert.Equal<AClass>(new AClass(1), new AClass(1))
            );
        }

        [Fact]
        public void NotEqual_ClassWithoutEqual()
        {
            Assert.NotEqual(new AClass(1), new AClass(1));
            Assert.NotEqual<AClass>(new AClass(1), new AClass(1));
        }

        [Fact]
        public void Equal_ClassWithEqual()
        {
            Assert.Equal(
                new AClassWithEquals(1), new AClassWithEquals(1)
            );
            Assert.Equal<AClassWithEquals>(
                new AClassWithEquals(1), new AClassWithEquals(1)
            );
        }

        [Fact]
        public void NotEqual_ClassWithEqual()
        {
            Assert.NotEqual(
                new AClassWithEquals(1), new AClassWithEquals(2)
            );
            Assert.NotEqual<AClassWithEquals>(
                new AClassWithEquals(1), new AClassWithEquals(2)
            );
        }

        [Fact]
        public void Equal_EqualityComparer()
        {
            Assert.Equal(
                new AClass(1),
                new AClass(1),
                new AClassEqualityComparer()
            );
            Assert.Equal<AClass>(
                new AClass(1),
                new AClass(1),
                new AClassEqualityComparer()
            );
        }

        [Fact]
        public void NotEqual_EqualityComparer()
        {
            Assert.NotEqual(
                new AClass(1),
                new AClass(2),
                new AClassEqualityComparer()
            );
            Assert.NotEqual<AClass>(
                new AClass(1),
                new AClass(2),
                new AClassEqualityComparer()
            );
        }

        [Fact]
        public void Equal_Struct_SameReference()
        {
            AStruct reference = new AStruct(1, 2);
            Assert.Equal(reference, reference);
            Assert.Equal<AStruct>(reference, reference);
        }

        [Fact]
        public void Equal_Struct_SameFields()
        {
            Assert.Equal(new AStruct(1, 2), new AStruct(1, 2));
            Assert.Equal<AStruct>(new AStruct(1, 2), new AStruct(1, 2));
        }

        [Fact]
        public void NotEqual_Struct_DifferentFields()
        {
            Assert.NotEqual(new AStruct(1, 2), new AStruct(1, 3));
            Assert.NotEqual<AStruct>(new AStruct(1, 2), new AStruct(1, 3));
        }
    }
}