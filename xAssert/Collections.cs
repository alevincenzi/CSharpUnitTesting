using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Sdk;

namespace CSharpUnitTesting.xAssert
{
    public class Collections
    {
        [Fact]
        public void All()
        {
            Assert.All(new int[] {0, 2, 4, 6, 8}, x => Assert.Equal(0, x % 2));
            Assert.All(new List<int>() {0, 1, 2, 3, 4}, x => Assert.True(x < 5));
            Assert.All("xxx", x => Assert.Equal('x', x));
        }


        [Fact]
        public void All_WithType()
        {
            Assert.All<int>(new int[] {0, 2, 4, 6, 8}, x => Assert.Equal(0, x % 2));
            Assert.All<int>(new List<int>() {0, 1, 2, 3, 4}, x => Assert.True(x < 5));
            Assert.All<char>("xxx", x => Assert.Equal('x', x));
        }

        [Fact]
        public void All_ThrowsException_WhenAtLeastOneFails()
        {
            var ex = Assert.Throws<AllException>(
                () => Assert.All(new int[] {0, 2, 5, 6, 8}, x => Assert.Equal(0, x % 2))
            );

            Assert.Equal(1, ex.Failures.Count);
            Assert.IsType<EqualException>(ex.Failures[0]);
        }

        [Fact]
        public void All_ThrowsException_WhenOneElementIsNull()
        {
            var collection = new List<AClass>();
            collection.Add(new AClass(1));
            collection.Add(null);
            collection.Add(new AClass(1));

            var ex = Assert.Throws<AllException>(
                () => Assert.All(collection, x => Assert.Equal(1, x.Value))
            );

            Assert.Equal(1, ex.Failures.Count);
            Assert.IsType<NullReferenceException>(ex.Failures[0]);
        }

        [Fact]
        public void Single()
        {
            Assert.Single(new int[1] { 42 });
            Assert.Single(new List<int>() { 42 });
            Assert.Single("x");
        }

        [Fact]
        public void Single_WithType()
        {
            Assert.Single<int>(new int[1] { 42 });
            Assert.Single<int>(new List<int>() { 42 });
            Assert.Single<char>("x");
        }

        [Fact]
        public void Single_ReturnedValue()
        {
            Assert.Equal(42,
                Assert.Single(new int[1] { 42 }));
            Assert.Equal(42,
                Assert.Single(new List<int>() { 42 }));
            Assert.Equal('x',
                Assert.Single("x"));
        }

        [Fact]
        public void Single_ThrowsException_WhenEmptyOrHasMoreThanOne()
        {
            Assert.Throws<SingleException>(
                () => Assert.Single(new int[0])
            );
            Assert.Throws<SingleException>(
                () => Assert.Single("XX")
            );
        }

        [Fact]
        public void Single_WithExpectedValue()
        {
            Assert.Single(new int[] {0, 1, 2, 3, 4}, 4);
            Assert.Single("xxYxx", 'Y');
        }

        [Fact]
        public void Single_ThrowsException_WhenExpectedValueNotFound()
        {
            Assert.Throws<SingleException>(
                () => Assert.Single(new int[] {0, 1, 2, 3, 4}, 5)
            );
            Assert.Throws<SingleException>(
                () => Assert.Single("xxYxx", 'y')
            );
        }

        [Fact]
        public void Single_WithPredicate()
        {
            Assert.Equal(5,
                Assert.Single(new int[] {0, 2, 5, 6, 8}, x => x % 2 == 1));
            Assert.Equal('Y',
                Assert.Single("xxYxx", x => x == 'Y'));
        }

        [Fact]
        public void Single_ThrowsException_WhenPredicateNotFound()
        {
            Assert.Throws<SingleException>(
                () => Assert.Single(new int[] {0, 2, 4, 6, 8}, x => x % 2 == 1)
            );
        }

        [Fact]
        public void Single_ThrowsException_WhenPredicateFoundMoreThanOnce()
        {
            Assert.Throws<SingleException>(
                () => Assert.Single("xYxYxYx", x => x == 'Y')
            );
        }

        [Fact]
        public void Empty()
        {
            Assert.Empty(new int[0]);
            Assert.Empty(new List<int>());
            Assert.Empty("");
        }

        [Fact]
        public void NotEmpty()
        {
            Assert.NotEmpty(new int[] { 0, 1, 2});
            Assert.NotEmpty(new List<int>() {0, 1, 2});
            Assert.NotEmpty("xxx");
        }
    }
}