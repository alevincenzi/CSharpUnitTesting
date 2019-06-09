using System.Collections.Generic;

namespace CSharpUnitTesting.sdk
{
    public class AMemberData
    {
        public string aProperty { get; }

        public AMemberData(string aValue) => aProperty = aValue;

        public static IEnumerable<object[]> StaticMember()
        {
            yield return new object[] { new AMemberData("Data_00") };
            yield return new object[] { new AMemberData("Data_01") };
            yield return new object[] { new AMemberData("Data_02") };
        }

        public static IEnumerable<object[]> StaticProperty
        {
            get
            {
                var aList = new List<object[]>(); 
                aList.Add(new object[] {
                    new AMemberData("Data_10"),
                    new AMemberData("Data_21"),
                    new AMemberData("Data_32")
                });
                return aList;
            }
        }
    }
}