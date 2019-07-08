using Xunit;
using Moq;
using CSharpUnitTesting.moq.Sdk;
using System;

// 04 - State based testing
// Set up what properties returns

namespace CSharpUnitTesting.moq
{
    public class Properties
    {
        [Fact]
        void SetBaseValue()
        {
            var moq = new Mock<IPropertyType>();
            var sut = new APropertyUser(moq.Object, 42);

            moq.Setup(x => x.BaseTypeProperty).Returns(42);

            Assert.True(sut.CompareBase());
        }

        [Fact]
        void DefaulBaseValue()
        {
            var moq = new Mock<IPropertyType>();
            var sut = new APropertyUser(moq.Object, 0);

            Assert.True(sut.CompareBase());
        }

        [Fact]
        void SetCustomValue()
        {
            var moqType = new Mock<IPropertyType>();
            var moqValue = new Mock<AClassWithProperty>();

            var sut = new APropertyUser(moqType.Object, 42);

            moqValue.Setup( x => x.Property).Returns(42);
            moqType.Setup(x => x.CustomTypeProperty).Returns(moqValue.Object);

            Assert.True(sut.CompareCustom());
        }

        [Fact]
        void SetCustomValueSimpler()
        {
            var moqType = new Mock<IPropertyType>();

            var sut = new APropertyUser(moqType.Object, 42);

            // Works only if the property is virtual

            moqType.Setup(x => x.CustomTypeProperty.Property).Returns(42);

            Assert.True(sut.CompareCustom());
        }

        [Fact]
        void DefaulCustomValue()
        {
            var moq = new Mock<IPropertyType>();
            var sut = new APropertyUser(moq.Object, 42);

            Assert.Throws<NullReferenceException>(
                () => sut.CompareCustom()
            );
        }

        [Fact]
        void SetupProperty()
        {
            var moq = new Mock<IPropertyType>();
            var sut = new APropertyUser(moq.Object, 0);

            moq.SetupProperty(x => x.Counter);

            sut.Add(10);

            Assert.Equal<int>(10, moq.Object.Counter);
        }

        [Fact]
        void SetupPropertyDefault()
        {
            var moq = new Mock<IPropertyType>();
            var sut = new APropertyUser(moq.Object, 0);

            sut.Add(10);

            Assert.Equal<int>(0, moq.Object.Counter);
        }

        [Fact]
        void SetupPropertyWithInitialValue()
        {
            var moq = new Mock<IPropertyType>();
            var sut = new APropertyUser(moq.Object, 0);

            moq.SetupProperty(x => x.Counter, 42);

            sut.Add(10);

            Assert.Equal<int>(52, moq.Object.Counter);
        }

        [Fact]
        void SetupPropertyAllProperties()
        {
            var moq = new Mock<IPropertyType>();
            var sut = new APropertyUser(moq.Object, 0);

            // Call this before any other moq.Setup(...)
            // To avoid overload of behaviour
            moq.SetupAllProperties();

            sut.Add(10);

            Assert.Equal<int>(10, moq.Object.Counter);
        }
    }
}