using System;
using System.Reflection;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace CSharpUnitTesting.xUnit.Sdk
{
    public class ABeforeAfterAttribute : BeforeAfterTestAttribute
    {
        public override void Before(MethodInfo methodUnderTest)
        {
            Console.WriteLine("Running before method " + methodUnderTest.Name);
        }

        public override void After(MethodInfo methodUnderTest)
        {
            Console.WriteLine("Running after method " + methodUnderTest.Name);
        }
    }
}