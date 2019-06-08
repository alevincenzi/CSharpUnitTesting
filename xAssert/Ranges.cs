using Xunit;

namespace CSharpUnitTesting.xAssert
{
    public class Ranges
    {
        [Fact]
        public void InRange_Type_Base()
        {
            Assert.InRange<int>(42, 42, 42);
            Assert.InRange<int>(42, int.MinValue, 42);
            Assert.InRange<int>(42, 42, int.MaxValue);
            Assert.InRange<int>(42, int.MinValue, int.MaxValue);

            Assert.InRange<char>('e', 'e', 'e');
            Assert.InRange<char>('e', 'a', 'e');
            Assert.InRange<char>('e', 'e', 'z');
            Assert.InRange<char>('e', 'a', 'z');

            Assert.InRange<string>("eee", "eee", "eee");
            Assert.InRange<string>("eee", "aaa", "eee");
            Assert.InRange<string>("eee", "eee", "zzz");
            Assert.InRange<string>("eee", "aaa", "zzz");
        }

        [Fact]
        public void InRange_Type_Custom()
        {
            var ref1 = new AClassWithComparer(1);
            var ref2 = new AClassWithComparer(2);
            var ref3 = new AClassWithComparer(3);

            Assert.InRange<AClassWithComparer>(ref2, ref1, ref3);
        }

        [Fact]
        public void InRange_Type_Custom_WithComparer()
        {
            var ref1 = new AClass(1);
            var ref2 = new AClass(2);
            var ref3 = new AClass(3);

            Assert.InRange<AClass>(ref2, ref1, ref3, new AClassComparer());
        }

        [Fact]
        public void NotInRange_Type_Base()
        {
            Assert.NotInRange<int>(42, 43, 45);
            Assert.NotInRange<char>('a', 'e', 'z');
            Assert.NotInRange<string>("aaa", "eee", "zzz");
        }

        [Fact]
        public void NotInRange_Type_Custom()
        {
            var ref1 = new AClassWithComparer(1);
            var ref2 = new AClassWithComparer(2);
            var ref3 = new AClassWithComparer(3);

            Assert.NotInRange<AClassWithComparer>(ref1, ref2, ref3);
        }

        [Fact]
        public void NotInRange_Type_Custom_WithComparer()
        {
            var ref1 = new AClass(1);
            var ref2 = new AClass(2);
            var ref3 = new AClass(3);

            Assert.NotInRange<AClass>(ref1, ref2, ref3, new AClassComparer());
        }
    }
}