using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace CSharpUnitTesting.xUnit
{
    public class CustomDataAttribute : DataAttribute
    {
        private int _qty;
        private List<object[]> _aList; 

        public CustomDataAttribute(int qty)
        {
            _qty = qty;
            _aList = new List<object[]>(); 
            _aList.Add(new object[] { new MyMemberData("Data_00") });
            _aList.Add(new object[] { new MyMemberData("Data_01") });
            _aList.Add(new object[] { new MyMemberData("Data_02") });
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null)
                throw new ArgumentNullException(nameof(testMethod));

            return _aList.Take(_qty);            
        }
    }

    public class _05_Theory_CustomDataAttribute
    {
        [Theory]
        [CustomData(2)]
        public void UsingCustomDataAttribute(MyMemberData param)
        {
            Console.WriteLine($"Using parameter {param.aProperty}");
        }
    }
}