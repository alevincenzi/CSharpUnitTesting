using System;
using Xunit;
using Xunit.Sdk;

namespace CSharpUnitTesting.xAssert
{
    public class Equality
    {
        [Fact]
        public void Equal_Double()
        {
            Assert.Equal(0.3d, 0.1d + 0.2d, 1);
        }

        [Fact]
        public void NotEqual_Double()
        {
            Assert.NotEqual(0.3d, 0.1d + 0.2d);
        }

        [Fact]
        public void Equal_Decimal()
        {
            Assert.Equal(0.30m, 0.10m + 0.20m, 0);
        }

        [Fact]
        public void NotEqual_Decimal()
        {
            Assert.NotEqual(0.3m, 0.11m + 0.20m);
        }

        [Fact]
        public void Equal_DateTime()
        {
            Assert.Equal(
                new DateTime(2000, 12, 25, 12, 30, 10),
                new DateTime(2000, 12, 25, 12, 30, 11),
                               new TimeSpan(0,  0,  1));
        }

        [Fact]
        public void Equal_Type_Base()
        {
            Assert.Equal<int>(1, 1);
            Assert.Equal<double>(1.0d, 1.0d);
            Assert.Equal<char>('x', 'x');

            // Warning xUnit2004
            // --> Use Assert.True(expression)
            // Assert.Equal<bool>(true, bActual);

            // Warning xUnit2006
            // --> Use Assert.Equal("x", "x")
            // Assert.Equal<string>("x", "x");
        }

        [Fact]
        public void NotEqual_Type_Base()
        {
            Assert.NotEqual<int>(0, 1);
            Assert.NotEqual<double>(0.0d, 1.0d);
            Assert.NotEqual<char>('x', 'y');

            // Warning xUnit2004
            // --> Use Assert.True(expression)
            // Assert.NotEqual<bool>(true, bActual);

            // Warning xUnit2006
            // --> Use Assert.NotEqual("x", "y")
            // Assert.NotEqual<string>("x", "x");
        }

        [Fact]
        public void Equal_Type_Custom()
        {
            var ref1 = new AClass(1);
            var ref2 = new AClass(1);
            var ref3 = new AClassWithEquals(1);
            var ref4 = new AClassWithEquals(1);
            var ref5 = new AClassWithEquals(2);

            Assert.Equal<AClass>(ref1, ref1);
            
            Assert.Throws<EqualException>(
                () => Assert.Equal<AClass>(ref1, ref2)
            );
            
            Assert.Equal<AClassWithEquals>(ref3, ref4);

            Assert.Throws<EqualException>(
                () => Assert.Equal<AClassWithEquals>(ref4, ref5)
            );
        }

        [Fact]
        public void Equal_Type_Custom_WithEqualityComparer()
        {
            var ref1 = new AClass(1);
            var ref2 = new AClass(1);

            Assert.Equal<AClass>(ref1, ref2, new AClassEqualityComparer());
        }

        [Fact]
        public void Equal_Struct()
        {
            AStruct ref1 = new AStruct(1, 2);
            AStruct ref2 = new AStruct(1, 2);

            Assert.Equal<AStruct>(ref1, ref1);
            Assert.Equal<AStruct>(ref1, ref2);
        }

        [Fact]
        public void NotEqual_Type_Custom()
        {
            var ref1 = new AClass(1);
            var ref2 = new AClass(1);
            var ref3 = new AClassWithEquals(1);
            var ref4 = new AClassWithEquals(2);

            Assert.NotEqual<AClass>(ref1, ref2);
            Assert.NotEqual<AClassWithEquals>(ref3, ref4);
        }

        [Fact]
        public void NotEqual_Type_Custom_WithEqualityComparer()
        {
            var ref1 = new AClass(1);
            var ref2 = new AClass(2);

            Assert.NotEqual<AClass>(ref1, ref2, new AClassEqualityComparer());
        }

        [Fact]
        public void NotEqual_Struct()
        {
            AStruct ref1 = new AStruct(1, 2);
            AStruct ref2 = new AStruct(3, 4);

            Assert.NotEqual<AStruct>(ref1, ref2);
        }
    }
}