using System.Collections.Generic;

namespace CSharpUnitTesting.xUnit.Sdk
{
    public class AClassWithStatics
    {
        public static IEnumerable<object[]> StaticFunction()
        {
            yield return new object[] { new AClassData("Data_00") };
            yield return new object[] { new AClassData("Data_01") };
            yield return new object[] { new AClassData("Data_02") };
        }

        public static IEnumerable<object[]> StaticProperty
        {
            get
            {
                var aList = new List<object[]>(); 
                aList.Add(new object[] {
                    new AClassData("Data_10"),
                    new AClassData("Data_21"),
                    new AClassData("Data_32")
                });
                return aList;
            }
        }
    }
}