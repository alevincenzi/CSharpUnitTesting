using System;
using Xunit;
using Xunit.Abstractions;
using CSharpUnitTesting.xUnit.Sdk;

// 06 - Basic set up and tear down
//
// "Set up" is implemented with the constructor and
// "Tear down" with the dispose(). The test class 
//  is constructed and diposed for every fact or theory.

// To have a Tear Down, implement the IDisposable interface.

namespace CSharpUnitTesting.xUnit
{
    [Trait("Category", "SharingSetup")]
    [Trait("SharingLevel", "Test")]
    public class Construct_Dispose : IDisposable
    {
        private readonly ITestOutputHelper output;

        ACounter testCounter;

        // This is the setup, run before every test.
        // ACounter is a class with a static member that
        // counts how many time is it constructed.
        public Construct_Dispose(ITestOutputHelper output)
        {
            this.output = output;
            this.testCounter = new ACounter();
        }

        public void Dispose()
        {
            // If Needed ...
            // Here the garbage collector helps out :)
        }

        // The three tests simply print the counter to prove that
        // it is constructed before every call. The property Value
        // will increase every time, from 1 to 3.

        [Fact]
        public void FirstTest()
        {
            output.WriteLine($"First test is running with {testCounter.Value}");
        }

        [Fact]
        public void SecondTest()
        {
            output.WriteLine($"Second test is running with {testCounter.Value}");
        }

        [Fact]
        public void ThirdTest()
        {
            output.WriteLine($"Third test is running with {testCounter.Value}");
        }
    }
}