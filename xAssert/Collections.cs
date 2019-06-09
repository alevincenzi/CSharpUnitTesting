using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Sdk;

namespace CSharpUnitTesting.xAssert
{
    public class Collections
    {
        // Warning xUnit2011
        // --> Use Assert.Empty(aCollection)
        // Assert.Collection(new aCollection());

        [Fact]
        public void Collection()
        {
            Assert.Collection(new int[]{ 0, 1, 2 },
                item => Assert.Equal(0, item),
                item => Assert.Equal(1, item),
                item => Assert.Equal(2, item)
            );
        }

        [Fact]
        public void Collection_ThrowsException_WhenCountMismatch()
        {
            Assert.Throws<CollectionException>(
                () => Assert.Collection(new int[]{ 0, 1, 2 },
                    item => Assert.Equal(0, item),
                    item => Assert.Equal(1, item)
                )
            );
        }

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

        [Fact]
        public void Contains()
        {
            Assert.Contains(6, new int[] {0, 2, 4, 6, 8});
            Assert.Contains(2, new List<int>() {0, 1, 2, 3, 4});
            Assert.Contains('x', "xxx");
        }

        [Fact]
        public void Contains_WithType()
        {
            Assert.Contains<int>(6, new int[] {0, 2, 4, 6, 8});
            Assert.Contains<int>(2, new List<int>() {0, 1, 2, 3, 4});
            Assert.Contains<char>('x', "xxx");
        }

        [Fact]
        public void Contains_ThrowsException_WhenNotFound()
        {
            Assert.Throws<ContainsException>(
                () => Assert.Contains(10, new int[] {0, 2, 4, 6, 8})
            );
        }

        [Fact]
        public void Contains_WithComparer()
        {
            var collection = new List<AClass>();
            collection.Add(new AClass(1));
            collection.Add(new AClass(2));
            collection.Add(new AClass(3));

            Assert.Contains(new AClass(2), collection, new AClassEqualityComparer());
        }

        [Fact]
        public void Contains_WithPredicate()
        {
            var collection = new List<AClass>();
            collection.Add(new AClass(1));
            collection.Add(new AClass(2));
            collection.Add(new AClass(3));

            Assert.Contains(collection, item => item.Value % 2 == 0);
        }

        [Fact]
        public void DoesNotContain()
        {
            Assert.DoesNotContain(10, new int[] {0, 2, 4, 6, 8});
            Assert.DoesNotContain(5, new List<int>() {0, 1, 2, 3, 4});
            Assert.DoesNotContain('y', "xxx");
        }

        [Fact]
        public void DoesNotContain_WithType()
        {
            Assert.DoesNotContain<int>(10, new int[] {0, 2, 4, 6, 8});
            Assert.DoesNotContain<int>(5, new List<int>() {0, 1, 2, 3, 4});
            Assert.DoesNotContain<char>('y', "xxx");
        }

        [Fact]
        public void DoesNotContain_ThrowsException_WhenFound()
        {
            Assert.Throws<DoesNotContainException>(
                () => Assert.DoesNotContain(6, new int[] {0, 2, 4, 6, 8})
            );
        }

        [Fact]
        public void DoesNotContain_WithComparer()
        {
            var collection = new List<AClass>();
            collection.Add(new AClass(1));
            collection.Add(new AClass(2));
            collection.Add(new AClass(3));

            Assert.DoesNotContain(new AClass(4), collection, new AClassEqualityComparer());
        }

        [Fact]
        public void DoesNotContain_WithPredicate()
        {
            var collection = new List<AClass>();
            collection.Add(new AClass(1));
            collection.Add(new AClass(3));
            collection.Add(new AClass(5));

            Assert.DoesNotContain(collection, item => item.Value % 2 == 0);
        }

        [Fact]
        public void Contains_KeyInDictionary()
        {
            var dictionary = (IDictionary<int, string>) new Dictionary<int, string>()
            {
                [0] = "0",
                [2] = "2",
                [4] = "4"
            };

            var value = Assert.Contains(2, dictionary);
            Assert.Equal("2", value);
        }

        [Fact]
        public void Contains_KeyInDictionary_WithType()
        {
            var dictionary = (IDictionary<int, string>) new Dictionary<int, string>()
            {
                [0] = "0",
                [2] = "2",
                [4] = "4"
            };

            var value = Assert.Contains<int, string>(2, dictionary);
            Assert.Equal("2", value);
        }

        [Fact]
        public void Contains_ThrowsException_WhenKeyNotFound()
        {
            var dictionary = (IDictionary<int, string>) new Dictionary<int, string>()
            {
                [0] = "0",
                [2] = "2",
                [4] = "4"
            };

            Assert.Throws<ContainsException>(
                () => Assert.Contains(6, dictionary)
            );
        }

        [Fact]
        public void DoesNotContain_KeyInDictionary()
        {
            var dictionary = (IDictionary<int, string>) new Dictionary<int, string>()
            {
                [0] = "0",
                [2] = "2",
                [4] = "4"
            };

            Assert.DoesNotContain(6, dictionary);
        }

        [Fact]
        public void DoesNotContain_KeyInDictionary_WithType()
        {
            var dictionary = (IDictionary<int, string>) new Dictionary<int, string>()
            {
                [0] = "0",
                [2] = "2",
                [4] = "4"
            };

            Assert.DoesNotContain<int, string>(6, dictionary);
        }

        [Fact]
        public void DoesNotContain_ThrowsException_WhenKeyFound()
        {
            var dictionary = (IDictionary<int, string>) new Dictionary<int, string>()
            {
                [0] = "0",
                [2] = "2",
                [4] = "4"
            };

            Assert.Throws<DoesNotContainException>(
                () => Assert.DoesNotContain(2, dictionary)
            );
        }

        [Fact]
        public void Equal()
        {
            Assert.Equal(
                new int[] {0, 2, 4, 6, 8},
                new int[] {0, 2, 4, 6, 8});
            Assert.Equal(
                new List<int>() {0, 1, 2, 3, 4},
                new List<int>() {0, 1, 2, 3, 4}
            );
            Assert.Equal(
                new List<AClassWithEquals>() {
                    new AClassWithEquals(0), new AClassWithEquals(1), new AClassWithEquals(2)
                },
                new List<AClassWithEquals>() {
                    new AClassWithEquals(0), new AClassWithEquals(1), new AClassWithEquals(2)
                }
            );
        }

        [Fact]
        public void Equal_ThrowsException_WhenNotEquals()
        {
            Assert.Throws<EqualException>(
                () => Assert.Equal(
                    new int[] {0, 2, 4},
                    new int[] {0, 2, 4, 6, 8})
            );
        }

        [Fact]
        public void Equal_ThrowsException_WhenNotSameOrder()
        {
            Assert.Throws<EqualException>(
                () => Assert.Equal(
                    new int[] {0, 2, 4, 6, 8},
                    new int[] {0, 4, 2, 8, 6})
            );
            Assert.Throws<EqualException>(
                () => Assert.Equal(
                    new List<int>() {0, 1, 2, 3, 4},
                    new List<int>() {4, 3, 2, 1, 0})
            );
            Assert.Throws<EqualException>(
                () => Assert.Equal(
                    new List<AClassWithEquals>() {
                        new AClassWithEquals(0), new AClassWithEquals(1), new AClassWithEquals(2)
                    },
                    new List<AClassWithEquals>() {
                        new AClassWithEquals(2), new AClassWithEquals(1), new AClassWithEquals(0)
                    })
            );
        }

        [Fact]
        public void Equal_SameReference()
        {
            var expected = new int[] {0, 2, 4, 6, 8};
            var actual = expected;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Equal_NestedIntArray()
        {
            Assert.Equal(
                new int[][] {new []{0, 1, 2}, new []{3, 4, 5}, new []{6, 7, 8}},
                new int[][] {new []{0, 1, 2}, new []{3, 4, 5}, new []{6, 7, 8}});
        }

        [Fact]
        public void Equal_WithType()
        {
            Assert.Equal<int>(
                new int[] {0, 2, 4, 6, 8},
                new int[] {0, 2, 4, 6, 8});
            Assert.Equal<int>(
                new List<int>() {0, 1, 2, 3, 4},
                new List<int>() {0, 1, 2, 3, 4}
            );
            Assert.Equal<AClassWithEquals>(
                new List<AClassWithEquals>() {
                    new AClassWithEquals(0), new AClassWithEquals(1), new AClassWithEquals(2)
                },
                new List<AClassWithEquals>() {
                    new AClassWithEquals(0), new AClassWithEquals(1), new AClassWithEquals(2)
                }
            );
        }

        [Fact]
        public void Equal_WithComparer()
        {
            Assert.Equal(
                new List<AClass>() {
                    new AClass(0), new AClass(1), new AClass(2)
                },
                new List<AClass>() {
                    new AClass(0), new AClass(1), new AClass(2)
                },
                new AClassEqualityComparer()
            );
        }

        [Fact]
        public void NotEqual()
        {
            Assert.NotEqual(
                new int[] {0, 2, 4},
                new int[] {0, 2, 4, 6, 8});
            Assert.NotEqual(
                new List<int>() {0, 1, 2},
                new List<int>() {0, 1, 2, 3, 4}
            );
            Assert.NotEqual(
                new List<AClassWithEquals>() {
                    new AClassWithEquals(0), new AClassWithEquals(1), new AClassWithEquals(2)
                },
                new List<AClassWithEquals>() {
                    new AClassWithEquals(3), new AClassWithEquals(4), new AClassWithEquals(5)
                }
            );
        }

        [Fact]
        public void NotEqual_ThrowsException_WhenEquals()
        {
            Assert.Throws<NotEqualException>(
                () => Assert.NotEqual(
                    new int[] {0, 2, 4, 6, 8},
                    new int[] {0, 2, 4, 6, 8})
            );
        }
        
        [Fact]
        public void NotEqual_DifferentOrder()
        {
            Assert.NotEqual(
                new int[] {0, 2, 4, 6, 8},
                new int[] {0, 4, 2, 8, 6}
            );
            Assert.NotEqual(
                new List<int>() {0, 1, 2, 3, 4},
                new List<int>() {4, 3, 2, 1, 0}
            );
            Assert.NotEqual(
                new List<AClassWithEquals>() {
                    new AClassWithEquals(0), new AClassWithEquals(1), new AClassWithEquals(2)
                },
                new List<AClassWithEquals>() {
                    new AClassWithEquals(2), new AClassWithEquals(1), new AClassWithEquals(0)
                }
            );
        }

        [Fact]
        public void NotEqual_NestedIntArray()
        {
            Assert.NotEqual(
                new int[][] {new []{0, 1, 2}, new []{3, 4, 5}, new []{6, 7, 8}},
                new int[][] {new []{0, 1, 8}, new []{3, 4, 5}, new []{6, 7, 2}});
        }

        [Fact]
        public void NotEqual_WithType()
        {
            Assert.NotEqual<int>(
                new int[] {0, 2, 4},
                new int[] {0, 2, 4, 6, 8});
            Assert.NotEqual<int>(
                new List<int>() {0, 1, 2},
                new List<int>() {0, 1, 2, 3, 4}
            );
            Assert.NotEqual<AClassWithEquals>(
                new List<AClassWithEquals>() {
                    new AClassWithEquals(0), new AClassWithEquals(1), new AClassWithEquals(2)
                },
                new List<AClassWithEquals>() {
                    new AClassWithEquals(3), new AClassWithEquals(4), new AClassWithEquals(5)
                }
            );
        }

        [Fact]
        public void NotEqual_WithComparer()
        {
            Assert.NotEqual(
                new List<AClass>() {
                    new AClass(0), new AClass(1), new AClass(2)
                },
                new List<AClass>() {
                    new AClass(3), new AClass(4), new AClass(5)
                },
                new AClassEqualityComparer()
            );
        }
    }
}