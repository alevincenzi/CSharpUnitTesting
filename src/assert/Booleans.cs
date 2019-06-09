﻿using Xunit;
using Xunit.Sdk;

namespace CSharpUnitTesting.assert
{
    public class Booleans
    {
        [Fact]
        public void False()
        {
            Assert.False(0 == 1);
        }

        [Fact]
        public void False_ThrowsException_WhenNull()
        {
            Assert.Throws<FalseException>(
                () => Assert.False(null)
            );
        }

        [Fact]
        public void True()
        {
            Assert.True(1 == 1);
        }

        [Fact]
        public void True_ThrowsException_WhenNull()
        {
            Assert.Throws<TrueException>(
                () => Assert.True(null)
            );
        }
    }
}