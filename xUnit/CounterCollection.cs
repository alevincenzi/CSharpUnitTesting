using System;
using Xunit;

namespace CSharpUnitTesting.xUnit
{
    [CollectionDefinition("Counter Collection", DisableParallelization = true)]
    public class CounterCollection : ICollectionFixture<Counter> { }
}