using System;
using Xunit;
using CSharpUnitTesting.xUnit.Sdk;

namespace CSharpUnitTesting.xUnit
{
    [Trait("Category", "SharingSetup")]
    [Trait("SharingLevel", "Individual")]
    public class Before_After
    {
        // How to run :
        // dotnet test --filter "Category=SharingSetup&SharingLevel=Individual" > output.txt
        // 

        [Fact]
        public void FirstTest()
        {
            Console.WriteLine($"First test is running");
        }

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