using Xunit;
using CSharpUnitTesting.assert.Sdk;

// 05 Ranges
//
// Use comparer for non traditional types

namespace CSharpUnitTesting.assert
{
    public class Ranges
    {
        [Theory]
        [InlineData(42, 42,           42)]
        [InlineData(42, int.MinValue, 42)]
        [InlineData(42, 42,           int.MaxValue)]
        [InlineData(42, int.MinValue, int.MaxValue)]
        public void InRange_Int(int actual, int low, int high)
        {
            Assert.InRange(actual, low, high);
            Assert.InRange<int>(actual, low, high);
        }

        [Theory]
        [InlineData('e', 'e', 'e')]
        [InlineData('e', 'a', 'e')]
        [InlineData('e', 'e', 'z')]
        [InlineData('e', 'a', 'z')]
        public void InRange_Char(char actual, char low, char high)
        {
            Assert.InRange(actual, low, high);
            Assert.InRange<char>(actual, low, high);
        }

        [Theory]
        [InlineData("eee", "eee", "eee")]
        [InlineData("eee", "aaa", "eee")]
        [InlineData("eee", "eee", "zzz")]
        [InlineData("eee", "aaa", "zzz")]
        public void InRange_String(string actual, string low, string high)
        {
            Assert.InRange(actual, low, high);
            Assert.InRange<string>(actual, low, high);
        }

        [Fact]
        public void InRange_Type_Custom()
        {
            var ref1 = new AClassWithComparer(1);
            var ref2 = new AClassWithComparer(2);
            var ref3 = new AClassWithComparer(3);

            Assert.InRange(ref2, ref1, ref3);
            Assert.InRange<AClassWithComparer>(ref2, ref1, ref3);
        }

        [Fact]
        public void InRange_Type_Custom_WithComparer()
        {
            var ref1 = new AClass(1);
            var ref2 = new AClass(2);
            var ref3 = new AClass(3);

            Assert.InRange(ref2, ref1, ref3, new AClassComparer());
            Assert.InRange<AClass>(ref2, ref1, ref3, new AClassComparer());
        }

        [Fact]
        public void NotInRange_Type_Base()
        {
            Assert.NotInRange(42, 43, 45);
            Assert.NotInRange<int>(42, 43, 45);

            Assert.NotInRange('a', 'e', 'z');
            Assert.NotInRange<char>('a', 'e', 'z');

            Assert.NotInRange("aaa", "eee", "zzz");
            Assert.NotInRange<string>("aaa", "eee", "zzz");
        }

        [Fact]
        public void NotInRange_Type_Custom()
        {
            var ref1 = new AClassWithComparer(1);
            var ref2 = new AClassWithComparer(2);
            var ref3 = new AClassWithComparer(3);

            Assert.NotInRange(ref1, ref2, ref3);
            Assert.NotInRange<AClassWithComparer>(ref1, ref2, ref3);
        }

        [Fact]
        public void NotInRange_Type_Custom_WithComparer()
        {
            var ref1 = new AClass(1);
            var ref2 = new AClass(2);
            var ref3 = new AClass(3);

            Assert.NotInRange(ref1, ref2, ref3, new AClassComparer());
            Assert.NotInRange<AClass>(ref1, ref2, ref3, new AClassComparer());
        }
    }
}