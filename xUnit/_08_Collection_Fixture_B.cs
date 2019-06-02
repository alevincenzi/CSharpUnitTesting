﻿using System;
using Xunit;

namespace CSharpUnitTesting.xUnit
{
    [Trait("Category", "SharingSetup")]
    [Trait("SharingLevel", "Collection")]
    [Collection("Counter Collection")]
    public class _08_Collection_Fixture_B
    {
        Counter testCounter;

        public _08_Collection_Fixture_B(Counter counter)
        {
            this.testCounter = counter;
        }

        [Fact]
        public void FirstTest()
        {
            Console.WriteLine($"First test is running with {testCounter.Value}");
        }

        [Fact]
        public void SecondTest()
        {
            Console.WriteLine($"Second test is running with {testCounter.Value}");
        }

        [Fact]
        public void ThirdTest()
        {
            Console.WriteLine($"Third test is running with {testCounter.Value}");
        }
    }
}