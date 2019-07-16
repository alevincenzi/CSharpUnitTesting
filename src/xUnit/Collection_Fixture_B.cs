using System;
using Xunit;
using Xunit.Abstractions;
using CSharpUnitTesting.xUnit.Sdk;

// 08 - Sharing fixture among tests in different classes
//
// This is just a test class that shares the same fixture
// as Collection_Fixture_A

namespace CSharpUnitTesting.xUnit
{
    [Trait("Category", "SharingSetup")]
    [Trait("SharingLevel", "Collection")]
    [Collection("Counter Collection")]
    public class Collection_Fixture_B
    {
        private readonly ITestOutputHelper output;

        ACounter testCounter;

        public Collection_Fixture_B(ACounter counter)
        {
            this.testCounter = counter;
        }

        [Fact]
        public void FirstTest()
        {
            Console.WriteLine($"First test (B) is running with {testCounter.Value}");
        }

        [Fact]
        public void SecondTest()
        {
            Console.WriteLine($"Second test (B) is running with {testCounter.Value}");
        }

        [Fact]
        public void ThirdTest()
        {
            Console.WriteLine($"Third test (B) is running with {testCounter.Value}");
        }
    }
}
