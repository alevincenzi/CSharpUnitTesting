﻿using Xunit;
using Xunit.Sdk;
using CSharpUnitTesting.assert.Sdk;

// 08 Exceptions
//
// Two levels of test
// - The function actually throws or not the exception
// - Save reference on exception and do further exceptions
//
// Note strict check on exception class hierarchy.
// To be flexible on derived classes --> use ThrowsAny

namespace CSharpUnitTesting.assert
{
    public class Exceptions
    {
        // Warning xUnit2015
        // --> Use Assert.Throws<Type>(Action)
        // Assert.Throws(Type, Action);

        // Warning xUnit2015
        // --> Use var e = Assert.Throws<Type>(Action)
        // var e = Assert.Throws(Type, Action);

        [Fact]
        public void Throws()
        {
            var sut = new AClassWithExceptions();

            var ex = Assert.Throws<BaseException>(
                () => sut.Throw(new BaseException("BaseMessage")));

            Assert.NotNull(ex);
            Assert.IsType<BaseException>(ex);
            Assert.Equal("BaseMessage", ex.Message);
        }

        [Fact]
        public void Throws_ThrowsException_WhenNoExceptionThrown()
        {
            var sut = new AClassWithExceptions();

            Assert.Throws<ThrowsException>( () =>
                Assert.Throws<BaseException>(
                    () => sut.Throw(null))
            );
        }

        [Fact]
        public void Throws_ThrowsException_WhenDerivedException()
        {
            var sut = new AClassWithExceptions();

            Assert.Throws<ThrowsException>( () =>
                Assert.Throws<BaseException>(
                    () => sut.Throw(new DerivedException("DerivedException")))
            );
        }

        [Fact]
        public void ThrowsAny()
        {
            var sut = new AClassWithExceptions();

            var ex = Assert.ThrowsAny<BaseException>(
                () => sut.Throw(new BaseException("BaseMessage")));

            Assert.NotNull(ex);
            Assert.IsType<BaseException>(ex);
            Assert.Equal("BaseMessage", ex.Message);
        }

        [Fact]
        public void ThrowsAny_ThrowsException_WhenNoExceptiontThrown()
        {
            var sut = new AClassWithExceptions();

            Assert.Throws<ThrowsException>( () =>
                Assert.ThrowsAny<BaseException>(
                    () => sut.Throw(null))
            );
        }

        [Fact]
        public void ThrowsAny_DerivedException()
        {
            var sut = new AClassWithExceptions();

            var ex = Assert.ThrowsAny<BaseException>(
                () => sut.Throw(new DerivedException("DerivedMessage")));

            Assert.NotNull(ex);
            Assert.IsType<DerivedException>(ex);
            Assert.Equal("DerivedMessage", ex.Message);
        }
    }
}