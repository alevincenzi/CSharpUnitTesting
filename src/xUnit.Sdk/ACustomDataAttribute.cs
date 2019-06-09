using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;

namespace CSharpUnitTesting.xUnit.Sdk
{
    public class ACustomDataAttribute : DataAttribute
    {
        private int _qty;
        private List<object[]> _aList; 

        public ACustomDataAttribute(int qty)
        {
            _qty = qty;
            _aList = new List<object[]>(); 
            _aList.Add(new object[] { new AMemberData("Data_00") });
            _aList.Add(new object[] { new AMemberData("Data_01") });
            _aList.Add(new object[] { new AMemberData("Data_02") });
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null)
                throw new ArgumentNullException(nameof(testMethod));

            return _aList.Take(_qty);            
        }
    }
}