using Xunit;
using Xunit.Sdk;
using CSharpUnitTesting.assert.Sdk;

namespace CSharpUnitTesting.assert
{
    public class Events
    {
        [Fact]
        public void Raises()
        {
            var sut = new AClassWithEvents();

            var ev = Assert.Raises<BaseEventArgs>(
                handler => sut.AnEvent += handler,
                handler => sut.AnEvent -= handler,
                () => sut.Raise(new BaseEventArgs(42)));

            Assert.Same(sut, ev.Sender);
            Assert.IsType<BaseEventArgs>(ev.Arguments);
            Assert.Equal(42, ev.Arguments.IValue);
        }

        [Fact]
        public void Raises_ThrowsException_WhenNoEventRaised()
        {
            var sut = new AClassWithEvents();

            Assert.Throws<RaisesException>( () =>
                Assert.Raises<BaseEventArgs>(
                    handler => sut.AnEvent += handler,
                    handler => sut.AnEvent -= handler,
                    () => sut.Raise(null))
            );
        }

        [Fact]
        public void Raises_ThrowsException_WhenDerivedArgs()
        {
            var sut = new AClassWithEvents();

            Assert.Throws<RaisesException>( () =>
                Assert.Raises<BaseEventArgs>(
                    handler => sut.AnEvent += handler,
                    handler => sut.AnEvent -= handler,
                    () => sut.Raise(new DerivedEventArgs(42, "42")))
            );
        }
        
        [Fact]
        public void RaisesAny()
        {
            var sut = new AClassWithEvents();

            var ev = Assert.RaisesAny<BaseEventArgs>(
                handler => sut.AnEvent += handler,
                handler => sut.AnEvent -= handler,
                () => sut.Raise(new BaseEventArgs(42)));

            Assert.Same(sut, ev.Sender);
            Assert.IsType<BaseEventArgs>(ev.Arguments);
            Assert.Equal(42, ev.Arguments.IValue);
        }

        [Fact]
        public void RaisesAny_ThrowsException_WhenNoEventRaised()
        {
            var sut = new AClassWithEvents();

            Assert.Throws<RaisesException>( () =>
                Assert.RaisesAny<BaseEventArgs>(
                    handler => sut.AnEvent += handler,
                    handler => sut.AnEvent -= handler,
                    () => sut.Raise(null))
            );
        }

        [Fact]
        public void RaisesAny_DerivedArgs()
        {
            var sut = new AClassWithEvents();

            var ev = Assert.RaisesAny<BaseEventArgs>(
                handler => sut.AnEvent += handler,
                handler => sut.AnEvent -= handler,
                () => sut.Raise(new DerivedEventArgs(42, "42")));

            Assert.Same(sut, ev.Sender);
            Assert.IsType<DerivedEventArgs>(ev.Arguments);
            Assert.Equal(42,   ((ev.Arguments) as DerivedEventArgs).IValue);
            Assert.Equal("42", ((ev.Arguments) as DerivedEventArgs).SValue);
        }
    }
}