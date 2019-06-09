using Xunit;
using Xunit.Sdk;
using CSharpUnitTesting.assert.Sdk;

namespace CSharpUnitTesting.assert
{
    public class Properties
    {
        [Fact]
        public void PropertyChanged()
        {
            var sut = new AClassWithProperties(1, 1);

            Assert.PropertyChanged(sut, "Value1", () => sut.Value1 = 2);
        }

        [Fact]
        public void PropertyChanged_MultipleChanges()
        {
            var sut = new AClassWithProperties(1, 1);

            Assert.PropertyChanged(sut, "Value2", () => {
                sut.Value1 = 2;
                sut.Value2 = 2;
                sut.Value1 = 3;
            });
        }

        [Fact]
        public void PropertyChanged_ThrowsException_WhenSameValue()
        {
            var sut = new AClassWithProperties(1, 1);

            Assert.Throws<PropertyChangedException>(
                () => Assert.PropertyChanged(sut, "Value1", () => sut.Value1 = 1)
            );
        }

        [Fact]
        public void PropertyChanged_ThrowsException_WhenNoChange()
        {
            var sut = new AClassWithProperties(1, 1);

            Assert.Throws<PropertyChangedException>(
                () => Assert.PropertyChanged(sut, "Value1", () => {})
            );
        }

        [Fact]
        public void PropertyChanged_ThrowsException_WhenBadPropertyName()
        {
            var sut = new AClassWithProperties(1, 1);

            Assert.Throws<PropertyChangedException>(
                () => Assert.PropertyChanged(sut, "Value1", () => sut.Value2 = 2)
            );
        }
    }
}