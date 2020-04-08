using Xunit;

// This class defines a fixture that can be
// shared by tests in different classes.

// It is possible to disable parallelization for
// all tests in classes belonging to the same collection

namespace CSharpUnitTesting.xUnit.Sdk
{
    [CollectionDefinition("Counter Collection", DisableParallelization = true)]
    public class CounterCollection : ICollectionFixture<ACounter> { }
}