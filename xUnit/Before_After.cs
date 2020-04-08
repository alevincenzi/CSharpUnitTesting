using System;
using Xunit;
using CSharpUnitTesting.xUnit.Sdk;

// 09 - Before and After a test
//
// It is possible to specify actions that areexecuted
// before or after given unit tests. It is needed to define a
// class that
//
// * implements BeforeAfterTestAttribute
// * Override Before and After (one or both)
// * Use the class name as attribute for individual tests

namespace CSharpUnitTesting.xUnit
{
    [Trait("Category", "SharingSetup")]
    [Trait("SharingLevel", "Individual")]
    public class Before_After
    {
        // How to run :
        // dotnet test --filter "Category=SharingSetup&SharingLevel=Individual" > output.txt

        [Fact]
        public void FirstTest()
        {
            Console.WriteLine($"First test is running");
        }

        // Only this test will have the custom Before and After
        // called. Note that the class ABeforeAfter is called/build
        // Without parameters. No way to inject a value.

        [Fact]
        [ABeforeAfter]
        public void SecondTest()
        {
            Console.WriteLine($"Second test is running");
        }

        [Fact]
        public void ThirdTest()
        {
            Console.WriteLine($"Third test is running");
        }        
    }
}