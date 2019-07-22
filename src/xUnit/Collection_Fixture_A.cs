using System;
using Xunit;
using Xunit.Abstractions;
using CSharpUnitTesting.xUnit.Sdk;

// 07 - Sharing fixture among tests in different classes
//
// It is possible to inject a fixture that is build only
// once and shared for all tests in different test class.
//
// The fixture must be a class, and
//
// * The test class must have the attribute "Collection"
// * There must be a class with the attribute "CollectionDefinition"
// * The class must implement the interface IClassFixture<Type>
// * The two attributes must be configured with the same name.
// * All classes must add the type to their constructor
//
// Here ACounter is built only once and injected as a dependency
// to the constructor of all the test classes in CollectionFixture_A.
// and CollectionFixture_B

namespace CSharpUnitTesting.xUnit
{
    [Trait("Category", "SharingSetup")]
    [Trait("SharingLevel", "Collection")]
    [Collection("Counter Collection")]
    public class Collection_Fixture_A
    {
        ACounter testCounter;

        // Here we must add a parameter to receive
        // the fixture and save its reference.
        public Collection_Fixture_A(ACounter counter)
        {
            this.testCounter = counter;
        }

        // The three (+three) tests simply print the counter to prove that
        // is is constructed only once. The property Value
        // will will alwas be 1.

        // Run with:
        // dotnet test --filter "Category=SharingSetup&SharingLevel=Collection" > output.txt
        //
        // Tests will run in series but with a random order
        
        [Fact]
        public void FirstTest()
        {
            Console.WriteLine($"First test (A) is running with {testCounter.Value}");
        }

        [Fact]
        public void SecondTest()
        {
            Console.WriteLine($"Second test (A) is running with {testCounter.Value}");
        }

        [Fact]
        public void ThirdTest()
        {
            Console.WriteLine($"Third test (A) is running with {testCounter.Value}");
        }
    }
}
