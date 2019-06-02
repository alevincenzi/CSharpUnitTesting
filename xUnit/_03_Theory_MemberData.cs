using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CSharpUnitTesting.xUnit
{
    public class MyMemberData
    {
        public string aProperty { get; }

        public MyMemberData(string aValue) => aProperty = aValue;

        public static IEnumerable<object[]> StaticMember()
        {
            yield return new object[] { new MyMemberData("Data_00") };
            yield return new object[] { new MyMemberData("Data_01") };
            yield return new object[] { new MyMemberData("Data_02") };
        }

        public static IEnumerable<object[]> StaticProperty
        {
            get
            {
                var aList = new List<object[]>(); 
                aList.Add(new object[] {
                    new MyMemberData("Data_10"),
                    new MyMemberData("Data_21"),
                    new MyMemberData("Data_32")
                });
                return aList;
            }
        }
    }

    public class _03_Theory_MemberData
    {
        public static IEnumerable<object[]> StaticTestClassMember()
        {
            yield return new object[] { new MyMemberData("Data_20") };
            yield return new object[] { new MyMemberData("Data_21") };
            yield return new object[] { new MyMemberData("Data_22") };

        }

        public static IEnumerable<object[]> StaticTestClassMemberWithAParameter(int qty)
        {
            var aList = new List<object[]>(); 
            aList.Add(new object[] { new MyMemberData("Data_30") });
            aList.Add(new object[] { new MyMemberData("Data_31") });
            aList.Add(new object[] { new MyMemberData("Data_32") });
            return aList.Take(qty);
        }

        public static IEnumerable<object[]> StaticTestClassProperty
        {
            get
            {
                var aList = new List<object[]>(); 
                aList.Add(new object[] {
                    new MyMemberData("Data_40"),
                    new MyMemberData("Data_41"),
                    new MyMemberData("Data_42")
                });
                return aList;
            }
        }

        [Theory]
        [MemberData(nameof(MyMemberData.StaticMember), MemberType=typeof(MyMemberData))]
        public void Using_StaticMember_ExternalClass(MyMemberData param)
        {
            Console.WriteLine($"Using parameter {param.aProperty}");
        }

        [Theory]
        [MemberData(nameof(MyMemberData.StaticProperty), MemberType=typeof(MyMemberData))]
        public void Using_StaticProperty_ExternalClass(MyMemberData param1, MyMemberData param2, MyMemberData param3)
        {
            Console.WriteLine($"Using parameters {param1.aProperty}, {param2.aProperty} and {param3.aProperty}");
        }

        [Theory]
        [MemberData(nameof(StaticTestClassMember))]
        public void Using_StaticMember_TestClass(MyMemberData param)
        {
            Console.WriteLine($"Using parameter {param.aProperty}");
        }

        [Theory]
        [MemberData(nameof(StaticTestClassMemberWithAParameter), 1)]
        public void Using_StaticMember_TestClass_WithAParameter(MyMemberData param)
        {
            Console.WriteLine($"Using parameter {param.aProperty}");
        }

        [Theory]
        [MemberData(nameof(StaticTestClassProperty))]
        public void Using_StaticProperty_TestClass(MyMemberData param1, MyMemberData param2, MyMemberData param3)
        {
            Console.WriteLine($"Using parameters {param1.aProperty}, {param2.aProperty} and {param3.aProperty}");
        }
    }
}
